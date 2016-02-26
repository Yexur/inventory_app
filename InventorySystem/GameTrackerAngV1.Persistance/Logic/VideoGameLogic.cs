
using System.Linq;
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Model;
using GameTrackerAngV1.Persistance.Core;
using System;

namespace GameTrackerAngV1.Persistance.Logic
{
    public class VideoGameLogic : IVideoGameLogic
    {
        private readonly IVideoGameRepository _videoGameRepository;
        private readonly ITrackingCodeLogic _trackingCodeLogic;
        private readonly IItemStatusLogic _itemStatusLogic;
        private readonly IGenreLogic _genreLogic;

        public VideoGameLogic(IVideoGameRepository videoGameRepository, ITrackingCodeLogic trackingCodeLogic, IItemStatusLogic itemStatusLogic, IGenreLogic genreLogic)
        {
            _videoGameRepository = videoGameRepository;
            _trackingCodeLogic = trackingCodeLogic;
            _itemStatusLogic = itemStatusLogic;
            _genreLogic = genreLogic;
        }

        public VideoGame Get(int id)
        {
            return _videoGameRepository.FindById(id);
        }

        public IQueryable<VideoGame> GetList()
        {
            return _videoGameRepository.All();
        }

        public int Save(VideoGameListItem videoGameListItem)
        {
            if (videoGameListItem == null) return -1;

            var videoGame = MapVideoGameListItemToVideoGame(videoGameListItem);
            _videoGameRepository.Insert(videoGame);
            return videoGame.Id;
        }

        public void Delete(int id)
        {
            _videoGameRepository.Delete(id);
        }

        public IQueryable<VideoGameListItem> GetPurchasedVideoGamesByCategoryId(int categoryId)
        {
            if (categoryId <= 0)
            {
                var allVideoGames =
                   _videoGameRepository.All().Where(o => o.Status.Id == (int)Enums.StatusEnum.Purchased);

                return MapVideoGameToVideoGameListItem(allVideoGames);
            }

            var videoGames =
                _videoGameRepository.GetVideoGamesByCategoryId(categoryId)
                      .Where(o => o.Status.Id == (int)Enums.StatusEnum.Purchased);


            return MapVideoGameToVideoGameListItem(videoGames);
        }

        private static IQueryable<VideoGameListItem> MapVideoGameToVideoGameListItem(IQueryable<VideoGame> videoGames)
        {
            if (videoGames == null || !videoGames.Any())
            {
                return Enumerable.Empty<VideoGameListItem>().AsQueryable();
            }

            var videoGameList = videoGames.Select(x => new VideoGameListItem()
            {
                VideoGameId = x.Id,
                CategoryId = x.Category_Id,
                Description = x.Description,
                Price = x.Price,
                Rating = x.Rating,
                CategoryType = x.Category.CategoryType,
                Publisher = x.Publisher,
                Developer = x.Developer,
                Status = x.Status.Status,
                PurchaseMonth = x.PurchaseMonth,
                TrackingCode = x.TrackingCode.TrackingCodeType,
                Genre = x.Genre.GenreType,
                ReleaseDate = x.ReleaseDate,
                Note = x.Note
            });

            return videoGameList;
        }

        private VideoGame MapVideoGameListItemToVideoGame(VideoGameListItem videoGameListItem)
        {            
                return new VideoGame
                {
                    Id = videoGameListItem.VideoGameId,
                    Rating = videoGameListItem.Rating,
                    Publisher = videoGameListItem.Publisher,
                    Developer = videoGameListItem.Developer,
                    ReleaseDate = videoGameListItem.ReleaseDate,
                    PurchaseMonth = videoGameListItem.PurchaseMonth,
                    Description = videoGameListItem.Description,
                    Price = videoGameListItem.Price,
                    Note = videoGameListItem.Note,
                    Category_Id = videoGameListItem.CategoryId,
                    Genre_Id = GetGenre(videoGameListItem.Genre),
                    Status_Id = GetItemStatus(videoGameListItem.Status),
                    Tracking_Id = GetTrackingCode(videoGameListItem.TrackingCode)
                };          
        }

        private int GetGenre(string genre)
        {
            return _genreLogic.GetList().FirstOrDefault(t => t.GenreType == genre).Id;
        }

        private int GetTrackingCode(string trackingCode)
        {
            return _trackingCodeLogic.GetList().FirstOrDefault(t => t.TrackingCodeType == trackingCode).Id;
        }

        private int GetItemStatus(string status)
        {
            return _itemStatusLogic.GetList().FirstOrDefault(t => t.Status == status).Id;
        }
    }
}
