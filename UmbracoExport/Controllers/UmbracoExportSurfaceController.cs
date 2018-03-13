using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoExport.Core.Services.Interfaces;
using UmbracoExport.Models.ViewModels;

namespace UmbracoExport.Controllers
{
    public class UmbracoExportSurfaceController : SurfaceController
    {
        private readonly IExportService _exportService;

        public UmbracoExportSurfaceController(IExportService exportService)
        {
            _exportService = exportService;
        }

        public ActionResult RenderExportForm()
        {
            return PartialView("_ExportForm", new UmbracoExportViewModel());
        }
        // GET
        public ActionResult ExportUmbracoContentTree(UmbracoExportViewModel viewModel)
        {
            
            return RedirectToCurrentUmbracoPage();
        }
    }
}