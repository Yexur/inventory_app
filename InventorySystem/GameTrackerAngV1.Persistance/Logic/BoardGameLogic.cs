
using System.Linq;
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Model;
using GameTrackerAngV1.Persistance.Core;

namespace GameTrackerAngV1.Persistance.Logic
{
    public class BoardGameLogic : IBoardGameLogic
    {
        private readonly IBoardGameRepository _boardGameRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BoardGameLogic(IBoardGameRepository boardGameRepository, ICategoryRepository categoryRepository)
        {
            _boardGameRepository = boardGameRepository;
            _categoryRepository = categoryRepository;
        }

        public BoardGame Get(int id)
        {
            return _boardGameRepository.FindById(id);
        }

        public IQueryable<BoardGame> GetList()
        {
            return _boardGameRepository.All();
        }

        public void Save(BoardGame boardGame)
        {
            _boardGameRepository.Insert(boardGame);
        }

        public void Delete(int id)
        {
            _boardGameRepository.Delete(id);
        }

        public IQueryable<BoardGameListItem> GetPurchasedBoardGamesByCategoryId(int categoryId)
        {
            if (categoryId <= 0)
            {
                var allBoardGames =
                    _boardGameRepository.All().Where(w => w.Status.Id == (int)Enums.StatusEnum.Purchased);

                return MapBoardGameToBoardGameListItem(allBoardGames);
            }

            var boardGames =
                _boardGameRepository.GetBoardGamesByCategoryId(categoryId)
                    .Where(w => w.Status.Id == (int)Enums.StatusEnum.Purchased); 
            return MapBoardGameToBoardGameListItem(boardGames);
        }

        private static IQueryable<BoardGameListItem> MapBoardGameToBoardGameListItem(IQueryable<BoardGame> boardGames)
        {
            if (boardGames == null || !boardGames.Any())
            {
                return Enumerable.Empty<BoardGameListItem>().AsQueryable();
            }

            var boardGameList = boardGames.Select(x => new BoardGameListItem()
            {
                BoardGameId = x.Id,
                CategoryId = x.Category_Id,
                Description = x.Description,
                Price = x.Price,
                Rating = x.Rating,
                CategoryType = x.Category.CategoryType,
                Publisher = x.Publisher,
                Designer = x.Designer,
                Status = x.Status.Status,
                PurchaseMonth = x.PurchaseMonth,
                NumberOfPlayers = x.NumberOfPlayers,
                PlayingTime = x.PlayingTime,
                Note = x.Note

            });

            return boardGameList;
        }
    }
}






