using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using CsvHelper;
using Newtonsoft.Json;
using umbraco.presentation;
using Umbraco.Core;
using Umbraco.Core.Models;
using UmbracoExport.Core.Extentions;
using UmbracoExport.Core.Models;
using UmbracoExport.Core.Services.Interfaces;

namespace UmbracoExport.Core.Services
{
    public class ExportService : IExportService
    {
        public string ExportNodeAndChildrenToJson(IPublishedContent node)
        {
            var json = JsonConvert.SerializeObject(node.GetAllNodes(), Formatting.Indented, new JsonSerializerSettings
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
            var targetDir = HttpContext.Current.Server.MapPath("~/Exports/");
            var fileName = $"{node.Name}_WithChildren_{Guid.NewGuid()}.csv";

            using (var sw = new StreamWriter($@"{targetDir}\{fileName}"))
            using (var cw = new CsvWriter(sw))
            {
                cw.WriteHeader<NodeFlatContent>();

                foreach (var page in node.GetAllNodesFlat())
                {
                    cw.NextRecord();
                    cw.WriteRecord(page);
                }
            }

            return $"/Exports/{fileName}";
        }
    }
}