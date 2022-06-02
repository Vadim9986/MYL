// $('.block_item').click(function (event) {
//     if ($(this).hasClass('_active__photo')) {
//         $('.block_item').removeClass('_active__photo')
//     }
//     else {
//         $('.block_item').removeClass('_active__photo')
//         $(this).addClass('_active__photo')
//     }
// });

$('.block_item, .view__photo').on('click', function () {
    //$('body').toggleClass('_lock_scroll')
    $('.view__photo').toggleClass('_active__view__photo')
    $('.view__photo__content img').attr('src', $(this).children('img').attr('src'))
});