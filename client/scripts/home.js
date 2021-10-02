$('.tile').on('click', function (evt) {
    $('#content').css({'padding': '6vh 0vh 0vh 0vh'});
    $('.tile').addClass('low-scale-tile');
    $('.tile-text').addClass('high-scale-tile-text');
});


// reset view
$('#headerTitle').on('click', function (evt) {
    $('#content').animate({
        'padding': '25vh 0vh 0vh 0vh',
    }, 700);
    $('.tile').removeClass('low-scale-tile');
    $('.tile-text').removeClass('high-scale-tile-text');
    $('#contentPlaceholder').css({ 'display': 'none' });
    $('#contentPlaceholder').empty();

});