$(function () {
    //toastr.options = {
    //    "closeButton": false, //是否显示关闭按钮
    //    "debug": false, //是否使用debug模式    
    //    "positionClass": "toast-top-center",//弹出窗的位置        
    //    "showDuration": "300",//显示的动画时间        
    //    "hideDuration": "1000",//消失的动画时间        
    //    "timeOut": "3000", //展现时间        
    //    "extendedTimeOut": "1000",//加长展示时间        
    //    "showEasing": "swing",//显示时的动画缓冲方式        
    //    "hideEasing": "linear",//消失时的动画缓冲方式        
    //    "showMethod": "fadeIn",//显示时的动画方式        
    //    "hideMethod": "fadeOut" //消失时的动画方式        
    //}

    $("#txtMobile").change(function () {
        if ($("#txtMobile").val() == "") {
            layer.msg("请输入手机号");
            return;
        } else {
            if (!(/^(((13[0-9]{1})|159|153|155|198|176|175|166|(18[0-9]{1})|(15[0-9]{1}))+\d{8})$/.test($("#txtMobile").val()))) {
                layer.msg("请输入正确的手机号");
                return;
            }
        }
    })
})

//验证码
function ChangeYZM() {
    $("#ImgYZM").attr('src', "/Home/IdentifyCode?m=" + Math.random());
}

//注册
function checkInfo() {
    if ($("#txtMobile").val() == "") {
        $("#txtMobile").focus();
        return;
    } else {
        if (!(/^(((13[0-9]{1})|159|153|155|198|176|175|166|(18[0-9]{1})|(15[0-9]{1}))+\d{8})$/.test($("#txtMobile").val()))) {
            layer.msg("请输入正确的手机号");
            $("#txtMobile").focus();
            return;
        }
    }

    if ($("#txtPWD").val() == "") {
        $("#txtPWD").focus();
        return;
    } else {
        if (!(/^[a-zA-Z\d_]{6,}$/.test($("#txtPWD").val()))) {
            layer.msg("密码由数字、大小写字母及下划线组成，不少于6位");
            $("#txtPWD").focus();
            return;
        }
    }

    if ($("#txtAgainPWD").val() == "") {
        $("#txtAgainPWD").focus();
        return;
    } else {
        if ($("#txtPWD").val() != $("#txtAgainPWD").val()) {
            layer.msg("两次密码输入不一致");
            $("#txtAgainPWD").focus();
            return;
        }
    }

    if ($("#txtYZM").val() == "") {
        $("#txtYZM").focus();
        return;
    }

    if ($("#txtMobileYZM").val() == "") {
        $("#txtMobileYZM").focus();
        return;
    }

    if ($("#txtInviteCode").val() == "") {
        $("#txtInviteCode").focus();
        return;
    }

    var userData = {
        "USERNAME": $("#txtMobile").val(),
        "MOBILE": $("#txtMobile").val(),
        "PASSWORD": $("#txtPWD").val(),
        "InviteCode": $("#txtInviteCode").val(),
        "YZM": $("#txtYZM").val()
    }   

    $.ajax({
        type: "POST",
        url: "/Home/RegisterInfo",
        data: userData,
        success: function (code) {
            if (code == "0") {
                layer.alert('注册成功，请登录',{
                    closeBtn: 0,
                }, function () {
                    window.location.href = "/Home/Login";
                })
            } else if (code == "1") {
                layer.alert("注册失败，请重试");
            } else if (code == "2") {
                layer.alert("验证码错误，请重新输入");
            } else if (code == "3") {
                layer.alert("邀请码不存在，请重新输入");
            } else if (code == "4") {
                layer.alert("该手机号已注册，请登录");
            }
        },
        error: function () {//请求失败处理函数  
            layer.msg("请求失败，请重试");
        },
    })
}



