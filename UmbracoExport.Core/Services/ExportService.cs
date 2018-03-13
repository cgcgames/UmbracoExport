using System;
using System.Web;
using Newtonsoft.Json;
using umbraco.presentation;
using Umbraco.Core;
using Umbraco.Core.Models;
using UmbracoExport.Core.Services.Interfaces;

namespace UmbracoExport.Core.Services
{
    public class ExportService : IExportService
    {
        public string ExportNodeAndChildrenToJson(IPublishedContent node)
        {
            string json = JsonConvert.SerializeObject(node);

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
    }
}