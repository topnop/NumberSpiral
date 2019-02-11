using NumberSpiral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NumberSpiral.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SpiralInput model = new SpiralInput();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SpiralInput model)
        {
            if (ModelState.IsValid)
            {
                SpiralModel spiralModel = new SpiralModel();

                int rowColCount;
                int[,] spiralMat = SpiralHelper.SpiralArrayTillNumber(model.Number, out rowColCount);

                spiralModel.RowColCount = rowColCount;
                spiralModel.SpiralMatrix = spiralMat;

                return View("Spiral", spiralModel);
            }
            return View(model);
        }

    }
}