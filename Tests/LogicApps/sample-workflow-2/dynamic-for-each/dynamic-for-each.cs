using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Workflows.UnitTesting.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicApps.Tests.Mocks.sample_workflow_2;
using System;
using DotLiquid;
using Microsoft.Identity.Client;
using System.Linq;

namespace LogicApps.Tests
{
    /// <summary>
    /// Contains unit tests for the 'dynamic-for-each' workflow in sample-workflow-2 using mocked data.
    /// 
    /// This test class demonstrates advanced testing techniques for Logic Apps workflows that contain
    /// For Each loops with dynamic content. It shows how to:
    /// 
    /// - Set up multiple interconnected mock actions that depend on each other
    /// - Verify outputs across multiple iterations of a For Each loop
    /// - Use callback functions to dynamically generate mock responses
    /// - Assert complex nested outputs from workflow executions
    /// </summary>
    [TestClass]
    public class dynamic_for_each
    {
        /// <summary>
        /// The test executor for running workflow unit tests.
        /// This instance is initialized before each test method runs.
        /// </summary>
        public TestExecutor TestExecutor;

        /// <summary>
        /// Initializes the test executor before each test.
        /// The configuration file specifies the workflow definition location and test parameters.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            this.TestExecutor = new TestExecutor("sample-workflow-2/testSettings.config");
        }

        /// <summary>
        /// Unit test for executing a workflow with For Each iterations over multiple rows of mocked data.
        /// 
        /// This test demonstrates:
        /// 1. Setting up multiple interdependent mock actions (List, Get, HTTP)
        /// 2. Configuring mock callbacks to generate dynamic responses
        /// 3. Executing a workflow with complex nested actions
        /// 4. Asserting outputs across multiple iterations of a For Each loop
        /// 5. Validating that each iteration correctly processes its specific data
        /// </summary>
        [TestMethod]
        public async Task Dynamic_Callbacks()
        {
            // PREPARE: Generate mock trigger and action data.
            var triggerMockOutput = new WhenAHTTPRequestIsReceivedTriggerOutput();
            // Example: triggerMockOutput.Body.Id = "SampleId";
            var triggerMock = new WhenAHTTPRequestIsReceivedTriggerMock(outputs: triggerMockOutput);
            var dvListRowMock = new ListRowsActionMock(name: "List_Accounts", onGetActionMock: CallListActionMockOutputCallback);
            var dvGetContactMock = new GetARowByIDActionMock(name: "Get_contact", onGetActionMock: CallGetContactActionMockOutputCallback);
            var httpActionMock = new HTTPActionMock(name: "Get_Balance", onGetActionMock: CallGetHTTPActionMockOutputCallback);
            var sbSendMessage = new SendMessageActionOutput();
            var sbSendMessageMock = new SendMessageActionMock(name: "Send_message", outputs: sbSendMessage, status: TestWorkflowStatus.Succeeded);

            // ACT: Create and run the workflow with the mock data.
            var testMock = new TestMockDefinition(
                triggerMock: triggerMock,
                actionMocks: new Dictionary<string, ActionMock>()
                {
                    {sbSendMessageMock.Name, sbSendMessageMock},
                    {dvListRowMock.Name, dvListRowMock},
                    {dvGetContactMock.Name, dvGetContactMock},
                    {httpActionMock.Name, httpActionMock}
                });
            var testRun = await this.TestExecutor
                .Create()
                .RunWorkflowAsync(testMock: testMock).ConfigureAwait(continueOnCapturedContext: false);

            // ASSERT: Verify the workflow executed successfully and outputs are as expected for each repetition.
            Assert.IsNotNull(value: testRun);
            Assert.AreEqual(expected: TestWorkflowStatus.Succeeded, actual: testRun.Status);
            Assert.IsNotNull(value: testRun.Actions["For_each"].ChildActions["Create_Message"].Repetitions);
            Assert.AreEqual(expected: TestWorkflowStatus.Succeeded, actual: testRun.Actions["For_each"].ChildActions["Create_Message"].Status);
            
            for (int i = 0; i < testRun.Actions["For_each"].Inputs["foreachItems"].Count(); i++)
            {
                var messageOutput = testRun.Actions["For_each"].ChildActions["Create_Message"].Repetitions[i];
                Assert.IsNotNull(value: messageOutput);
                Assert.AreEqual(expected: TestWorkflowStatus.Succeeded, actual: messageOutput.Status);
                var message = messageOutput.Outputs;
                Assert.IsNotNull(value: message);
                Assert.IsNotNull(value: message["AccountId"]);
                Assert.IsNotNull(value: message["AccountName"]);
                Assert.IsNotNull(value: message["ContactName"]);
                Assert.IsNotNull(value: message["ContactEmail"]);
                Assert.IsNotNull(value: message["Balance"]);
                var account = testRun.Actions["For_each"].Inputs["foreachItems"][i];
                var contact = testRun.Actions["For_each"].ChildActions["Get_Contact"].Repetitions[i].Outputs["body"];
                var balance = testRun.Actions["For_each"].ChildActions["Get_Balance"].Repetitions[i].Outputs["body"];
                Assert.AreEqual(expected: account["accountnumber"], actual: message["AccountId"]);
                Assert.AreEqual(expected: $"{contact["firstname"]} {contact["lastname"]}", actual: message["ContactName"]);
                Assert.AreEqual(expected: balance["Balance"], actual: message["Balance"]);
                Assert.AreEqual(expected: contact["emailaddress1"], actual: message["ContactEmail"]);
            }
        }

