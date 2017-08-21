const Router = require('koa-router')
const path = require('path')

let router = new Router();
let routerPath = path.join(__dirname,'../routers')

//todo 实现自动加载路由

// 引入子路由
//首页，注册等
let home = require(routerPath + '/home')
router.use('/', home.routes(), home.allowedMethods())

//个人中心
let user = require(routerPath + '/user')
router.use('/user', user.routes(), user.allowedMethods())

//任务中心
let task = require(routerPath + '/task')
router.use('/task', task.routes(), task.allowedMethods())

//帮助中心
let help = require(routerPath + '/help')
router.use('/help', help.routes(), help.allowedMethods())

//管理中心
let admin = require(routerPath + '/admin');
router.use('/admin', admin.routes(), admin.allowedMethods())

module.exports = router;