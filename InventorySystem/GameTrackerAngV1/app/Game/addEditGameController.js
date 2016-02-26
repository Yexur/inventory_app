
app.controller('addEditGameController',
    ["$scope", "$modalInstance", "dataService", "cacheService", "row",
        function ($scope, $modalInstance, dataService, cacheService, row) {

            $scope.v = cacheService.getVersion(cacheService.categoryKey);
            $scope.categoryOptions = [];
            $scope.hobbyItemStatuses = [];

            //thus is first   need to fix werer we set the defaults


            //add in the call to get the data for the drop downs in each section of the if. If that works then put them in their own javascript
            //need to refactor so some of this is in its own jscript - we can callit from there

            //check if we have a row also check for undefined
            if (!!row) {
                //we have an existing row set the values
                $scope.newGame = false;

                $scope.gameAddEdit = {
                    //hobbyItemStatus: $scope.editRowHobbyItemStatus,
                    //categoryOption: $scope.editRowCategory,
                    hobbyId: row[0].hobbyId,
                    itemDescription: row[0].itemDescription,
                    price: row[0].price,
                    rating: row[0].rating,
                    publisher: row[0].publisher,
                    developer: row[0].developer
                };

                dataService.getCategories($scope.v).then(
                    function (results) {
                        //on success
                        for (var i = 0; i < results.data.length; i++) {
                            $scope.categoryOptions.push({
                                id: results.data[i].categoryId,
                                group: results.data[i].categoryGroup,
                                label: results.data[i].categoryType
                            });

                            if (row[0].categoryId == results.data[i].categoryId) {
                                $scope.gameAddEdit.categoryOption = $scope.categoryOptions[i];
                            }
                        }
                    },
                    function (results) {
                        // on error
                        $scope.hasFormError = true;
                        var err = results.status + ' ' + results.statusText;
                        $scope.formErrors = err;
                        return;
                    });

                dataService.getHobbyItemStatuses().then(
                       function (results) {
                           //on success
                           for (var i = 0; i < results.data.length; i++) {
                               $scope.hobbyItemStatuses.push({
                                   id: results.data[i].id,
                                   label: results.data[i].itemStatus
                               });

                               if (row[0].hobbyItemStatus == results.data[i].itemStatus) {
                                   $scope.gameAddEdit.hobbyItemStatus = $scope.hobbyItemStatuses[i];
                               }
                           }
                       },
                       function (results) {
                           // on error
                           $scope.hasFormError = true;
                           var err = results.status + ' ' + results.statusText;
                           $scope.formErrors = err;
                           return;
                       });
            }
            else {
                //we have a new row
                $scope.newGame = true;
                //set the default Hobby Item Status
                $scope.gameAddEdit = {
                    hobbyId: 0,
                 };
              
                dataService.getCategories($scope.v).then(
                    function (results) {
                        //on success
                        for (var i = 0; i < results.data.length; i++) {
                            $scope.categoryOptions.push({
                                id: results.data[i].categoryId,
                                group: results.data[i].categoryGroup,
                                label: results.data[i].categoryType
                            });
                        }
                        //set the default category
                        $scope.gameAddEdit.categoryOption = $scope.categoryOptions[0];
                    },
                    function (results) {
                        // on error
                        $scope.hasFormError = true;
                        var err = results.status + ' ' + results.statusText;
                        $scope.formErrors = err;
                        return;
                    });

                dataService.getHobbyItemStatuses().then(
                       function (results) {
                           //on success
                           for (var i = 0; i < results.data.length; i++) {
                               $scope.hobbyItemStatuses.push({
                                   id: results.data[i].id,
                                   label: results.data[i].itemStatus
                               });
                           }
                           //set the default hobbyItemStatus
                           $scope.gameAddEdit.hobbyItemStatus = $scope.hobbyItemStatuses[0];
                       },
                       function (results) {
                           // on error
                           $scope.hasFormError = true;
                           var err = results.status + ' ' + results.statusText;
                           $scope.formErrors = err;
                           return;
                       });
            }

            //need the submit method and the cancel method
            $scope.cancelForm = function () {
                $modalInstance.dismiss();
            };

            //need to send back to the calling page and update the grid
            $scope.submitForm = function () {
                $scope.$broadcast('show-errors-event');

                if ($scope.gameForm.$invalid)
                    return;

               $scope.game = {
                    ItemDescription: $scope.gameAddEdit.itemDescription,
                    CategoryId: $scope.gameAddEdit.categoryOption.id,
                    CategoryType: $scope.gameAddEdit.categoryOption.label,
                    Price: $scope.gameAddEdit.price,
                    Rating: $scope.gameAddEdit.rating,
                    Publisher: $scope.gameAddEdit.publisher,
                    Developer: $scope.gameAddEdit.developer,
                    HobbyItemStatus: $scope.gameAddEdit.hobbyItemStatus.label,
                    HobbyId: $scope.gameAddEdit.hobbyId,
                    NewGame: $scope.newGame
                };

                dataService.saveHobbyItem($scope.game).then(
                    function (results) {
                        //on success - pass the hobbyItme back to the caller
                        $scope.game.HobbyId = results.data;
                        $modalInstance.close($scope.game);
                    },
                    function (results) {
                        //on error
                        $scope.hasFormError = true;
                        var err = results.status + ' ' + results.statusText;
                        $scope.formErrors = err;
                    }
                );
            };
        }])