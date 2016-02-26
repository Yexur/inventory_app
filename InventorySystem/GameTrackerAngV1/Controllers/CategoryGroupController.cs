using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameTrackerAngV1.Persistance.Logic;

namespace GameTrackerAngV1.Controllers
{
    public class CategoryGroupController : Controller
    {
        private readonly ICategoryGroupLogic _categoryGroupLogic;

        public CategoryGroupController(ICategoryGroupLogic categoryGroupLogic)
        {
            _categoryGroupLogic = categoryGroupLogic;
        }

        // GET: CategoryGroup
        public ActionResult GetCategoryGroups()
        {
            var categories = _categoryGroupLogic.GetList();
            if (categories != null)
            {
                return ControllerHelper.GetJsonContentResult(categories);
            }
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Constants.Constants.ErrorMsg);
        }
    }
}
