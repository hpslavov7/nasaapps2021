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
        zoom: 0
      })
    });

    map.on('singleclick', function (evt) {
      var coordinate = evt.coordinate;
      var hdms = ol.coordinate.toStringHDMS(ol.proj.toLonLat(coordinate));
      var marks = MapFactory.landslides;

      var feature = map.forEachFeatureAtPixel(evt.pixel, function (feature) {
        return feature;
      });

      var featureData = marks.filter(function (mark) {
        if (mark) {
          return feature.id === mark.id;
        }
      });


      if (feature) {
        $('#popup-content')[0].innerHTML = MapFactory.constructLandSlideData(featureData[0]);
        overlay.setPosition(coordinate);
      }
    });


    $('#popup-closer').on('click', function () {
      overlay.setPosition(undefined);
      return false;
    });

    $('#' + container).data('map', map);
    return map;
  },

  createSingleMap: function (container, longitude, latitude) {
    var overlay = this.createOverlay();

    var vectorLayer = new ol.layer.Vector({
      source: new ol.source.Vector({
        features: this.mapMarkers([])
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
        center: ol.proj.fromLonLat([longitude, latitude]),
        zoom: 7
      })
    });

    return map;
  },

  constructLandSlideData: function (data) {
    var header = '<p>Landslide area: ' + data.address + '</p>'
    var date = '<p>Landslide area: ' + data.date + '</p>'
    var landslideLongitude = '<p>Longitude:</p><code>' + data.longitudeCenter + '</code>';
    var landslideLatitude = '<p>Latitude:</p><code>' + data.latitudeCenter + '</code>';
    var steepness = '<p>Slope steepness:</p><code>' + data.slopeSteepness + '</code>';
    var materialType = '<p>Last landslide material type:</p><code>' + data.landslideMaterialType + '</code>';
    var riskLevel = '<p>General Risk level:</p><h3>' + data.generalRiskLevel + '</h3>';
    var result = header + date + landslideLongitude + landslideLatitude + steepness + materialType + riskLevel;
    return result;
  },

  mapMarkers: function (data) {
    var response = data.responseJSON;
    var resultMarkers = [];
    if (!response) {
      return resultMarkers;
    }

    for (var index = 0; index < response.length; index++) {
      var resultLandSlide = {};
      var currentLandslide = response[index];

      resultLandSlide = currentLandslide
      resultLandSlide.marker = this.createMarker(resultLandSlide.longitudeCenter, resultLandSlide.latitudeCenter);
      resultLandSlide.marker.id = index;
      resultLandSlide.id = index;

      resultMarkers.push(resultLandSlide.marker);
      this.landslides.push(resultLandSlide);
    }

    return resultMarkers;
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

  landslides: [],

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
