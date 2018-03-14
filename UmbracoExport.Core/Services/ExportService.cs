using System;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using umbraco.presentation;
using Umbraco.Core;
using Umbraco.Core.Models;
using UmbracoExport.Core.Models;
using UmbracoExport.Core.Services.Interfaces;

namespace UmbracoExport.Core.Services
{
    public class ExportService : IExportService
    {
        private NodeContent _exportCollection;

        public string ExportNodeAndChildrenToJson(IPublishedContent node)
        {
            _exportCollection = NodeContent.ToNodeContent(node);
            _exportCollection.Properties.AddRange(node.Properties.Select(NodeProperty.ToNodeProperty));
            if (node.Children.Any())
            {
                GetAllNodes(node, _exportCollection);
            }

            var json = JsonConvert.SerializeObject(_exportCollection, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            var targetDir = HttpContext.Current.Server.MapPath("~/Exports/");
            var fileName = $"{node.Name}_WithChildren_{Guid.NewGuid()}.json";

            //write string to file
            System.IO.File.WriteAllText($@"{targetDir}\{fileName}", json);

            return $"/Exports/{fileName}";
        }

        public string ExportNodeAndChildrenToCsv(IPublishedContent node)
        {
            throw new System.NotImplementedException();
        }

        private static void GetAllNodes(IPublishedContent node, NodeContent nodeContent)
        {
            foreach (var child in node.Children)
            {
                var ncChild = NodeContent.ToNodeContent(child);
                ncChild.Properties.AddRange(child.Properties.Select(NodeProperty.ToNodeProperty));
                nodeContent.Children.Add(ncChild);

                if (child.Children.Any())
                {
                    GetAllNodes(child, ncChild);
                }
            }
        }
    }
}