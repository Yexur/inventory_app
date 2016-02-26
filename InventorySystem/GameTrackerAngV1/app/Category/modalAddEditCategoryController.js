//todo:break out the crud and stuff to other scripts
app.controller('modalAddEditCategoryController',
    ["$scope", "$modalInstance", "dataService", "row",
        function modalAddEditCategoryController($scope, $modalInstance, dataService, row) {

            //checking for an undefined row -  (!!row) will evaluate to false if the row is undefined
            if (!!row) {
                //we have an existing row -set the values
                $scope.newCategory = false;

                $scope.categoryAddEdit = {
                    categoryType: row[0].categoryType,
                    categoryId: row[0].categoryId,
                    categoryGroup: {
                        group: row[0].categoryGroup,
                        value: row[0].categoryGroupId
                    }
                };
            }
            else {
                //we have a new Category
                $scope.newCategory = true;

                $scope.categoryGroups = [];
                //populate the drop down list of Category Groups
                dataService.getCategoryGroups().then(
                    function (results) {
                        // on sucess
                        for (var i = 0; i < results.data.length; i++) {
                            $scope.categoryGroups.push({
                                group: results.data[i].categoryGroup,
                                value: results.data[i].categoryGroupId
                            });
                        }
                        //set the id to 0 - new row and the default group
                        $scope.categoryAddEdit = {
                            categoryId: 0,
                            categoryGroup: $scope.categoryGroups[0]
                        };
                    },
                    function (results) {
                        //on error
                        $scope.hasFormError = true;
                        var err = results.status + ' ' + results.statusText;
                        $scope.formErrors = err;
                    });
            }

            //save the new or added row
            $scope.submitForm = function () {

                $scope.$broadcast('show-errors-event');

                if ($scope.catergoryForm.$invalid)
                    return;

                $scope.category = {
                    CategoryGroupId: $scope.categoryAddEdit.categoryGroup.value,
                    CategoryGroup: $scope.categoryAddEdit.categoryGroup.group,
                    CategoryType: $scope.categoryAddEdit.categoryType,
                    CategoryId: $scope.categoryAddEdit.categoryId,
                    NewCategory: $scope.newCategory
                };

                dataService.saveCategory($scope.category).then(
                    function (results) {
                        //on success - pass the category back to the caller
                        $scope.category.CategoryId = results.data;
                        $modalInstance.close($scope.category);
                    },
                    function (results) {
                        //on error
                        $scope.hasFormError = true;
                        var err = results.status + ' ' + results.statusText;
                        $scope.formErrors = err;
                    }
                );
            };

            $scope.cancelForm = function () {
                $scope.$broadcast('hide-errors-event');
                $modalInstance.dismiss();
            };
        }]);