var contentPlaceHolder = $('#contentPlaceholder');
$('#reportLandslide').on('click', function () {
    contentPlaceHolder.empty();
    $.get('../fragments/reportFormsFragment.html', function (data) {
        contentPlaceHolder.css({ 'display': 'block' });
        contentPlaceHolder.append(data);


        //simpleReport
        $('#simpleReportForm').on('click', function () {
            contentPlaceHolder.empty();
            $.get('../fragments/reportLandslideFragment.html', function (data) {
                contentPlaceHolder.empty();
                contentPlaceHolder.append(data);
                MapFactory.createMap('reportLandslidemap', 25.68, 42.42);

                $('#reportLandSlide').submit(simpleReportSubmit);
            })
        });

        //governmentReport
        $('#governmentReportForm').on('click', function () {
            contentPlaceHolder.empty();
            $.get('../fragments/governmentLandslideFragment.html', function (data) {
                contentPlaceHolder.empty();
                contentPlaceHolder.append(data);
                MapFactory.createMap('reportLandslidemap', 25.68, 42.42);

                $('#governmentReport').submit(governmentReportSubmit);

            });
        });


        //precipitationReport
        $('#precipitationReport').on('click', function () {
            contentPlaceHolder.empty();
            $.get('../fragments/precipitationFragment.html', function (data) {
                contentPlaceHolder.empty();
                contentPlaceHolder.append(data);
                MapFactory.createMap('reportLandslidemap', 25.68, 42.42);

                $('#precipitationReport').submit(precipitationReportSubmit);

            })
        });
    })
});


function simpleReportSubmit(e) {
    e.preventDefault();
    var payload = parseForm('#reportLandSlide');
    RestUtil.postSimpleReport(payload);
}


function governmentReportSubmit(e) {
    e.preventDefault();
    var payload = parseForm('#governmentReport');
    RestUtil.postSimpleReport(payload);
}


function precipitationReportSubmit(e) {
    e.preventDefault();
    var payload = parseForm('#precipitationReport');
    RestUtil.postSimpleReport(payload);
}


function parseForm(formId) {
    debugger;
    var fields = $(formId + ' :input');
    var values = {};

    fields.each(function () {
        values[this.name] = $(this).val();
    });

    return values;
}




