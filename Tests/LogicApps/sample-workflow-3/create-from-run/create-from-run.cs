using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Workflows.Common.ErrorResponses;
using Microsoft.Azure.Workflows.UnitTesting;
using Microsoft.Azure.Workflows.UnitTesting.Definitions;
using Microsoft.Azure.Workflows.UnitTesting.ErrorResponses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using LogicApps.Tests.Mocks.sample_workflow_3;
using Saxon.Eej.functions.extfn;
using Flow.WebJobs.Extensions.Sdk.Powershell;
using System.Net;
using Newtonsoft.Json.Linq;

namespace LogicApps.Tests
{
    /// <summary>
    /// Contains unit tests for the 'sample-workflow-3' Logic App workflow using mocked data.
    /// 
    /// This test class demonstrates how to create tests based on a previous workflow run,
    /// which is useful for:
    /// 
    /// - Creating regression tests for existing workflows
    /// - Testing complex workflows with many actions and conditions
    /// - Capturing real-world data patterns for testing
    /// - Ensuring workflow modifications don't break existing functionality
    /// 
    /// This approach uses pre-captured mock data (typically stored in a JSON file)
    /// as a baseline, then modifies specific parts to test different scenarios.
    /// </summary>
    [TestClass]
    public class create_from_run
    {
        /// <summary>
        /// The test executor for running workflow unit tests.
        /// Provides access to workflow configuration and execution capabilities.
        /// </summary>
        public TestExecutor TestExecutor;

        /// <summary>
        /// Initializes the test executor before each test.
        /// The configuration file contains settings specific to this workflow,
        /// including paths to necessary resources and test parameters.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            this.TestExecutor = new TestExecutor("sample-workflow-3/testSettings.config");
        }

        /// <summary>
        /// Unit test for executing the workflow with a "insert" message type.
        /// 
        /// This test demonstrates:
        /// 1. Loading pre-defined mock data from an external source (GetTestMockDefinition)
        /// 2. Using the mock data without modifications for the base case scenario
        /// 3. Validating that workflow variables are set to the expected values
        /// 4. Testing the "insert" message path through the workflow
        /// 
        /// This pattern is useful for regression testing to ensure basic functionality
        /// continues to work as expected after changes are made to the workflow.
        /// </summary>
        [TestMethod]
        public async Task CreateFromRun_InsertMessage()
        {
            // PREPARE: Generate mock action and trigger data.
            var mockData = this.GetTestMockDefinition();
            var sampleActionMock = mockData.ActionMocks["Call_External_API"];
            // Example: sampleActionMock.Outputs["your-property-name"] = "your-property-value";

            // ACT: Create and run the workflow with the mock data.
            var executor = this.TestExecutor.Create();
            var testRun = await executor.RunWorkflowAsync(testMock: mockData).ConfigureAwait(continueOnCapturedContext: false);

            // ASSERT: Verify the workflow executed successfully and outputs are as expected.
            Assert.IsNotNull(value: testRun);
            Assert.AreEqual(expected: TestWorkflowStatus.Succeeded, actual: testRun.Status);
            Assert.AreEqual(expected: executor.WorkflowSettings.Parameters["insertTargetUrl"].Value, actual: testRun.Variables["targetUrl"]);
        }

        /// <summary>
        /// Unit test for executing the workflow with an "update" message type.
        /// 
        /// This test demonstrates:
        /// 1. Loading pre-defined mock data and modifying specific properties
        /// 2. Testing conditional logic in workflows by changing trigger inputs
        /// 3. Validating that the workflow follows the correct branch based on input data
        /// 4. Using the same mock data base with small variations to test different paths
        /// 
        /// This approach is efficient for testing workflows with multiple execution paths
        /// since you can reuse the same base mock data and only change the specific
        /// values needed to trigger different logic branches.
        /// </summary>
        [TestMethod]
        public async Task CreateFromRun_UpdateMessage()
        {
            // PREPARE: Generate mock action and trigger data.
            var mockData = this.GetTestMockDefinition();
            mockData.TriggerMock.Outputs["body"]["contentData"]["status"] = "update";

            // ACT: Create and run the workflow with the mock data.
            var executor = this.TestExecutor.Create();
            var testRun = await executor.RunWorkflowAsync(testMock: mockData).ConfigureAwait(continueOnCapturedContext: false);

            // ASSERT: Verify the workflow executed successfully and outputs are as expected.
            Assert.IsNotNull(value: testRun);
            Assert.AreEqual(expected: TestWorkflowStatus.Succeeded, actual: testRun.Status);
            Assert.AreEqual(expected: executor.WorkflowSettings.Parameters["updateTargetUrl"].Value, actual: testRun.Variables["targetUrl"]);
        }

