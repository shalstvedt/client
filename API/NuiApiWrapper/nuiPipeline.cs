using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuiApiWrapper
{
    public class PipelineDescriptor
    {
        public string name;
        public string description;
        public string author;
        public List<ModuleDescriptor> modules;
        public List<EndpointDescriptor> inputEndpoints;
        public List<EndpointDescriptor> outputEndpoints;
        public List<ConnectionDescriptor> connections;
    }
}
