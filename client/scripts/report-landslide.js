var contentPlaceHolder = $('#contentPlaceholder');
$('#reportLandslide').on('click', function () {
    contentPlaceHolder.empty();
    $.get('../fragments/reportFormsFragment.html', function (data) {
        contentPlaceHolder.css({ 'display': 'block' });
        contentPlaceHolder.append(data);

        $('#simpleReportForm').on('click', function () {
            contentPlaceHolder.empty();
            $.get('../fragments/reportLandslideFragment.html', function (data) {
                contentPlaceHolder.empty();
                contentPlaceHolder.append(data);
                MapFactory.createMap('reportLandslidemap', 25.68, 42.42);
            })
        });


        $('#governmentReportForm').on('click', function () {
            contentPlaceHolder.empty();
            $.get('../fragments/governmentLandslideFragment.html', function (data) {
                contentPlaceHolder.empty();
                contentPlaceHolder.append(data);
                MapFactory.createMap('reportLandslidemap', 25.68, 42.42);
            })
        });
    })
});





