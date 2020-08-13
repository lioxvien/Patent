// var data ={
//     "data": [
//         {
//             "name": "首页",
//             "id":0,
//             "path": "/home",
//             "sort":0,
//         },
//         {
//             "name": "订单",
//             "id":4,
//             "sort":4,
//             "child": [{
//                     "path": "/orderManagement",
//                     "name": "订单管理",
//                     "id":41,
//                     "sort":41
//                 },
//                 {
//                     "path": "/orderInvoice",
//                     "name": "发票",
//                     "id":42,
//                     "sort":42
//             }]
//     },
//         {
//             "name": "消息",
//             "path": "/newsManagement",
//             "id":5,
//             "sort":5,
//         },
//         {
//             "name": "工作组",
//             "path": "/workgroup",
//             "id":8,
//             "sort":8,
//         },
//         {
//             "path": "/equipmentInfo",
//             "name": "设备管理",
//             "id":9,
//             "sort":9,
//         },
//         {
//             "path": "/planeReport",
//             "name": "报表",
//             "id":7,
//             "sort":7,
//         },
//         {
//             "name": "系统管理",
//             "id":6,
//             "sort":6,
//             "child": [{
//                 "path": "/roleManagement",
//                 "name": "角色管理",
//                 "id": 61,
//                 "sort":61
//             },
//                 {
//                     "path": "/authoritytManagement",
//                     "name": "权限管理",
//                     "id": 62,
//                     "sort":62
//                 },
//                 {
//                     "path": "/dicManagement",
//                     "name": "字典管理",
//                     "id": 63,
//                     "sort":63
//                 }]
//         },
//         {
//             "name": "日志管理",
//             "id":10,
//             "sort":10,
//             "child": [{
//                 "path": "/loginLog",
//                 "name": "用户登录日志",
//                 "id":101,
//                 "sort": 4
//             },
//             {
//                 "path": "/operatingLog",
//                 "name": "用户操作日志",
//                 "id":102,
//                 "sort": 4
//             }]
//         },
//     ]
// };
var data ={
    "data": [
        {
            "name": "首页",
            "id":0,
            "path": "/home",
            "sort":0,
        },
        {
            "path": "/user",
            "name": "用户管理",
            "id":1,
            "sort":1,
        },
        {
            "name": "求购商品",
            "path": "/buy",
            "id":2,
            "sort":2,
        },
        {
            "name": "出售商品",
            "path": "/sale",
            "id":3,
            "sort":3,
        },
        {
            "path": "/complaintReview",
            "name": "投诉审核",
            "id":4,
            "sort":4,
        }, {
            "path": "/exchange",
            "name": "兑换记录",
            "id":5,
            "sort":5,
        }
    ]
};
export default [{
    path: '/auth/getNavList',
    data: data
}]
