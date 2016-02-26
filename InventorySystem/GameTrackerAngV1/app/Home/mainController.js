
app.controller('mainController',
    ["$scope",
    function mainController($scope) {
        $scope.myInterval = 5000;
        var slides = [];        
        slides.push({
            image: '\\app\\Home\\Images\\GW2_GuardianWallpaper02-1920x1080.jpg',
            text: 'Guild Wars'
        });
        
        slides.push({
            image: '\\app\\Home\\Images\\jokerAC.jpg',
            text: 'Batman'
        });
        
        slides.push({
            image: '\\app\\Home\\Images\\LATEST-WALLPAPER_wide_HeroArt_bioshock_InF.jpg',
            text: 'BioShock Infinite'
        });
        
        slides.push({
            image: '\\app\\Home\\Images\\Mordesh1280x1024ws.jpg',
            text: 'Wild Star'
        });
        
        slides.push({
            image: '\\app\\Home\\Images\\skyrim_environment_1920x1200.jpg',
            text: 'Skyrim'
        });
        
        slides.push({
            image: '\\app\\Home\\Images\\wall026-1440x900 - HOS.jpg',
            text: 'Star Craft II'
        });
        
        slides.push({
            image: '\\app\\Home\\Images\\witcher3.jpg',
            text: 'Witcher 3'
        });
        $scope.slides = slides;
    }]);

