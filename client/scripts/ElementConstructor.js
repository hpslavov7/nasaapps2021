var ElementConstructor = {
    data: ['Sofia', 'Varna', 'Burgas', 'Chirpan', 'StaraZagora'],
    constructMap: function (contentContainer,data) {
        this.constructContentStructure(contentContainer);
        MapFactory.createMap('map',data);
    },

    constructContentStructure: function (container) {
        var map = $('<div id="map" class="map">');
        var popup = $('<div id="popup" class="ol-popup">');
        var closeBtn = $('<div id="popup-closer" class="ol-popup-closer"></div>');
        var popupContent = $('<div id="popup-content"></div>');
        popup.append(closeBtn);
        popup.append(popupContent);
        $(container).append(map);
        $(container).append(popup);
    },

    constructSearchWidget: function (container) {
        var widgetRoot = $('<div class="ui-widget"></div>');
        var searchInput = $('<input id="searchLandSlide" placeholder="Search by area">');
        widgetRoot.append(searchInput);
        container.append(widgetRoot);
        searchInput.on("autocompleteselect", this.searchLandSlide);
        searchInput.autocomplete({ source: this.data });
    },

    searchLandSlide: function (event, ui) {
        debugger;
    },

    constructLandSlideInfo: function () {

    },

    constructLandSlideMap: function (id, info) {
        var contentMap = $('<div id="' + id + '" class="map"></div>');
        return contentMap;
    }


}