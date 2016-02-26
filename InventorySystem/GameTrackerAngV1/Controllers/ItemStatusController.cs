using System.Net;
using System.Web.Mvc;
using GameTrackerAngV1.Persistance.Logic;

namespace GameTrackerAngV1.Controllers
{
    public class ItemStatusController : Controller
    {
        private readonly IItemStatusLogic _itemStatusLogic;

        public ItemStatusController(IItemStatusLogic itemStatusLogic)
        {
            _itemStatusLogic = itemStatusLogic;
        }
        // GET: ItemStatus
        public ActionResult GetItemStatuses()
        {
            var itemStatuses = _itemStatusLogic.GetList();

            if (itemStatuses != null)
            {
                return ControllerHelper.GetJsonContentResult(itemStatuses);
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Constants.Constants.ErrorMsg);
        }
    }
}