using System.Net;
using System.Web.Mvc;
using GameTrackerAngV1.Persistance.Logic;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Controllers
{
    public class VideoGameController : Controller
    {
        private readonly IVideoGameLogic _videoGameLogic;

        public VideoGameController(IVideoGameLogic videoGameLogic)
        {
            _videoGameLogic = videoGameLogic;
        }

        //GET
        public ActionResult GetVideoGames()
        {
            var videoGames = _videoGameLogic.GetList();

            if (videoGames != null)
            {
                return ControllerHelper.GetJsonContentResult(videoGames);
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Constants.Constants.ErrorMsg);
        }

        public ActionResult GetPurchasedVideoGamesByCategoryId(int categoryId)
        {
            var videoGames = _videoGameLogic.GetPurchasedVideoGamesByCategoryId(categoryId);

            if (videoGames != null)
            {
                return ControllerHelper.GetJsonContentResult(videoGames);
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Constants.Constants.ErrorMsg);

        }

        [HttpPost]
        public ActionResult SaveVideoGame(
            [Bind(Include = "VideoGameId, CategoryId, CategoryType, Status, Note, Developer, Publisher, Rating, Price, Description, ReleaseDate, Genre, TrackingCode, PurchaseMonth")]
            VideoGameListItem videoGameListItem)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Constants.Constants.SaveMsgFailure);
            }

            try
            {
                var videoGameId = _videoGameLogic.Save(videoGameListItem);
                return ControllerHelper.GetJsonContentResult(videoGameId);
            }
            catch (System.Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
        }

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