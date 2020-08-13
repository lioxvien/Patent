var data={
    "code": 200,
    "msg": "SUCCESS",
    "data": {
        totalElements:200,
        "list": [
            {
            "id": 1,
            "phone": "1234567890123",
            "allSale": 300,
            "sale": 100,
            "saleRate": '33.33%',
            "allBuy": parseInt(Math.random()*200),
            "createTime": "2019-08-09 10:00:00"
        }, {
            "id": 1,
            "phone": "1234567890123",
            "allSale": parseInt(Math.random()*200)+200,
            "sale": parseInt(Math.random()*200),
            "saleRate": '33.33%',
            "allBuy": parseInt(Math.random()*200),
            "createTime": "2019-08-09 10:00:00"
        }, {
            "id": 1,
            "phone": "1234567890123",
            "allSale": parseInt(Math.random()*200)+200,
            "sale": parseInt(Math.random()*200),
            "saleRate": '33.33%',
            "allBuy": parseInt(Math.random()*200),
            "createTime": "2019-08-09 10:00:00"
        }, {
            "id": 1,
            "phone": "1234567890123",
            "allSale": parseInt(Math.random()*200)+200,
            "sale": parseInt(Math.random()*200),
            "saleRate": '33.33%',
            "allBuy": parseInt(Math.random()*200),
            "createTime": "2019-08-09 10:00:00"
        },  {
            "id": 1,
            "phone": "1234567890123",
            "allSale": parseInt(Math.random()*200)+200,
            "sale": parseInt(Math.random()*200),
            "saleRate": '33.33%',
            "allBuy": parseInt(Math.random()*200),
            "createTime": "2019-08-09 10:00:00"
        },  {
            "id": 1,
            "phone": "1234567890123",
            "allSale": parseInt(Math.random()*200)+200,
            "sale": parseInt(Math.random()*200),
            "saleRate": '33.33%',
            "allBuy": parseInt(Math.random()*200),
            "createTime": "2019-08-09 10:00:00"
        }]
    }
}
export default [{
    path: '/getUserGoodsList',
    data: data
}]
