using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Workflows.UnitTesting.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicApps.Tests.Mocks.sample_workflow;
using System;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.VisualStudio.TestPlatform.Common.Hosting;

namespace LogicApps.Tests
{
    /// <summary>
    /// Contains unit tests for the 'sample-workflow' Logic App workflow using mocked data.
    /// 
    /// This test class demonstrates how to create tests based on a workflow definition file (workflow.json),
    /// rather than from an existing run. This approach is useful when developing new workflows or
    /// testing workflows that haven't been executed yet.
    /// 
    /// Key concepts:
    /// - Mock triggers and actions to simulate workflow execution
    /// - Define expected inputs and outputs for each action
    /// - Verify the workflow behaves as expected with assertions
    /// </summary>
    [TestClass]
    public class create_from_workflow
    {
        /// <summary>
        /// The test executor for running workflow unit tests.
        /// This provides access to the workflow under test and manages test execution.
        /// </summary>
        public TestExecutor TestExecutor;

        /// <summary>
        /// Initializes the test executor before each test.
        /// The configuration file path is relative to the test project's output directory.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            this.TestExecutor = new TestExecutor("sample-workflow/testSettings.config");
        }

        /// <summary>
        /// Unit test for executing the workflow with static mocked data.
        /// 
        /// This test demonstrates:
        /// 1. How to set up mock trigger data
        /// 2. How to configure mock actions with static or dynamic outputs
        /// 3. How to execute the workflow with mocked data
        /// 4. How to assert workflow execution results and outputs
        /// 5. How to validate For_each loop iterations
        /// </summary>
        [TestMethod]
        public async Task Create_From_Definition_MultipleRows()
        {
            // PREPARE: Generate mock trigger and action data.
            var triggerMockOutput = new WhenAHTTPRequestIsReceivedTriggerOutput();
            // Example: triggerMockOutput.Body.Id = "SampleId";
            var triggerMock = new WhenAHTTPRequestIsReceivedTriggerMock(outputs: triggerMockOutput);
            var dvListRow = new ListRowsActionMock(name: "List_rows", onGetActionMock: CallListActionMockOutputCallback);
            var sbSendMessage = new SendMessageActionOutput();
            var sbSendMessageMock = new SendMessageActionMock(name: "Send_message", outputs: sbSendMessage, status: TestWorkflowStatus.Succeeded);

            // ACT: Create and run the workflow with the mock data.
            var testMock = new TestMockDefinition(
                triggerMock: triggerMock,
                actionMocks: new Dictionary<string, ActionMock>()
                {
                    {sbSendMessageMock.Name, sbSendMessageMock},
                    {dvListRow.Name, dvListRow}
                });
            var testRun = await this.TestExecutor
                .Create()
                .RunWorkflowAsync(testMock: testMock).ConfigureAwait(continueOnCapturedContext: false);

            // ASSERT: Verify the workflow executed successfully and outputs are as expected.
            Assert.IsNotNull(value: testRun);
            Assert.AreEqual(expected: TestWorkflowStatus.Succeeded, actual: testRun.Status);
            Assert.IsNotNull(value: testRun.Actions["For_each"].ChildActions["Compose"].Repetitions);
            Assert.AreEqual(expected: TestWorkflowStatus.Succeeded, actual: testRun.Actions["For_each"].ChildActions["Compose"].Status);
            
            var seed = 1000;
            foreach (var repetition in testRun.Actions["For_each"].ChildActions["Compose"].Repetitions)
            {
                Assert.IsNotNull(value: repetition);
                Assert.AreEqual(expected: seed.ToString(), actual: repetition.Outputs["AccountId"]);
                Assert.AreEqual(expected: String.Format("Name {0}",seed), actual: repetition.Outputs["AccountName"]);
                seed++;
            }
        }

        #region Mock generator helpers

        /// <summary>
        /// Callback to dynamically generate mocked data for the 'List_rows' action.
        /// 
        /// This method demonstrates how to create dynamic mock responses for actions that
        /// may require different outputs based on input parameters or test conditions.
        /// You can customize this method to:
        /// - Return different data sets for different test scenarios
        /// - Simulate errors or specific response conditions
        /// - Generate realistic test data programmatically
        /// - Mock pagination or other complex API behaviors
        /// </summary>
        /// <param name="context">The test execution context for the current test run, containing
        /// details about the current workflow execution state and inputs.</param>
        private ListRowsActionMock CallListActionMockOutputCallback(TestExecutionContext context)
        {
            var seed = 1000;
            var body = new ListRowsActionOutputBody
            {
                Value = new List<ListofItems>()
            };
            for (int i = 0; i < 3  ; i++)
            {
                var Account = (seed + i).ToString();
                body.Value.Add(new ListofItems
                {
                    Accountnumber = Account,
                    Name = "Name" + " " + Account
                });
            }
            var actionMockOutput = new ListRowsActionOutput
            {
                Body = body
            };
            ListRowsActionMock actionMock = new(name: "List_rows", status: TestWorkflowStatus.Succeeded, outputs: actionMockOutput);
            Debug.WriteLine($"actionMockOutput: {JsonSerializer.Serialize<ListRowsActionOutput>(actionMockOutput)}");
            Debug.WriteLine($"actionMock: {JsonSerializer.Serialize<ListRowsActionMock>(actionMock)}");
            return actionMock;
        }
        

        #endregion
    }
}