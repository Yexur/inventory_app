
app.controller('categoryController',
    ["$scope", "dataService", "$modal", "cacheService",
    function categoryController($scope, dataService, $modal, cacheService) {
        $scope.title = "Category";

       $scope.v = cacheService.getVersion(cacheService.categoryKey);

        dataService.getCategories($scope.v).then(
                 function (results) {
                     // on success
                     $scope.categoryData = results.data;
                 },
                function (results) {
                    // on error
                    $scope.hasFormError = true;
                    var err = results.status + ' ' + results.statusText;
                    $scope.formErrors = err;
                    return;
                }
             );

       //setup the grid of Categories
        $scope.gridOptions = {
            data: 'categoryData',
            enableCellSelection: false,
            enableRowSelection: true,
            enableCellEdit: false,
            multiSelect: false,
            selectedItems: [],
            columnDefs: [{ field: 'categoryType', displayName: 'Category', enableCellEdit: false },
                         { field: 'categoryGroup', displayName: 'Hobby Type', enableCellEdit: false },
                         { field: 'categoryId', visible: false },
                         { field: 'categoryGroupId', visible: false }],
            afterSelectionChange: function (row, event) {
                $scope.hasFormError = false;
                $scope.saveSuccess = false; //just to clear the msg
                $scope.cancelled = false;
            }
        };

        $scope.saveCategory = function (row) {
            $scope.saveSuccess = false; //just to clear the msg

            if (!!row && row.length == 0) {
                //user choose edit but did not pick a row
                $scope.hasFormError = true;
                $scope.formErrors = "Please select a Category to edit";
                return;
            }

            var modalWindow = $modal.open(
              {
                  templateUrl: 'app/Category/CategoryAddEdit.html',
                  controller: 'modalAddEditCategoryController',
                  resolve: {
                      row: function () {
                          return row;
                      }
                  }
              });

            modalWindow.result.then(
                 function (category) {
                     //on sucessful save
                     //check for a new row
                     if (category.NewCategory) {
                         $scope.categoryData.push({
                             categoryType: category.CategoryType,
                             categoryGroup: category.CategoryGroup,
                             categoryId: category.CategoryId,
                             categoryGroupId: category.CategoryGroupId
                         });
                         $scope.saveSuccess = true;
                         $scope.formSaveMsg = "Successfully added new Category.";
                     }
                     else {
                         var index = $scope.categoryData.indexOf(row[0]); //index of the selected row.  We only ever have 1 selected row
                         $scope.categoryData[index].categoryType = category.CategoryType;
                         $scope.categoryData[index].categoryGroup = category.CategoryGroup;
                         $scope.categoryData[index].categoryId = category.CategoryId;
                         $scope.categoryData[index].categoryGroupId = category.CategoryGroupId;

                         //clear the selected row
                         $scope.gridOptions.selectItem(index, false);

                         $scope.saveSuccess = true;
                         $scope.formSaveMsg = "Successfully updated the Category.";
                     }

                     //update the versionData to force a new call to the DB
                     $scope.v++;
                     cacheService.setVersion(cacheService.categoryKey, $scope.v);
                 },
                 function () {
                     //cancel - do nothing
                     $scope.cancelled = true;
                     $scope.formCancel = "Transaction cancelled.";
                 });

        };

        $scope.deleteCategory = function (row) {

            $scope.saveSuccess = false; //just to clear the msg
            $scope.cancelled = false;

            if (!!row && row.length == 0) {
                //user choose edit but did not pick a row
                $scope.hasFormError = true;
                $scope.formErrors = "Please select a Category to delete";
                return;
            }

            var index = $scope.categoryData.indexOf(row[0]);
            var modalWindow = $modal.open(
              {
                  templateUrl: 'app/Category/CategoryDelete.html',
                  controller: 'modalDeleteCategoryController',
                  resolve: {
                      row: function () {
                          return row;
                      }
                  }
              });

            //pass the delete object back to here and check the boolean for failure or success
            //if we have a failure then display the message we passed back
            modalWindow.result.then(
                 function (success) {
                     //on successful delete
                     if (success) {
                         $scope.categoryData.splice(index, 1);
                         $scope.saveSuccess = true;
                         $scope.formSaveMsg = "Successfully deleted the Category.";
                         
                         //clear the selected row
                         $scope.gridOptions.selectItem(index, false);

                         //update the versionData to force a new call to the DB
                         $scope.v++;
                         cacheService.setVersion(cacheService.categoryKey, $scope.v);
                         
                     }
                     else {
                         //we have items attached to the category - so we cannot delete it
                         $scope.hasFormError = true;
                         $scope.formErrors = "The Category has items associated to it and cannot be deleted.";
                     }

                 },
                 function () {
                     //cancel - do nothing
                     $scope.cancelled = true;
                     $scope.formCancel = "Transaction cancelled.";
                 });
        };

    }]);