using System;
using System.Collections.Generic;
using NuiApiWrapper;

using System.Collections;
using System.Net;
using Jayrock.Json;
using Jayrock.JsonRpc;

using System.Web.Services;

namespace NuiApiWrapper
{
    public class NuiState
    {
        private NuiState() { }

        private static NuiState instance;
        public static NuiState Instance
        {
            get
            {
                if (instance == null)
                    instance = new NuiState();
                return instance;
            }
        }

        JsonRpcClient client;

        //! list of modules available for building pipelines
        private List<ModuleDescriptor> availableModules;

        //! list of pipelines available for building pipelines
        private List<PipelineDescriptor> availablePipelines;

        //! current level, root is 0;
        private int level = 0;

        //! descriptor for current pipeline
        private PipelineDescriptor currentPipeline;

        public void Connect(string url = "http://localhost:8080/")
        {
            client = new JsonRpcClient();
            client.Url = url;
        }

        /************************************************************************/
        /* NAVIGATE                                                             */
        /************************************************************************/
        //! move into next pipeline
        public PipelineDescriptor NavigatePush(int pipelineIdx)
        {
            PipelineDescriptor newPipeline  = (PipelineDescriptor) NuiState.Instance.client.Invoke( 
                typeof(PipelineDescriptor),
                "web_navigate_push");

            NuiState.Instance.level++;
            currentPipeline = newPipeline;

            return newPipeline;
        }

        //! move out of current pipeline
        public PipelineDescriptor NavigatePop()
        {
            PipelineDescriptor newPipeline = (PipelineDescriptor)NuiState.Instance.client.Invoke(
                typeof(PipelineDescriptor),
                "web_navigate_pop");

            NuiState.Instance.level--;
            currentPipeline = newPipeline;

            return newPipeline;
        }

        /************************************************************************/
        /* LIST                                                                 */
        /************************************************************************/

        //! lists dynamic modules
        public string[] ListDynamic()
        {
            string[] listDynamic = (string[])(new ArrayList((ICollection)
                NuiState.Instance.client.Invoke(
                    typeof(PipelineDescriptor),
                    "web_list_dynamic")).ToArray(typeof(string)));

            return listDynamic;
        }

        //! list pipeline modules
        public string[] ListPipeline()
        {
            string[] listPipelines = (string[])(new ArrayList((ICollection)
                NuiState.Instance.client.Invoke(
                    typeof(PipelineDescriptor),
                    "web_list_pipeline")).ToArray(typeof(string)));

            return listPipelines;
        }

        /************************************************************************/
        /* WORKFLOW                                                             */
        /************************************************************************/

        public bool WorkflowStart()
        {
            return (bool)NuiState.Instance.client.Invoke(
                    typeof(bool),
                    "web_workflow_start");
        }

        public bool WorkflowStop()
        {
            return (bool)NuiState.Instance.client.Invoke(
                    typeof(bool),
                    "web_workflow_stop");
        }

        public bool WorkflowQuit()
        {
            return (bool)NuiState.Instance.client.Invoke(
                    typeof(bool),
                    "web_workflow_quit");
        }

        /************************************************************************/
        /* CREATE                                                               */
        /************************************************************************/
        //! creates entirely new pipeline descriptor
        public PipelineDescriptor CreatePipeline(string name)
        {
            PipelineDescriptor pipeline = (PipelineDescriptor)NuiState.Instance.client.InvokeVargs(
                typeof(PipelineDescriptor),
                "web_create_pipeline",
                name);

            return pipeline;
        }

        //! creates new module descriptor in pipeline
        public ModuleDescriptor CreateModule(string pipelineName, string moduleName)
        {
            ModuleDescriptor module = (ModuleDescriptor)NuiState.Instance.client.InvokeVargs(
                typeof(PipelineDescriptor),
                "web_create_module",
                pipelineName, moduleName);

            return module;
        }

        //! create new connection
        public ConnectionDescriptor CreateConnection(string pipelineName,
            int sourceModuleIndex, int sourceModulePort,
            int destModuleIndex, int destModulePort)
        {
            throw new NotImplementedException();
        }

        /************************************************************************/
        /* UPDATE                                                               */
        /************************************************************************/
        public PipelineDescriptor UpdatePipeline(string name)
        {
            throw new NotImplementedException();
        }

        public PipelineDescriptor UpdatePipelineProperty(string name,
            string key, string value, string description)
        {
            throw new NotImplementedException();
        }

        public ModuleDescriptor UpdateModule(string moduleName)
        {
            throw new NotImplementedException();
        }

        public PipelineDescriptor UpdateModuleProperty(string name,
        string key, string value, string description)
        {
            throw new NotImplementedException();
        }

        public ConnectionDescriptor UpdateConnection(string pipelineName,
            int sourceModuleIndex, int sourceModulePort,
            int destModuleIndex, int destModulePort)
        {
            throw new NotImplementedException();
        }

        public EndpointDescriptor UpdateEndpoint()
        {
            throw new NotImplementedException();
        }

        public int UpdateEndpointCount()
        {
            throw new NotImplementedException();
        }

        /************************************************************************/
        /* DELETE                                                               */
        /************************************************************************/

        public void DeletePipeline(string pipelineName)
        {
            throw new NotImplementedException();
        }

        public void DeleteModule(string pipelineName, int moduleIndex)
        {
            throw new NotImplementedException();
        }

        public void DeleteConnection(string pipelineName,
            int srcModuleIdx, int srcModulePort,
            int dstModuleIdx, int dstModulePort)
        {
            throw new NotImplementedException();
        }

        /************************************************************************/
        /* GET                                                                  */
        /************************************************************************/

        public void GetPipeline()
        {
            throw new NotImplementedException();
        }

        public void GetModule()
        {
            throw new NotImplementedException();
        }

        public void GetConnection()
        {
            throw new NotImplementedException();
        }

        /************************************************************************/
        /* SAVE                                                                 */
        /************************************************************************/
        public void Save(string pipelineName)
        {
            throw new NotImplementedException();
        }
    }
}