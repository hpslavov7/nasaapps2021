var RestUtil = {
    getLandslides: function (complete, error) {
        this.executeRequest('GET', 'http://localhost:26252/landslide', {}, complete, error)
    },
    postSimpleReport: function (data, complete, error) {
        this.executeRequest('POST', 'http://localhost:26252/landslideReport', data, complete, error);
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
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            data: JSON.stringify(data),
            complete: complete,
            error: error
        });
    }
}