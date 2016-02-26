using System.Net;
using System.Web.Mvc;
using GameTrackerAngV1.Persistance.Logic;

namespace GameTrackerAngV1.Controllers
{
    public class BoardGameController : Controller
    {
        private readonly IBoardGameLogic _boardGameLogic;

        public BoardGameController(IBoardGameLogic boardGameLogic)
        {
            _boardGameLogic = boardGameLogic;
        }

        //GET
        public ActionResult GetBoardGames()
        {
            var boardGames = _boardGameLogic.GetList();

            if (boardGames != null)
            {
                return ControllerHelper.GetJsonContentResult(boardGames);
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Constants.Constants.ErrorMsg);
        }

        public ActionResult GetPurchasedBoardGamesByCategoryId(int categoryId)
        {
            var boardGames = _boardGameLogic.GetPurchasedBoardGamesByCategoryId(categoryId);

            if (boardGames != null)
            {
                return ControllerHelper.GetJsonContentResult(boardGames);
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Constants.Constants.ErrorMsg);
        }

        //[HttpPost]
        //public ActionResult SaveHobbyItem([Bind(Include = "HobbyId, CategoryId, HobbyItemStatus, Developer, Publisher, Rating, Price, ItemDescription")]
        //    HobbyItemListItem hobbyItemListItem)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Constants.Constants.SaveMsgFailure);
        //    }

        //    try
        //    {
        //        var hobbyId = _hobbyItemLogic.Save(hobbyItemListItem);
        //        return ControllerHelper.GetJsonContentResult(hobbyId);
        //    }
        //    catch (Exception e)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
        //    }
        //}

        //[HttpPost]
        //public ActionResult DeleteGame([Bind(Include = "HobbyId")]
        //    int hobbyId)
        //{
        //    try
        //    {
        //        var success = _hobbyItemLogic.Delete(hobbyId);
        //        return ControllerHelper.GetJsonContentResult(success);
        //    }
        //    catch (Exception e)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
        //    }
        //}
    }
}