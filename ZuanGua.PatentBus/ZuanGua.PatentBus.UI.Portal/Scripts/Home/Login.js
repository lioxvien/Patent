//验证码
function ChangeYZM() {
    $("#ImgYZM").attr('src', "/Home/IdentifyCode?m=" + Math.random());
}

function checkInfo() {
    if ($("#txtUserName").val() == "") {
        $("#txtUserName").focus();
        return;
    }
    if ($("#txtPWD").val() == "") {
        $("#txtPWD").focus();
        return;
    }
    if ($("#txtYZM").val() == "") {
        $("#txtYZM").focus();
        return;
    }

    var userData = {
        "MOBILE": $("#txtUserName").val(),
        "PASSWORD": $("#txtPWD").val(),
        "YZM": $("#txtYZM").val()
    }

    $.ajax({
        type: "POST",
        url: "/Home/Login",
        data: userData,
        success: function (code) {
            if (code == "0") {
                window.location.href = "/Home/Index";
            } else if (code == "1") {
                layer.alert("登录失败，请重试");
            } else if (code == "2") {
                layer.alert("验证码错误，请重新输入");
            } else if (code == "3") {
                layer.alert("密码不正确，请输入正确密码");
            } else if (code == "4") {
                layer.alert("该手机号未注册，请注册后登录");
            }
        },
        error: function () {//请求失败处理函数  
            layer.msg("请求失败，请重试");
        },
    })
}
