const Router = require('koa-router');

let router = new Router();

// 引入子路由
let home = require('./home');
router.use('/', home.routes(), home.allowedMethods())

module.exports = router;