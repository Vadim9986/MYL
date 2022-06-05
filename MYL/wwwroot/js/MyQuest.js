$('.block_item, .view__photo').on('click', function () {
    //$('body').toggleClass('_lock_scroll')
    $('.view__photo').toggleClass('_active__view__photo')
    $('.view__photo__content img').attr('src', $(this).children('img').attr('src'))
});

function AddToFavourite(id) {
    console.log(id);
    var formData = new FormData();
    formData.append("id", id);

    $.ajax({
        url: "/MyQuestionary/AddToFavourite",
        type: 'POST',
        cache: false,
        contentType: false,
        processData: false,
        data: formData,
        success: function (response) {
            console.log(response)
            if (!response) {
                alert('Вы не авторизованы!')
            }
        }
    });
}