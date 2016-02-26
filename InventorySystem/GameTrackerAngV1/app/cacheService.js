

app.factory('cacheService',
['$cacheFactory',
    function ($cacheFactory) {
        var myCache = $cacheFactory('myData');
        
        //key used for getting the categories
        var categoryKey = "categoryKey";
      
        function getVersion(key) {
            var cacheItem = myCache.get(key);
            if (cacheItem) {
                return cacheItem;
            } else {
                return 1;  //pass sometihng else back?  - or should this be genric? or throw an exception?
            }
        }
        
        function setVersion(key, value) {
            myCache.put(key, value);
        }

        return {
            //myCache: myCache,
            getVersion: getVersion,
            setVersion: setVersion,
            categoryKey: categoryKey
        };
    }]);





