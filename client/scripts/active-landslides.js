var contentPlaceHolder = $('#contentPlaceholder');
$('#activeLandslide').on('click', function () {
    contentPlaceHolder.empty();
    RestUtil.getLandslides(dispatchContent,handleError);
});


function dispatchContent(data) {
    contentPlaceHolder.css({ 'display': 'block' });
    ElementConstructor.constructMap(contentPlaceHolder,data);
    console.log(data.responseJSON);
}

function handleError(data) {
    console.log(data);
}