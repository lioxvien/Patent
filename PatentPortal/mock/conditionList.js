var data ={
    code:0,
    data: [{
        title: '商品类型',
        options: ['不限','发明专利','实用新型专利','商标']
    },{
        title: '商品领域',
        options: ['不限','求购领域','出售领域', ]
    },{
        title: '商品状态',
        options: ['不限','授权下证书','授权未交易']
    },{
        title: '求购价格',
        options: ['不限','1K以下','1K-5K','5K-10K','10K-15K','15K-20K','20K-25K', '25K-30K','30k以上']
    },{
        title: '交易状态',
        options: ['不限','求购中','求购成功',]
    }]
};

export default [{
    path: '/getConditionList',
    data: data
}]
