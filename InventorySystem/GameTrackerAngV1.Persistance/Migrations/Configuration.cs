using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using GameTrackerAngV1.Persistance.Core;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GameTrackerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GameTrackerContext context)
        {
            var itemStatusTracking = new ItemStatus
            {
                Id = 1,
                Status = "Tracking"
            };

            var itemStatusPurchased = new ItemStatus
            {
                Id = 2,
                Status = "Purchased"
            };

            var itemStatusPreOrdered = new ItemStatus
            {
                Id = 3,
                Status = "Preordered"
            };

            var genreMMO = new Genre()
            {
                Id = 1,
                GenreType = "MMO"
            };

            var genreFPS = new Genre()
            {
                Id = 2,
                GenreType = "FPS"
            };

            var genreRPG = new Genre()
            {
                Id = 3,
                GenreType = "RPG"
            };

            var genreAction = new Genre()
            {
                Id = 4,
                GenreType = "Action"
            };

            var trackingCodePurchase = new TrackingCode()
            {
                Id = 1,
                TrackingCodeType = "Purchase"
            };

            var trackingCodePotentialPurchase = new TrackingCode()
            {
                Id = 2,
                TrackingCodeType = "Potential Purchase"
            };

            var trackingCodeWatching = new TrackingCode()
            {
                Id = 3,
                TrackingCodeType = "Watching"
            };

            var categoryGroupVideoGame = new CategoryGroup
            {
                CategoryGroupType = "VideoGame",
                Categories = new Collection<Category>()
                {
                    new Category()
                    {
                        CategoryType = "PS4",
                        VideoGames = new Collection<VideoGame>()
                        {
                            new VideoGame()
                            {
                                Description = "Test a PS4 Game",
                                Price = 59.99,
                                Rating = 8.5,
                                Publisher = "SquareEnix",
                                Developer = "SquareEnix",
                                Status_Id = itemStatusPurchased.Id,
                                ReleaseDate = "TBD",
                                Genre_Id= genreMMO.Id,
                                Tracking_Id = trackingCodePurchase.Id,
                                PurchaseMonth = "June"
                            },
                            new VideoGame()
                            {
                                Description = "Test another PS4 Game",
                                Price = 69.99,
                                Rating = 9.0,
                                Publisher = "CdProject",
                                Developer = "CdProject",
                                Status_Id = itemStatusPreOrdered.Id,
                                ReleaseDate = "June 15, 2016",
                                Genre_Id = genreRPG.Id,
                                Tracking_Id = trackingCodePotentialPurchase.Id,
                                PurchaseMonth = "TBD"
                            }
                        }
                    },
                    new Category()
                    {
                        CategoryType = "Xbox",
                        VideoGames = new Collection<VideoGame>()
                        {
                            new VideoGame()
                            {
                                Description = "Test a Xbox Game",
                                Price = 59.99,
                                Rating = 8.5,
                                Publisher = "Microsoft",
                                Developer = "Microsoft",
                                Status_Id= itemStatusTracking.Id,
                                ReleaseDate = "June 15, 2016",
                                Genre_Id = genreRPG.Id,
                                Tracking_Id = trackingCodePotentialPurchase.Id,
                                PurchaseMonth = "TBD"
                            },
                            new VideoGame()
                            {
                                Description = "Test another Xbox Game",
                                Price = 69.99,
                                Rating = 9.0,
                                Publisher = "EA",
                                Developer = "EA",
                                Status_Id = itemStatusPurchased.Id,
                                ReleaseDate = "June 15, 2016",
                                Genre_Id = genreAction.Id,
                                Tracking_Id = trackingCodeWatching.Id,
                                PurchaseMonth = "TBD"
                            }
                        }
                    },
                    new Category()
                    {
                        CategoryType = "PC",
                        VideoGames = new Collection<VideoGame>()
                        {
                            new VideoGame()
                            {
                                Description = "Testing a PC Game",
                                Price = 59.99,
                                Rating = 8.5,
                                Publisher = "FromSoftware",
                                Developer = "FromSoftware",
                                Status_Id = itemStatusPreOrdered.Id,
                                ReleaseDate = "June 15, 2016",
                                Genre_Id = genreFPS.Id,
                                Tracking_Id = trackingCodePurchase.Id,
                                PurchaseMonth = "TBD"
                            },
                            new VideoGame()
                            {
                                Description = "Test another PC Game",
                                Price = 69.99,
                                Rating = 9.0,
                                Publisher = "Monolith",
                                Developer = "Monolith",
                                Status_Id = itemStatusPurchased.Id,
                                ReleaseDate = "June 15, 2016",
                                Genre_Id = genreMMO.Id,
                                Tracking_Id = trackingCodePotentialPurchase.Id,
                                PurchaseMonth = "TBD"
                            }
                        }
                    }
                }
            };

            var categoryGroupBoardGame = new CategoryGroup
            {
                CategoryGroupType = "BoardGame",
                Categories = new Collection<Category>()
                {
                    new Category()
                    {
                        CategoryType = "Card",
                        BoardGames = new Collection<BoardGame>()
                        {
                            new BoardGame()
                            {
                                Description = "Test a card Game",
                                Price = 29.99,
                                Rating = 8.0,
                                Publisher = "someone",
                                Designer = "someoneelse",
                                Status_Id = itemStatusPurchased.Id,
                                NumberOfPlayers = "4-8",
                                PlayingTime = "30 min - 45 min",
                                PurchaseMonth = "May, 2015"
                            },
                            new BoardGame()
                            {
                                Description = "Test another card Game",
                                Price = 19.99,
                                Rating = 9.0,
                                Publisher = "coop guys",
                                Designer = "montreal company",
                                Status_Id = itemStatusPreOrdered.Id,
                                NumberOfPlayers = "2-6",
                                PlayingTime = "45 min - 1 hour",
                                PurchaseMonth = "June, 2015"
                            }
                        }
                    },
                    new Category()
                    {
                        CategoryType = "Co-op",
                        BoardGames = new Collection<BoardGame>()
                        {
                            new BoardGame()
                            {
                                Description = "Test a co-op Game",
                                Price = 59.99,
                                Rating = 8.5,
                                Publisher = "Tell",
                                Designer = "tee",
                                Status_Id = itemStatusTracking.Id,
                                NumberOfPlayers = "2-10",
                                PlayingTime = "45 min - 1 hour",
                                PurchaseMonth = "March, 2015"

                            },
                            new BoardGame()
                            {
                                Description = "Test another co-op Game",
                                Price = 69.99,
                                Rating = 9.0,
                                Publisher = "boardgamegeek",
                                Designer = "boardgamegeek",
                                Status_Id = itemStatusPurchased.Id,
                                NumberOfPlayers = "4-8",
                                PlayingTime = "45 min",
                                PurchaseMonth = "March, 2015"
                            }
                        }
                    },
                    new Category()
                    {
                        CategoryType = "Strategy",
                        BoardGames = new Collection<BoardGame>()
                        {
                            new BoardGame()
                            {
                                Description = "Test a strategy Game",
                                Price = 59.99,
                                Rating = 7.0,
                                Publisher = "From",
                                Designer = "Software",
                                Status_Id = itemStatusPreOrdered.Id,
                                NumberOfPlayers = "2-4",
                                PlayingTime = "25 min - 35 min",
                                PurchaseMonth = "April, 2015"
                            },
                            new BoardGame()
                            {
                                Description = "Test another strategy Game",
                                Price = 19.99,
                                Rating = 9.0,
                                Publisher = "Monolith",
                                Designer = "Monolith",
                                Status_Id = itemStatusPurchased.Id,
                                NumberOfPlayers = "4-8",
                                PlayingTime = "35 min - 45 min",
                                PurchaseMonth = "Feb, 2015"
                            }
                        }
                    }
                }
            };

            context.ItemStatus.AddOrUpdate(itemStatusTracking);
            context.ItemStatus.AddOrUpdate(itemStatusPurchased);
            context.ItemStatus.AddOrUpdate(itemStatusPreOrdered);
            context.Genres.AddOrUpdate(genreMMO);
            context.Genres.AddOrUpdate(genreFPS);
            context.Genres.AddOrUpdate(genreRPG);
            context.Genres.AddOrUpdate(genreAction);
            context.TrackingCodes.AddOrUpdate(trackingCodePurchase);
            context.TrackingCodes.AddOrUpdate(trackingCodePotentialPurchase);
            context.TrackingCodes.AddOrUpdate(trackingCodeWatching);
            context.CategoryGroups.AddOrUpdate(categoryGroupVideoGame);
            context.CategoryGroups.AddOrUpdate(categoryGroupBoardGame);
        }
    }
}