        #region Mock generator helpers
        
        /// <summary>
        /// Callback to generate a mock output for the 'Get_contact' action.
        /// 
        /// This method demonstrates how to create context-aware mock responses that adapt based on
        /// inputs from previous actions or the current iteration context. In this example, it:
        /// 
        /// - Extracts the account number from the current iteration context
        /// - Generates a unique contact with first name, last name, and email for each account
        /// - Simulates the response structure of a real API call to retrieve contact details
        /// - Maintains data consistency across multiple iterations of the workflow
        /// 
        /// Using dynamic callbacks like this allows testing complex workflows where later
        /// actions depend on the specific outputs of earlier actions.
        /// </summary>
        /// <param name="context">The test execution context, including the current iteration input,
        /// which contains the account number to use for generating the contact data.</param>
        private GetARowByIDActionMock CallGetContactActionMockOutputCallback(TestExecutionContext context)
        {
            var body = new GetARowByIDActionOutputBody();
            var accountId = context.ActionContext.CurrentIterationInput.Item["accountnumber"].ToString();
            body.Firstname = $"@@Joe {accountId}";
            body.Lastname = $"Smith {accountId}";
            body.Emailaddress1 = $"Joe.Smith@{accountId}.com";
            var actionMockOutput = new GetARowByIDActionOutput
            {
                Body = body
            };
            GetARowByIDActionMock actionMock = new(name: "Get_contact", status: TestWorkflowStatus.Succeeded, outputs: actionMockOutput);
            return actionMock;
        }

        /// <summary>
        /// Callback to generate a mock output for the 'Get_Balance' HTTP action.
        /// 
        /// This method demonstrates:
        /// 1. How to simulate external HTTP API calls with mock data
        /// 2. Accessing context data from the current For Each iteration
        /// 3. Creating dynamic response data that's contextually related to the current item
        /// 4. Maintaining data consistency between different mock actions
        /// 
        /// This pattern is particularly useful when testing workflows that:
        /// - Call external APIs within loops
        /// - Need to maintain data relationships between iterations
        /// - Require dynamic response content based on the current context
        /// </summary>
        /// <param name="context">The test execution context containing the current iteration input,
        /// which is used to extract the account number and generate appropriate balance data.</param>
        private HTTPActionMock CallGetHTTPActionMockOutputCallback(TestExecutionContext context)
        {
            var accountId = context.ActionContext.CurrentIterationInput.Item["accountnumber"].ToString();
            var body = new HTTPActionOutput()
            {
                Body = new Newtonsoft.Json.Linq.JObject
                {
                    ["AccountId"] = accountId,
                    ["Balance"] = 1000
                },
                StatusCode = System.Net.HttpStatusCode.OK
            };
            return new HTTPActionMock(name: "Get_Balance", status: TestWorkflowStatus.Succeeded, outputs: body);
        }

        /// <summary>
        /// Callback to generate a mock output for the 'List_rows' action.
        /// 
        /// This method demonstrates:
        /// 1. How to generate mock list data for testing collection operations
        /// 2. Creating a dynamic data set of a specific size (3 items)
        /// 3. Structuring mock data to match the expected schema of a data connector
        /// 4. Using a seed value to ensure consistent, predictable test data
        /// 
        /// This pattern is particularly useful for:
        /// - Testing For Each loops with a controlled number of iterations
        /// - Simulating database or API list responses with predictable content
        /// - Creating test data that can be validated in assertions
        /// - Setting up preconditions for downstream actions that iterate over collections
        /// </summary>
        /// <param name="context">The test execution context for the current test run,
        /// though in this case the context isn't used since the mock data is statically generated.</param>
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
            return actionMock;
        }
        #endregion
    }
}