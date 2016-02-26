using System;
using System.Net;
using System.Web.Mvc;
using GameTrackerAngV1.Persistance.Core;
using GameTrackerAngV1.Persistance.Logic;
using GameTrackerAngV1.Persistance.Model;


namespace GameTrackerAngV1.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryLogic _categoryLogic;

        public CategoryController(ICategoryLogic categoryLogic)
        {
            _categoryLogic = categoryLogic;
        }

        // GET: Category
        public ActionResult GetCategories()
        {
            var categories = _categoryLogic.GetList();
            if (categories != null)
            {
                return ControllerHelper.GetJsonContentResult(categories);
            }
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Constants.Constants.ErrorMsg);
        }


        public ActionResult GetVideoGameCategories()
        {
            return GetCategoryListItemsByGroupType((int) CategoryGroupTypeEnum.CategoryGroupType.VideoGame);
        }

        public ActionResult GetBoardGameCategories()
        {
            return GetCategoryListItemsByGroupType((int)CategoryGroupTypeEnum.CategoryGroupType.BoardGame);
        }

        //todo: we should detrmine how to add a [ValidateAntiForgeryToken]
       [HttpPost]
        public ActionResult SaveCategory([Bind(Include = "CategoryId, CategoryType, CategoryGroupId, CategoryGroup")]
            CategoryListItem categoryListItem)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Constants.Constants.SaveMsgFailure);
            }

            try
            {
                var categoryId = _categoryLogic.Save(categoryListItem);
                return ControllerHelper.GetJsonContentResult(categoryId);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //todo: we should detrmine how to add a [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteCategory([Bind(Include ="CategoryId")]
            int categoryId)
        {
            try
            {
                var success = _categoryLogic.Delete(categoryId);
                return ControllerHelper.GetJsonContentResult(success);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //GET
        private ActionResult GetCategoryListItemsByGroupType(int categoryGroupId)
        {
            var categories = _categoryLogic.GetCategoryListItemsByGroupType(categoryGroupId);
            if (categories != null)
            {
                return ControllerHelper.GetJsonContentResult(categories);
            }
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Constants.Constants.ErrorMsg);
        }

    }
}
