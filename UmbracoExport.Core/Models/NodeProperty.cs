using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;

namespace UmbracoExport.Core.Models
{
    public class NodeProperty
    {
        public string DataValue { get; set; }
        public bool HasValue { get; set; }
        public string PropertyTypeAlias { get; set; }
        public string Value { get; set; }


        public static NodeProperty ToNodeProperty(IPublishedProperty prop)
        {
            return new NodeProperty
            {
                DataValue = prop.DataValue?.ToString(),
                HasValue = prop.HasValue,
                PropertyTypeAlias = prop.PropertyTypeAlias,
                Value = prop.Value?.ToString()
            };
        }
    }
}