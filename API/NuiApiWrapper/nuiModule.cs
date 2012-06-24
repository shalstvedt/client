using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace NuiApiWrapper
{
    public class ModuleDescriptor
    {
    /*
    "descriptor": {
		"name" : "pipeline1",
		"description" : "description",
		"author": "author",
		"inputEndpoints": [
			{
				"index" : 1,
				"descriptor" : "audio"
			},
			{
				"index" : 2,
				"descriptor" : "video"
			}],
		"outputEndpoints": [
			{
				"index" : 1,
				"descriptor" : "tree"
			}]
    }
    */
        public string name;
        public string description;
        public string author;
        List<EndpointDescriptor> inputEndpoints;
        List<EndpointDescriptor> outputEndpoints;
    }
}
