var RestUtil = {
    getLandslides: function (complete, error) {
        this.executeRequest('GET', 'http://localhost:26252/weatherforecast', {}, complete, error)
    },
    postSimpleReport: function (complete, error, data) {
        this.executeRequest('POST', '', data, complete, error);
    },
    postGovernmentReport: function (complete, error, data) {
        this.executeRequest('POST', '', data, complete, error);
    },
    postPrecipitationReport: function (complete, error, data) {
        this.executeRequest('POST', '', data, complete, error);
    },
    executeRequest: function (method, url, data, complete, error) {
        $.ajax({
            method: method,
            url: url,
            data: data,
            complete: complete,
            error: error
        });
    }
}