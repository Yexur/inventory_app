
app.controller('videoGameAddEditController',
    ["$scope", "$modalInstance", "dataService", "cacheService", "row",
        function videoGameAddEditController($scope, $modalInstance, dataService, cacheService, row) {

            $scope.v = cacheService.getVersion(cacheService.categoryKey);
            $scope.categoryOptions = [];
            $scope.itemStatuses = [];
            $scope.trackingCodes = [];
            $scope.genres = [];
            $scope.newGame = true;

            //check if we have a row also check for undefined
            if (!!row) {
                //we have an existing row set the values
                $scope.newGame = false;

                $scope.videoGameAddEdit = {
                    videoGameId: row[0].videoGameId,
                    description: row[0].description,
                    price: row[0].price,
                    rating: row[0].rating,
                    publisher: row[0].publisher,
                    developer: row[0].developer,
                    purchaseMonth: row[0].purchaseMonth,
                    releaseDate: row[0].releaseDate,
                    note: row[0].note
                };
            }

            dataService.getVideoGameCategories($scope.v).then(
                function (results) {
                    //on success
                    for (var i = 0; i < results.data.length; i++) {
                        $scope.categoryOptions.push({
                            id: results.data[i].categoryId,
                            label: results.data[i].categoryType
                        });
                        if (!$scope.newGame) {
                            if (row[0].categoryId == results.data[i].categoryId)
                                $scope.videoGameAddEdit.categoryOption = $scope.categoryOptions[i];
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

            dataService.getItemStatuses().then(
                function (results) {
                    //on success
                    for (var i = 0; i < results.data.length; i++) {
                        $scope.itemStatuses.push({
                            id: results.data[i].id,
                            label: results.data[i].status
                        });

                        if (!$scope.newGame) {
                            if (row[0].status == results.data[i].status)
                                $scope.videoGameAddEdit.itemStatus = $scope.itemStatuses[i];
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


            dataService.getTrackingCodes().then(
               function (results) {
                   //on success
                   for (var i = 0; i < results.data.length; i++) {
                       $scope.trackingCodes.push({
                           id: results.data[i].id,
                           label: results.data[i].trackingCodeType
                       });

                       if (!$scope.newGame) {
                           if (row[0].trackingCode == results.data[i].trackingCodeType)
                               $scope.videoGameAddEdit.trackingCode = $scope.trackingCodes[i];
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

            //add in the genres
            dataService.getGenres().then(
                function (results) {
                    //on success
                    for (var i = 0; i < results.data.length; i++) {
                        $scope.genres.push({
                            id: results.data[i].id,
                            label: results.data[i].genreType
                        });

                        if (!$scope.newGame) {
                            if (row[0].genre == results.data[i].genreType) {
                                $scope.videoGameAddEdit.genre = $scope.genres[i];
                            }
                        }
                    }
                },
                function (results) {
                    //on error
                    $scope.hasFormError = true;
                    var err = results.status + ' ' + results.statusText;
                    $scope.formErrors = err;
                    return;
                });

            $scope.cancelForm = function () {
                $scope.$broadcast('hide-errors-event');
                $modalInstance.dismiss();
            };

            $scope.submitForm = function () {
                $scope.$broadcast('show-errors-event');

                if ($scope.videoGameForm.$invalid)
                    return;

                $scope.videoGame = {
                    Description: $scope.videoGameAddEdit.description,
                    CategoryId: $scope.videoGameAddEdit.categoryOption.id,
                    CategoryType: $scope.videoGameAddEdit.categoryOption.label,
                    Price: $scope.videoGameAddEdit.price,
                    Rating: $scope.videoGameAddEdit.rating,
                    Publisher: $scope.videoGameAddEdit.publisher,
                    Developer: $scope.videoGameAddEdit.developer,
                    Genre: $scope.videoGameAddEdit.genre.label,
                    PurchaseMonth: $scope.videoGameAddEdit.purchaseMonth,
                    ReleaseDate: $scope.videoGameAddEdit.releaseDate,
                    TrackingCode: $scope.videoGameAddEdit.trackingCode.label,
                    Status: $scope.videoGameAddEdit.itemStatus.label,
                    Note: $scope.videoGameAddEdit.note,
                    VideoGameId: $scope.videoGameAddEdit.videoGameId,
                    NewGame: $scope.newGame
                };

                dataService.saveVideoGame($scope.videoGame).then(
                    function (results) {
                        //on success - pass the videoGameId back to the caller
                        $scope.videoGame.VideoGameId = results.data;
                        $modalInstance.close($scope.videoGame);
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