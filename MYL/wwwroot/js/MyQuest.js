$('.block_item').click(function (event) {
    if ($(this).hasClass('_active__photo')) {
        $('.block_item').removeClass('_active__photo')
    }
    else {
        $('.block_item').removeClass('_active__photo')
        $(this).addClass('_active__photo')
    }
});