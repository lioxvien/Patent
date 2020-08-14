import Mock from 'mockjs'
import getToken from './getToken'
import login from './login'
import navlist from './navlist'
import getRoleList from './roleList'
import userList from './userList'
import buyGoodsList from './getBuyGoodsList'
import myBuyGoodsList from './getMyBuyGoodsList'
import saleGoodsList from './getSaleGoodsList'
import mySaleGoodsList from './getMySaleGoodsList'
import conditionList from './conditionList'
import Vue from 'vue'


let data = [].concat(navlist, login, getToken,userList,getRoleList);

// data.forEach(function(res){
//     Mock.mock(res.path, res.data)
// });
Mock.mock(/\/user\/login/, login[0].data)
Mock.mock(/\/getAllBuyGoodsList/, buyGoodsList[0].data)
Mock.mock(/\/getMyBuyGoodsList/, myBuyGoodsList[0].data)
Mock.mock(/\/getAllSaleGoodsList/, saleGoodsList[0].data)
Mock.mock(/\/getMySaleGoodsList/, mySaleGoodsList[0].data)
Mock.mock(/\/auth\/getNavList/, navlist[0].data)
Mock.mock(/\/getConditionList/, conditionList[0].data)
export default Mock
