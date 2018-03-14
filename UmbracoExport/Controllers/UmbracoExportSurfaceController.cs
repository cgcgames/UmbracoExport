using System;
using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;
using UmbracoExport.Core.Models.Enums;
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
            //replace with a dynamic user selected noded
            try
            {
                var homepage = Umbraco.TypedContentSingleAtXPath("//home");

                switch (viewModel.FileType)
                {
                    case FileTypeEnum.CSV:
                        TempData["DownloadUrl"] = _exportService.ExportNodeAndChildrenToCsv(homepage);
                        break;
                    case FileTypeEnum.JSON:
                        TempData["DownloadUrl"] = _exportService.ExportNodeAndChildrenToJson(homepage);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "true";
                TempData["ErrorMessage"] = $"There has been an error with the export: {ex.Message} <br/> check the logs for more details";
                LogHelper.Error<Exception>(ex.Message, ex);
            }
            return RedirectToCurrentUmbracoPage();
        }
    }
}