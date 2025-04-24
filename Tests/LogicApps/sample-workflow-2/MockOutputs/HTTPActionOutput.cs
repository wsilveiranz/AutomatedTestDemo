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
    /// The <see cref="HTTPActionMock"/> class.
    /// </summary>
    public class HTTPActionMock : ActionMock
    {
        /// <summary>
        /// Creates a mocked instance for  <see cref="HTTPActionMock"/> with static outputs.
        /// </summary>
        public HTTPActionMock(TestWorkflowStatus status = TestWorkflowStatus.Succeeded, string name = null, HTTPActionOutput outputs = null)
            : base(status: status, name: name, outputs: outputs ?? new HTTPActionOutput())
        {
        }

        /// <summary>
        /// Creates a mocked instance for  <see cref="HTTPActionMock"/> with static error info.
        /// </summary>
        public HTTPActionMock(TestWorkflowStatus status, string name = null, TestErrorInfo error = null)
            : base(status: status, name: name, error: error)
        {
        }

        /// <summary>
        /// Creates a mocked instance for <see cref="HTTPActionMock"/> with a callback function for dynamic outputs.
        /// </summary>
        public HTTPActionMock(Func<TestExecutionContext, HTTPActionMock> onGetActionMock, string name = null)
            : base(onGetActionMock: onGetActionMock, name: name)
        {
        }
    }


    /// <summary>
    /// Class for HTTPActionOutput representing an object with properties.
    /// </summary>
    public class HTTPActionOutput : MockOutput
    {
        public JObject Body { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HTTPActionOutput"/> class.
        /// </summary>
        public HTTPActionOutput()
        {
            this.StatusCode = HttpStatusCode.OK;
            this.Body = new JObject();
        }

    }

}