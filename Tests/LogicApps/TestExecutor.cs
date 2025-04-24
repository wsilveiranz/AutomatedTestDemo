using Microsoft.Azure.Workflows.UnitTesting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace LogicApps.Tests
{
    /// <summary>
    /// Provides configuration and creation of a Logic Apps unit test executor.
    /// This is the primary entry point for testing Logic App workflows.
    /// 
    /// The TestExecutor reads configuration from an XML file and uses it to locate
    /// and load the workflow definition, connections, parameters, and local settings
    /// required to execute the workflow in the test environment.
    /// </summary>
    public class TestExecutor
    {                
        /// <summary>
        /// The root directory of the Logic Apps workspace.
        /// This is loaded from the TestSettings:WorkspacePath configuration value.
        /// </summary>
        public string rootDirectory;
        
        /// <summary>
        /// The Logic App name under test.
        /// This is loaded from the TestSettings:LogicAppName configuration value.
        /// </summary>
        public string logicAppName;

        /// <summary>
        /// The workflow name under test.
        /// This is loaded from the TestSettings:WorkflowName configuration value.
        /// </summary>
        public string workflow;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestExecutor"/> class using the specified configuration file.
        /// </summary>
        /// <param name="configPath">The path to the XML configuration file.</param>
        public TestExecutor(string configPath)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile(configPath, optional: false, reloadOnChange: true)
                .Build();

            this.rootDirectory = configuration["TestSettings:WorkspacePath"];
            this.logicAppName = configuration["TestSettings:LogicAppName"];
            this.workflow = configuration["TestSettings:WorkflowName"];
        }

        #region Unit test executor

        /// <summary>
        /// Creates a <see cref="UnitTestExecutor"/> for the configured workflow and Logic App.
        /// 
        /// This method builds the required file paths from the configuration and creates a UnitTestExecutor
        /// that can be used to run the workflow with mock data. The executor loads the workflow definition,
        /// connections, parameters, and local settings from the specified paths.
        /// 
        /// Usage example:
        /// <code>
        /// var executor = new TestExecutor("myWorkflow/testSettings.config").Create();
        /// var testRun = await executor.RunWorkflowAsync(testMock: mockData);
        /// </code>
        /// </summary>
        /// <returns>A configured <see cref="UnitTestExecutor"/> instance ready to run workflow tests.</returns>
        public UnitTestExecutor Create()
        {
            // Build the full paths to the required workflow and configuration files.
            var workflowDefinitionPath = Path.Combine(this.rootDirectory, this.logicAppName, this.workflow, "workflow.json");
            var connectionsPath = Path.Combine(this.rootDirectory, this.logicAppName, "connections.json");
            var parametersPath = Path.Combine(this.rootDirectory, this.logicAppName, "parameters.json");
            var localSettingsPath = Path.Combine(this.rootDirectory, this.logicAppName, "local.settings.json");
            
            return new UnitTestExecutor(
                workflowFilePath: workflowDefinitionPath,
                connectionsFilePath: connectionsPath,
                parametersFilePath: parametersPath,
                localSettingsFilePath: localSettingsPath
            );
        }

        #endregion

    }
}