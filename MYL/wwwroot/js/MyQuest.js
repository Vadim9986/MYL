$('.block_item').click(function (event) {
    $('.block_item').removeClass('_active__photo')
    $(this).toggleClass('_active__photo')
    console.log(event);
});