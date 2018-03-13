using Umbraco.Core.Models;

namespace UmbracoExport.Core.Services.Interfaces
{
    public interface IExportService 
    {
        string ExportNodeAndChildrenToJson(IPublishedContent node);


        string ExportNodeAndChildrenToCsv(IPublishedContent node);
    }
}