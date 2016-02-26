
app.factory('dataService',
    ['$http',
    function ($http) {
        //Categories
        var getCategories = function (v) {
            return $http.get("Category/GetCategories/?v=" + v);
        };

        var getCategoryGroups = function () {
            return $http.get("CategoryGroup/GetCategoryGroups");
        };

        var saveCategory = function (category) {
            return $http.post("Category/SaveCategory", category);
        };

        var deleteCategory = function (id) {
            return $http.post("Category/DeleteCategory/?categoryId=" + id);
        };

        var getVideoGameCategories = function (v) {
            return $http.get("Category/getVideoGameCategories/?v=" + v);
        };

        var getBoardGameCategories = function (v) {
            return $http.get("Category/getBoardGameCategories/?v=" + v);
        };

        //Video Games
        var saveVideoGame = function (videoGame) {
            return $http.post("VideoGame/SaveVideoGame", videoGame);
        };

        var deleteVideoGame = function (id) {
            return $http.post("VideoGame/DeleteVideoGame/?videoGameId=" + id);
        };

        var getPurchasedVideoGamesByCategoryId = function (categoryId) {
            return $http.get("VideoGame/GetPurchasedVideoGamesByCategoryId/?categoryId=" + categoryId);
        };

        //Board Games
        var getPurchasedBoardGamesByCategoryId = function (categoryId) {
            return $http.get("BoardGame/GetPurchasedBoardGamesByCategoryId/?categoryId=" + categoryId);
        };

        //Misc
        var getItemStatuses = function () {
            return $http.get("ItemStatus/GetItemStatuses");
        };

        var getTrackingCodes = function() {
            return $http.get("TrackingCode/GetTrackingCodes");
        };

        var getGenres = function () {
            return $http.get("Genre/GetGenres");
        };

        return {
            getCategories: getCategories,
            getCategoryGroups: getCategoryGroups,
            saveCategory: saveCategory,
            deleteCategory: deleteCategory,
            getVideoGameCategories: getVideoGameCategories,
            saveVideoGame: saveVideoGame,
            deleteVideoGame: deleteVideoGame,
            getBoardGameCategories: getBoardGameCategories,
            getPurchasedVideoGamesByCategoryId: getPurchasedVideoGamesByCategoryId,
            getPurchasedBoardGamesByCategoryId: getPurchasedBoardGamesByCategoryId,
            getItemStatuses: getItemStatuses,
            getTrackingCodes: getTrackingCodes,
            getGenres: getGenres
        };
    }]);