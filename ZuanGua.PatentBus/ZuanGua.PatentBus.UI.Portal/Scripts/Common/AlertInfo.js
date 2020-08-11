function ShowErr(msg) {
    $.alert({
        title: '提示',
        content: msg,
        confirmButton: '确定',
        confirmButtonClass: 'btn-warning',
        confirm: function () {

        }
    });
}

function ShowErrBack(msg, url) {
    $.alert({
        title: '提示',
        content: msg,
        confirmButton: '确定',
        confirmButtonClass: 'btn-warning',
        confirm: function () {
            window.location.href = url;
        }
    });
}

function ShowErrAllBack(msg, url) {
    $.alert({
        title: '提示',
        content: msg,
        confirmButton: '确定',
        confirmButtonClass: 'btn-warning',
        confirm: function () {
            window.location.href = url;
        },
        cancel: function () {
            window.location.href = url;
        }
    });
}

function ShowSuccess(msg) {
    $.alert({
        title: '提示',
        content: msg,
        confirmButton: '确定',
        confirmButtonClass: 'btn-success',
        confirm: function () {
        }
    });
}

function ShowSuccessBack(msg, url) {
    $.alert({
        title: '提示',
        content: msg,
        confirmButton: '确定',
        confirmButtonClass: 'btn-success',
        confirm: function () {
            window.location.href = url;
        }
    });
}

function ShowSuccessAllBack(msg, url) {
    $.alert({
        title: '提示',
        content: msg,
        confirmButton: '确定',
        confirmButtonClass: 'btn-success',
        confirm: function () {
            window.location.href = url;
        },
        cancel: function () {
            window.location.href = url;
        }
    });
}

function ShowSuccessBackTop(msg, url) {
    $.alert({
        title: '提示',
        content: msg,
        confirmButton: '确定',
        confirmButtonClass: 'btn-success',
        confirm: function () {
            window.top.location.href = url;
        }
    });
}

function ShowSuccessClose(msg) {
    $.alert({
        title: '提示',
        content: msg,
        confirmButton: '确定',
        confirmButtonClass: 'btn-success',
        confirm: function () {
            window.close();
        }
    });
}
