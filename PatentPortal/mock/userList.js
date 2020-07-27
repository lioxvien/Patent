var data={
    "code": 200,
    "msg": "SUCCESS",
    "data": {
        "list": [{
            "id": 1,
            "name": "超级管理员",
            "account": "master",
            "pwd": "123456",
            "phone": "1234567890123",
            "mail": "12345@163.com",
            "status": 1,
            "deptName": "",
            "deptId": 0,
            "roleName": "管理员",
            "roleId": 1,
            "lastEditBy": "超级管理员",
            "lastEditTime": "2019-08-09 10:00:00",
            "createBy": "超级管理员",
            "createTime": "2019-08-09 10:00:00"
        }, {
            "id": 2,
            "name": "数据分析员",
            "account": "ice",
            "pwd": "123456",
            "phone": "1234522220123",
            "mail": "12345@163.com",
            "status": 1,
            "deptName": "产品部",
            "deptId": 1,
            "roleName": "系统分析员",
            "roleId": 2,
            "lastEditBy": "超级管理员",
            "lastEditTime": "2019-08-09 10:00:00",
            "createBy": "超级管理员",
            "createTime": "2019-08-09 10:00:00"
        }]
    }
}
export default [{
    path: '/user/list',
    data: data
}]