        /// <summary>
        /// Unit test for verifying error handling in the workflow when an external API call fails.
        /// 
        /// This test demonstrates:
        /// 1. Testing error handling and fault tolerance in workflows
        /// 2. Using callback functions to generate dynamic error responses
        /// 3. Verifying that error paths in the workflow behave correctly
        /// 4. Testing compensating actions (like abandoning a queue message) work correctly
        /// 5. Setting up multiple related mock actions with specific status codes
        /// 
        /// Testing failure scenarios is essential for ensuring workflows handle errors
        /// gracefully and perform appropriate recovery or notification actions.
        /// </summary>
        [TestMethod]
        public async Task CreateFromRun_FailedHTTPAction()
        {
            // PREPARE: Generate mock action and trigger data.
            var mockData = this.GetTestMockDefinition();
            mockData.ActionMocks["Call_External_API"] = new CallExternalAPIActionMock(name: "Call_External_API", onGetActionMock: CallExternalAPIActionMockOutputCallback);
            var sbAbandonMessageInAQueue = new AbandonTheMessageInAQueueActionMock(status: TestWorkflowStatus.Succeeded, "Abandon_the_message_in_a_queue", new AbandonTheMessageInAQueueActionOutput());
            // Example: defining a callback function
            mockData.ActionMocks.Add(sbAbandonMessageInAQueue.Name, sbAbandonMessageInAQueue);

            // ACT: Create and run the workflow with the mock data.
            var testRun = await this.TestExecutor
                .Create()
                .RunWorkflowAsync(testMock: mockData).ConfigureAwait(continueOnCapturedContext: false);

            // ASSERT: Verify the workflow executed successfully and the status is 'Succeeded'.
            Assert.IsNotNull(value: testRun);
            Assert.AreEqual(expected: TestWorkflowStatus.Failed, actual: testRun.Status);
        }

        #region Mock generator helpers

        /// <summary>
        /// Returns deserialized test mock data from a JSON file.
        /// 
        /// This helper method:
        /// 1. Constructs the path to the mock data JSON file based on the test configuration
        /// 2. Reads the file containing captured run data
        /// 3. Deserializes it into a TestMockDefinition object that can be used in tests
        /// 
        /// Using a separate JSON file for mock data allows:
        /// - Capturing real production run data for regression testing
        /// - Sharing test data between multiple test methods
        /// - Separating test data from test logic for better maintainability
        /// - Storing complex mock data structures outside the test code
        /// </summary>
        /// <returns>A complete TestMockDefinition containing trigger and actions mocked data</returns>
        private TestMockDefinition GetTestMockDefinition()
        {
            var mockDataPath = Path.Combine(TestExecutor.rootDirectory, "Tests", TestExecutor.logicAppName, TestExecutor.workflow, "create-from-run", "create-from-run-mock.json");
            return JsonConvert.DeserializeObject<TestMockDefinition>(File.ReadAllText(mockDataPath));
        }

        /// <summary>
        /// Callback to generate a mock error response for the 'Call_External_API' action.
        /// 
        /// This method demonstrates:
        /// 1. How to simulate API failures with appropriate HTTP error codes
        /// 2. How to create realistic error payloads for testing error handling
        /// 3. How to configure a mock action to consistently return a failure
        /// 4. Using callbacks to generate dynamic error responses that mimic real failure scenarios
        /// 
        /// Testing error conditions is crucial for ensuring workflows handle exceptions
        /// gracefully and execute the appropriate error handling logic.
        /// </summary>
        /// <param name="context">The test execution context that contains information about the current test run,
        /// including triggers, actions executed so far, and the current execution state.</param>
        public CallExternalAPIActionMock CallExternalAPIActionMockOutputCallback(TestExecutionContext context)
        {
            // Create a new instance of CallExternalAPIActionMock.
            var callExternalAPIActionOutput = new CallExternalAPIActionMock(name: "Call_External_API", status: TestWorkflowStatus.Failed, error: new TestErrorInfo(code: ErrorResponseCode.BadRequest, message: "Input is invalid."));
            return callExternalAPIActionOutput;
        }

        #endregion
    }
}