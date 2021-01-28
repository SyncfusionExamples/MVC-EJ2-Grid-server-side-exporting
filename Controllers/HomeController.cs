using System.Collections.Generic;
using System.Web.Mvc;
using Syncfusion.EJ2.Grids;
using Syncfusion.EJ2.GridExport;
using GridExportMVC.Models;

namespace GridExportMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var Order = OrdersDetails.GetAllRecords();
            ViewBag.DataSource = Order;
            return View();
        }
        public ActionResult ExcelExport(string gridModel)
        {
            GridExcelExport exp = new GridExcelExport();
            Grid gridProperty = ConvertGridObject(gridModel);
            return exp.ExcelExport<OrdersDetails>(gridProperty, OrdersDetails.GetAllRecords());
        }
        public ActionResult PdfExport(string gridModel)
        {
            GridPdfExport exp = new GridPdfExport();
            Grid gridProperty = ConvertGridObject(gridModel);
            return exp.PdfExport<OrdersDetails>(gridProperty, OrdersDetails.GetAllRecords());
        }

        private Grid ConvertGridObject(string gridProperty)
        {
            Grid GridModel = (Grid)Newtonsoft.Json.JsonConvert.DeserializeObject(gridProperty, typeof(Grid));
            GridColumnmodel cols = (GridColumnmodel)Newtonsoft.Json.JsonConvert.DeserializeObject(gridProperty, typeof(GridColumnmodel));
            GridModel.Columns = cols.columns;
            return GridModel;
        }
        public class GridColumnModel
        {
            public List<GridColumn> columns { get; set; }
        }
    }
}