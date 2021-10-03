var contentPlaceHolder = $('#contentPlaceholder');
$('#activeLandslide').on('click', function () {
    contentPlaceHolder.empty();
    RestUtil.getLandslides(dispatchContent,handleError);
});


function dispatchContent(data) {
    contentPlaceHolder.css({ 'display': 'block' });
    //parsing of json object from backend!
    ElementConstructor.constructMap(contentPlaceHolder,[{},{},{}]);
    console.log(data.responseJSON);
}

function handleError(data) {
    console.log(data);
}