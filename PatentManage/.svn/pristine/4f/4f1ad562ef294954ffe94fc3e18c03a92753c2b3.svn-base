import Mock from 'mockjs'
import getToken from './getToken'
import login from './login'
import navlist from './navlist'
import getRoleList from './roleList'
import userList from './userList'
import Vue from 'vue'


let data = [].concat(navlist, login, getToken,userList,getRoleList);

console.log('data',data)
// data.forEach(function(res){
//     Mock.mock(res.path, res.data)
// });
Mock.mock(/\/user\/login/, login[0].data)
Mock.mock(/\/auth\/getNavList/, navlist[0].data)
export default Mock
