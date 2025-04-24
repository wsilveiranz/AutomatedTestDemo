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
    /// The <see cref="SendMessageActionMock"/> class.
    /// </summary>
    public class SendMessageActionMock : ActionMock
    {
        /// <summary>
        /// Creates a mocked instance for  <see cref="SendMessageActionMock"/> with static outputs.
        /// </summary>
        public SendMessageActionMock(TestWorkflowStatus status = TestWorkflowStatus.Succeeded, string name = null, SendMessageActionOutput outputs = null)
            : base(status: status, name: name, outputs: outputs ?? new SendMessageActionOutput())
        {
        }

        /// <summary>
        /// Creates a mocked instance for  <see cref="SendMessageActionMock"/> with static error info.
        /// </summary>
        public SendMessageActionMock(TestWorkflowStatus status, string name = null, TestErrorInfo error = null)
            : base(status: status, name: name, error: error)
        {
        }

        /// <summary>
        /// Creates a mocked instance for <see cref="SendMessageActionMock"/> with a callback function for dynamic outputs.
        /// </summary>
        public SendMessageActionMock(Func<TestExecutionContext, SendMessageActionMock> onGetActionMock, string name = null)
            : base(onGetActionMock: onGetActionMock, name: name)
        {
        }
    }


    /// <summary>
    /// Class for SendMessageActionOutput representing an empty object.
    /// </summary>
    public class SendMessageActionOutput : MockOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendMessageActionOutput"/> class.
        /// </summary>
        public SendMessageActionOutput()
        {
            this.StatusCode = HttpStatusCode.OK;
        }

    }

}