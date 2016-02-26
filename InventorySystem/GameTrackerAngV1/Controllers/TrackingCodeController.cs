using System.Net;
using System.Web.Mvc;
using GameTrackerAngV1.Persistance.Logic;

namespace GameTrackerAngV1.Controllers
{
    public class TrackingCodeController : Controller
    {
        private readonly ITrackingCodeLogic _trackingCodeLogic;

        public TrackingCodeController(ITrackingCodeLogic trackingCodeLogic)
        {
            _trackingCodeLogic = trackingCodeLogic;
        }
        // GET: TrackingCode
        public ActionResult GetTrackingCodes()
        {
            var trackingCodes = _trackingCodeLogic.GetList();

            if (trackingCodes != null)
            {
                return ControllerHelper.GetJsonContentResult(trackingCodes);
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Constants.Constants.ErrorMsg);
        }
    }
}