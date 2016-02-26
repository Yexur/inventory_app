
app.controller('deleteGameController',
    ["$scope", "$modalInstance", "dataService", "row",
        function deleteGameController($scope, $modalInstance, dataService, row) {

            //checking for an undefined row -  (!!row) will evaluate to false if the row is undefined
            if (!!row) {
                //we have an existing row -set the values
                $scope.gameDelete = {
                    itemDescription: row[0].itemDescription,
                    categoryType: row[0].categoryType,
                    publisher: row[0].publisher,
                    developer: row[0].developer,
                    hobbyId: row[0].hobbyId
                };
            }
            else {
                $scope.hasFormError = true;
                $scope.formErrors = "Internal Error  - Undefined row";
                return;
            }

            //delete the row
            $scope.deleteGame = function () {

                dataService.deleteGame($scope.gameDelete.hobbyId).then(
                    function (results) {
                        //on success
                        if (results.data) { //this should be true if we succeeded
                            $modalInstance.close(true);
                        }
                        else {

                            $modalInstance.close(false);
                        }
                    },
                    function (results) {
                        //on error
                        $scope.hasFormError = true;
                        var err = results.status + ' ' + results.statusText;
                        $scope.formErrors = err;
                    });
            };

            $scope.cancelForm = function () {
                $modalInstance.dismiss();
            };
        }]);