using ES1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ES1.Controllers
{
    public class HomeController : Controller
    {
        [Route("parametervalues")]
        public ActionResult Values(int id)
        {       
            if(CurrentVariants == null)
            {
                CurrentVariants = DBHelper.ParametersValues;
            }

            return Json(DBHelper.GetParameterValues(id, CurrentVariants), JsonRequestBehavior.AllowGet);
        }

        [Route("setparameter")]
        public ActionResult Set(int id, string value)
        {
            if(value == null)
            {
                return Content("");
            }

            var records = DBHelper.ExcludeByParameter(id, value, CurrentVariants);
            if(records.Count == 1){
                CurrentVariants = DBHelper.ParametersValues;
                return Content(records[0].Last().Value);
            }

            CurrentVariants = records;
            return Content("");
        }

        [Route("Refresh")]
        public ActionResult Refresh()
        {
            CurrentVariants = DBHelper.ParametersValues;
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        private List<Dictionary<int, string>> CurrentVariants
        {
            get { return (List<Dictionary<int, string>>)Session["Variants"]; }
            set { Session["Variants"] = value; }
        }

    }
}