using Microsoft.Azure.Workflows.UnitTesting.Definitions;
using Microsoft.Azure.Workflows.UnitTesting.ErrorResponses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System;

namespace LogicApps.Tests.Mocks.sample_workflow_2
{
    /// <summary>
    /// The <see cref="GetBalanceActionMock"/> class.
    /// </summary>
    public class GetBalanceActionMock : ActionMock
    {
        /// <summary>
        /// Creates a mocked instance for  <see cref="GetBalanceActionMock"/> with static outputs.
        /// </summary>
        public GetBalanceActionMock(TestWorkflowStatus status = TestWorkflowStatus.Succeeded, string name = null, GetBalanceActionOutput outputs = null)
            : base(status: status, name: name, outputs: outputs ?? new GetBalanceActionOutput())
        {
        }

        /// <summary>
        /// Creates a mocked instance for  <see cref="GetBalanceActionMock"/> with static error info.
        /// </summary>
        public GetBalanceActionMock(TestWorkflowStatus status, string name = null, TestErrorInfo error = null)
            : base(status: status, name: name, error: error)
        {
        }

        /// <summary>
        /// Creates a mocked instance for <see cref="GetBalanceActionMock"/> with a callback function for dynamic outputs.
        /// </summary>
        public GetBalanceActionMock(Func<TestExecutionContext, GetBalanceActionMock> onGetActionMock, string name = null)
            : base(onGetActionMock: onGetActionMock, name: name)
        {
        }
    }


    /// <summary>
    /// Class for GetBalanceActionOutput representing an object with properties.
    /// </summary>
    public class GetBalanceActionOutput : MockOutput
    {
        public JObject Body { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetBalanceActionOutput"/> class.
        /// </summary>
        public GetBalanceActionOutput()
        {
            this.StatusCode = HttpStatusCode.OK;
            this.Body = new JObject();
        }

    }

}