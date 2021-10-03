var MapFactory = {

  createMap: function (container, markersData) {
    var overlay = this.createOverlay();

    var vectorLayer = new ol.layer.Vector({
      source: new ol.source.Vector({
        features: this.mapMarkers(markersData)
      }),
      style: new ol.style.Style({
        image: new ol.style.Icon({
          anchor: [0.5, 46],
          anchorXUnits: 'fraction',
          anchorYUnits: 'pixels',
          src: '../resources/image.png'
        }),
        size: 20
      })
    });

    var basicRasterLayer = new ol.layer.Tile({
      source: new ol.source.OSM()
    });

    var map = new ol.Map({
      target: container,
      layers: [
        basicRasterLayer,
        vectorLayer
      ],
      overlays: [overlay],
      view: new ol.View({
        center: ol.proj.fromLonLat([24, 42]),
        zoom: 7
      })
    });

    map.on('singleclick', function (evt) {
      var coordinate = evt.coordinate;
      var hdms = ol.coordinate.toStringHDMS(ol.proj.toLonLat(coordinate));

      var feature = map.forEachFeatureAtPixel(evt.pixel, function (feature) {
        return feature;
      });


      if (feature) {
        $('#popup-content')[0].innerHTML = '<p>Landslide information:</p><code>' + hdms + '</code>';
        overlay.setPosition(coordinate);
      }
    });


    $('#popup-closer').on('click', function () {
      overlay.setPosition(undefined);
      return false;
    });

    return map;
  },

  mapMarkers: function (data) {
    result = [];

    for (var index = 0; index < data.length; index++) {
      var lat = Math.random(30, 100);
      var lon = Math.random(30, 100);
      var marker = this.createMarker(lat, lon);
      result.push(marker);
    }

    return result;
  },

  createOverlay: function () {
    return new ol.Overlay({
      element: $('#popup')[0],
      autoPan: true,
      autoPanAnimation: {
        duration: 250,
      },
    });
  },

  createMarker: function (longitute, latitute) {
    var marker = new ol.Feature({
      geometry: new ol.geom.Point(ol.proj.fromLonLat([longitute, latitute])),
      name: 'Test'
    });
    this.mapFeatures(marker);
    return marker;

  },

  getLandSlideMarker: function () {

  },

  features: [],

  getFeatures: function () {
    var features = this.features.filter(function (feature) {
      return feature !== undefined;
    });

    return features;
  },

  mapFeatures: function (feature) {
    this.features[this.features.length + 1] = feature;
  },

  cleanMap: function (selector) {
    $(selector).remove();
  }

};
