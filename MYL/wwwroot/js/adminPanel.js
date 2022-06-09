$(document).ready(function () {
    searchLove();
});

function searchLove() {
    var formData = new FormData();
    let gender = $('.search__looking__gender').val()
    let ageStart = $('.age_start').val()
    let ageEnd = $('.age_end').val()
    let country = $('.search__country').val()
    let sort = $('.select_regist').val()
    let search = {
        Gender: gender,
        AgeStart: ageStart,
        AgeEnd: ageEnd,
        Country: country,
        Sort: sort
    }
    formData.append("Gender", gender);
    formData.append("AgeStart", ageStart);
    formData.append("AgeEnd", ageEnd);
    formData.append("Country", country);
    formData.append("Sort", sort)

    $.ajax({
        url: "../AdminPanel/GetQuestionary",
        type: 'POST',
        data: {
            search: search
        },
        success: function (response) {
            $('.row').html(response);

        }
    });
}

function Delete(id) {
    $.ajax({
        url: "../AdminPanel/DeleteFromWebSite",
        type: 'POST',
        data: {
            id: id
        },
        success: function (response) {
            searchLove();
        }
    });
}