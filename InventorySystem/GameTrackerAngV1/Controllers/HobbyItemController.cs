using System;
using System.Net;
using System.Web.Mvc;
using GameTrackerAngV1.Persistance.Logic;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Controllers
{
    /*public class HobbyItemController : Controller
    {
        private readonly IHobbyLogic _hobbyItemLogic;

        public HobbyItemController(IHobbyLogic hobbyItemLogic)
        {
            _hobbyItemLogic = hobbyItemLogic;
        }

        //GET
        public ActionResult GetHobbyItems()
        {
            var hobbyItems = _hobbyItemLogic.GetList();

            if (hobbyItems != null)
            {
                return ControllerHelper.GetJsonContentResult(hobbyItems);
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Constants.Constants.ErrorMsg);
        }

        [HttpPost]
        public ActionResult GetHobbyItemsByCategoryId([Bind(Include = "CategoryId, CategoryType, CategoryGroupId, CategoryGroup")] CategoryListItem category)
        {
            var hobbyItems = _hobbyItemLogic.GetHobbyItemsByCategoryId(category);

            if (hobbyItems != null)
            {
                return ControllerHelper.GetJsonContentResult(hobbyItems);
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Constants.Constants.ErrorMsg);

        }

        [HttpPost]
        public ActionResult SaveHobbyItem([Bind(Include = "HobbyId, CategoryId, HobbyItemStatus, Developer, Publisher, Rating, Price, ItemDescription")]
            HobbyItemListItem hobbyItemListItem)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Constants.Constants.SaveMsgFailure);
            }

            try
            {
                var hobbyId = _hobbyItemLogic.Save(hobbyItemListItem);
                return ControllerHelper.GetJsonContentResult(hobbyId);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public ActionResult DeleteGame([Bind(Include = "HobbyId")]
            int hobbyId)
        {
            try
            {
                var success = _hobbyItemLogic.Delete(hobbyId);
                return ControllerHelper.GetJsonContentResult(success);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }*/
}
