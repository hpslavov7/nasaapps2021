var contentPlaceHolder = $('#contentPlaceholder');
$('#activeLandslide').on('click', function () {
    contentPlaceHolder.empty();
    $.ajax('https://jsonplaceholder.typicode.com/todos', {
        complete: dispatchContent
    });
});


function dispatchContent(data) {
    contentPlaceHolder.css({ 'display': 'block' });
    ElementConstructor.constructMap(contentPlaceHolder);
    console.log(data.responseJSON);
}