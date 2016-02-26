
app.controller('videoGameController',
    ["$scope", "dataService", "cacheService", "$modal",
        function videoGameController($scope, dataService, cacheService, $modal) {

            $scope.title = "Video Games";

            //use the category key to get the correct version of the category list
            $scope.v = cacheService.getVersion(cacheService.categoryKey);
            
            
            dataService.getVideoGameCategories($scope.v).then(
                function (results) {
                    //on success
                    $scope.videoGameCategoryData = results.data;
                    $scope.videoGameCategoryData.splice(0, 0, {
                        categoryId: -1,
                        categoryType: "All",
                        categoryGroup: results.data[0].categoryGroup,
                        categoryGroupId: results.data[0].categoryGroupId
                    });
                },
                function (results) {
                    // on error
                    $scope.hasFormError = true;
                    var err = results.status + ' ' + results.statusText;
                    $scope.formErrors = err;
                }
            );

            //now we need to build the grid
            $scope.getPurchasedVideoGamesByCategory = function (category) {
                // keep this around for later use in the save and edit functions
                $scope.categoryType = category.categoryType;
                dataService.getPurchasedVideoGamesByCategoryId(category.categoryId).then(
                    function (results) {
                        $scope.gridData = results.data;
                    },
                    function (results) {
                        // on error
                        $scope.hasFormError = true;
                        var err = results.status + ' ' + results.statusText;
                        $scope.formErrors = err;
                        return;
                    }
                );
            };

            $scope.gridOptions = {
                data: 'gridData',
                enableCellSelection: false,
                enableRowSelection: true,
                enableCellEdit: false,
                multiSelect: false,
                selectedItems: [],
                enableColumnResize: true,
                columnDefs: [{ field: 'description', displayName: 'Title', enableCellEdit: false, width: 250 },
                             { field: 'rating', displayName: 'Rating', enableCellEdit: false, width: 100 },
                             { field: 'developer', displayName: 'Developer', enableCellEdit: false, width: 175 },
                             { field: 'publisher', displayName: 'Publisher', enableCellEdit: false, width: 175 },
                             { field: 'genre', displayName: 'Genre', enableCellEdit: false, width: 100 },
                             { field: 'categoryType', displayName: 'System', enableCellEdit: false, width: 100 },
                             { field: 'videoGameId', visible: false },
                             { field: 'categoryId', visible: false }],
                afterSelectionChange: function (row, event) {
                    $scope.hasFormError = false;
                    $scope.saveSuccess = false; 
                    $scope.cancelled = false;
                }
            };

            $scope.saveVideoGame = function (row) {
                $scope.saveSuccess = false;
 
                if (!!row && row.length == 0) { //if the row is undefined we did not pass a row.
                    $scope.hasFormError = true;
                    $scope.formErrors = "Please select a Video Game to edit";
                    return;
                }
 
                var modalWindow = $modal.open(
                     {
                         templateUrl: 'app/VideoGame/VideoGameAddEdit.html',
                         controller: 'videoGameAddEditController',
                         resolve: {
                             row: function () {
                                 return row;
                             }
                         }
 
                     });
 
                modalWindow.result.then(
                 function (videoGame) {
                     if (videoGame.NewGame && videoGame.CategoryType == $scope.categoryType) {
                         $scope.gridData.push({
                             description: videoGame.Description,
                             rating: videoGame.Rating,
                             developer: videoGame.Developer,
                             publisher: videoGame.Publisher,
                             genre: videoGame.Genre,
                             videoGameId: videoGame.VideoGameId,
                             categoryType: videoGame.CategoryType,
                             categoryId: videoGame.CategoryId
                         });
 
                     }
                     else {
                         if (videoGame.CategoryType == $scope.categoryType) {
                             var index = $scope.gridData.indexOf(row[0]); //index of the selected row.  We only ever have 1 selected row
                             $scope.gridData[index].description = videoGame.Description;
                             $scope.gridData[index].rating = videoGame.Rating;
                             $scope.gridData[index].developer = videoGame.Developer;
                             $scope.gridData[index].publisher = videoGame.Publisher;
                             $scope.gridData[index].genre = videoGame.Genre;
                             $scope.gridData[index].videoGameId = videoGame.videoGameId;
                             $scope.gridData[index].categoryId = videoGame.CategoryId,
                             $scope.gridData[index].categoryType = videoGame.CategoryType;

                             $scope.gridOptions.selectItem(index, false);                                                          
                         }

                     }
                     $scope.saveSuccess = true;
                     $scope.formSaveMsg = "Successfully added the new Video Game.";
 
                 },
                 function () {
                     //cancel - do nothing
                     $scope.cancelled = true;
                     $scope.formCancel = "Transaction cancelled.";
                 });
            };
 
            /*$scope.deleteGame = function (row) {

                $scope.saveSuccess = false; //just to clear the msg
                $scope.cancelled = false;

                if (!!row && row.length == 0) {
                    //user choose edit but did not pick a row
                    $scope.hasFormError = true;
                    $scope.formErrors = "Please select an item to delete";
                    return;
                }

                var index = $scope.gridData.indexOf(row[0]);
                var modalWindow = $modal.open(
                  {
                      templateUrl: 'app/Game/GameDelete.html',
                      controller: 'deleteGameController',
                      resolve: {
                          row: function () {
                              return row;
                          }
                      }
                  });

                //pass the delete object back to here and check the boolean for failure or success
                //if we have a failure then display the message we passed back
                modalWindow.result.then(
                     function () {
                         //on successful delete
                         $scope.gridData.splice(index, 1);
                         $scope.saveSuccess = true;
                         $scope.formSaveMsg = "Successfully deleted the Game.";
                         $scope.gridOptions.selectItem(index, false);
                         //update the versionData to force a new call to the DB
                         //$scope.v++;
                         //cacheService.setVersion(cacheService.categoryKey, $scope.v);
                     },
                     function () {
                         //cancel - do nothing
                         $scope.cancelled = true;
                         $scope.formCancel = "Transaction cancelled.";
                     });
            };*/
        }
    ])