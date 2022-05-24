$(".fa-eye").click(function () {
    let type = $("#pwd").attr("type") == "text" ? "password" : "text";
    $("#pwd").attr("type", type);
});
