import Mock from 'mockjs'
import getToken from './getToken'
import login from './login'
import navlist from './navlist'
import getRoleList from './roleList'
import userList from './userList'
import buyGoodsList from './getBuyGoodsList'
import saleGoodsList from './getSaleGoodsList'
import conditionList from './conditionList'
import Vue from 'vue'


let data = [].concat(navlist, login, getToken,userList,getRoleList);

// data.forEach(function(res){
//     Mock.mock(res.path, res.data)
// });
Mock.mock(/\/user\/login/, login[0].data)
Mock.mock(/\/getBuyGoodsList/, buyGoodsList[0].data)
Mock.mock(/\/getSaleGoodsList/, saleGoodsList[0].data)
Mock.mock(/\/auth\/getNavList/, navlist[0].data)
Mock.mock(/\/getConditionList/, conditionList[0].data)
export default Mock
