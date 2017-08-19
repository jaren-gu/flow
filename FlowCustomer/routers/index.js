const Router = require('koa-router');

let router = new Router();

// 引入子路由
//首页，注册等
let home = require('./home');
router.use('/', home.routes(), home.allowedMethods())

//个人中心
let user = require('./user');
router.use('/user', user.routes(), user.allowedMethods())

//任务中心
let task = require('./task');
router.use('/task', task.routes(), task.allowedMethods())

//帮助中心
let help = require('./help');
router.use('/help', help.routes(), help.allowedMethods())

//管理中心
let admin = require('./admin');
router.use('/admin', admin.routes(), admin.allowedMethods())

module.exports = router;