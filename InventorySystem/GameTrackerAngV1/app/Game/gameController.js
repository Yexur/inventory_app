
app.controller('gameController',
    ["$scope", "dataService", "cacheService", "$modal",
        function gameController($scope, dataService, cacheService, $modal) {

            $scope.title = "Games";

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

            dataService.getBoardGameCategories($scope.v).then(
               function (results) {
                   //on success
                   $scope.boardGameCategoryData = results.data;
                   $scope.boardGameCategoryData.splice(0, 0, {
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
            $scope.getGamesByCategory = function (category) {
                // keep this around for later use in the save and edit functions
                $scope.categoryType = category.categoryType;
                dataService.getHobbyItemsByCategoryId(category).then(
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
                columnDefs: [{ field: 'itemDescription', displayName: 'Title', enableCellEdit: false },
                             { field: 'rating', displayName: 'Rating', enableCellEdit: false },
                             { field: 'developer', displayName: 'Developer', enableCellEdit: false },
                             { field: 'publisher', displayName: 'Publisher', enableCellEdit: false },
                             { field: 'hobbyItemStatus', displayName: 'Status', enableCellEdit: false },
                             { field: 'hobbyId', visible: false },
                             { field: 'categoryId', visible: false },
                             { field: 'categoryType', visible: false }],
                afterSelectionChange: function (row, event) {
                    $scope.hasFormError = false;
                    $scope.saveSuccess = false; //just to clear the msg
                    $scope.cancelled = false;
                }
            };

            $scope.saveGame = function (row) {
                $scope.saveSuccess = false; //just to clear the msg

                if (!!row && row.length == 0) { //if the row is undefined we did not pass a row.
                    //user choose edit but did not pick a row
                    $scope.hasFormError = true;
                    $scope.formErrors = "Please select a Hobby Item to edit";
                    return;
                }

                //go to a new page and create or edit a hobby item.
                var modalWindow = $modal.open(
                    {
                        templateUrl: 'app/Game/GameAddEdit.html',
                        controller: 'addEditGameController',
                        resolve: {
                            row: function () {
                                return row;
                            }
                        }

                    });

                modalWindow.result.then(
                 function (hobby) {
                     //on sucessful save
                     //check for a new row
                     if (hobby.NewGame && hobby.CategoryType == $scope.categoryType) {
                         $scope.gridData.push({
                             itemDescription: hobby.ItemDescription,
                             rating: hobby.Rating,
                             developer: hobby.Developer,
                             publisher: hobby.Publisher,
                             hobbyItemStatus: hobby.HobbyItemStatus,
                             hobbyId: hobby.HobbyId
                         });
                         $scope.saveSuccess = true;
                         $scope.formSaveMsg = "Successfully added new Hobby Item.";
                     }
                     else {
                         var index = $scope.gridData.indexOf(row[0]); //index of the selected row.  We only ever have 1 selected row
                         $scope.gridData[index].itemDescription = hobby.ItemDescription;
                         $scope.gridData[index].rating = hobby.Rating;
                         $scope.gridData[index].developer = hobby.Developer;
                         $scope.gridData[index].publisher = hobby.Publisher;
                         $scope.gridData[index].hobbyItemStatus = hobby.HobbyItemStatus;
                         $scope.gridData[index].hobbyId = hobby.HobbyId,
                         $scope.gridData[index].categoryId = hobby.CategoryId,
                         $scope.gridData[index].categoryType = hobby.CategoryType;
                         
                         $scope.gridOptions.selectItem(index, false);

                         $scope.saveSuccess = true;
                         $scope.formSaveMsg = "Successfully updated the Hobby Item.";
                     }

                     //update the versionData to force a new call to the DB
                     //$scope.v++;
                     // cacheService.setVersion(cacheService.categoryKey, $scope.v);
                 },
                 function () {
                     //cancel - do nothing
                     $scope.cancelled = true;
                     $scope.formCancel = "Transaction cancelled.";
                 });
            };

            $scope.deleteGame = function (row) {

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
            };
        }
    ])


