var RestUtil = {
    getLandslides: function (complete, error) {
        this.executeRequest('GET', 'https://api20211003142652.azurewebsites.net/landslide', {}, complete, error)
    },
    postSimpleReport: function (data, complete, error) {
        this.executeRequest('POST', 'https://api20211003142652.azurewebsites.net/landslideReport', data, complete, error);
    },
    postGovernmentReport: function (data,complete, error) {
        this.executeRequest('POST', 'https://api20211003142652.azurewebsites.net/governmentReport', data, complete, error);
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