
app.controller('modalDeleteCategoryController',
    ["$scope", "$modalInstance", "dataService", "row",
        function modalDeleteCategoryController($scope, $modalInstance, dataService, row) {

            //checking for an undefined row -  (!!row) will evaluate to false if the row is undefined
            if (!!row) {
                //we have an existing row -set the values
                $scope.categoryDelete = {
                    categoryType: row[0].categoryType,
                    categoryId: row[0].categoryId,
                    categoryGroup: row[0].categoryGroup,
                };
            }
            else {
                $scope.hasFormError = true;
                $scope.formErrors = "Internal Error  - Undefined row";
                return;
            }

            //delete the row
            $scope.deleteCategory = function () {

                dataService.deleteCategory($scope.categoryDelete.categoryId).then(
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