using GameTrackerAngV1.Persistance.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GameTrackerAngV1.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreLogic _genreLogic;

        public GenreController(IGenreLogic genreLogic)
        {
            _genreLogic = genreLogic;
        }

        public ActionResult GetGenres()
        {
            var genres = _genreLogic.GetList();

            if(genres != null)
            {
                return ControllerHelper.GetJsonContentResult(genres);
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, Constants.Constants.ErrorMsg);
        }
    }
}