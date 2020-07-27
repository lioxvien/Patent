var data = {
    'login': 'true',
    'captcha': "@image('100x40', '#FFFFFF', '@word')",
    'message': '这里是登录提交后错误提示信息@increment',
    'uid': '@id',
    'name': '@cname',
    'token': '@guid',
    'code':0
};

export default [{
    path: 'user/login',
    data: data
}]
