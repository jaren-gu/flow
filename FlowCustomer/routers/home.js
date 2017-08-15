const Router = require('koa-router');

let fileReader = require('../utils/fileReader');

let router = new Router();

let view = async (url,next) => {
    // 默认读取 index 
    if(url.length === 1){
        url = '/index';
    }

    let filePath = `./view/home${url}.html`;
    let html = await fileReader(filePath);
    return html;
}


router.get('/', async(ctx) => {
    console.log(ctx.request.url);
    let html = await view(ctx.request.url);
    ctx.body = html;
})

.get('login', async(ctx) => {
    ctx.body = 'login';
})

.get('404', async(ctx) => {
    ctx.body = '404 page!'
})

.get('helloworld', async(ctx) => {
    ctx.body = 'helloworld page!'
})

module.exports = router;