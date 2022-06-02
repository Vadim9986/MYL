$(".pas").click(function () {
    let type = $("#pwd").attr("type") == "text" ? "password" : "text";
    $("#pwd").attr("type", type);
    console.log("hfhf")
});

$(".pas-c").click(function () {
    let type = $("#pwd_cnf").attr("type") == "text" ? "password" : "text";
    $("#pwd_cnf").attr("type", type);
    console.log("hfhf")
});
