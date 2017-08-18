const Router = require('koa-router')
const path = require('path')
let upload = require('./file')

let router = new Router()

router
    .get('/', async(ctx) => {
        await ctx.render('home/index', {})
    })

    .get('login', async(ctx) => {
        await ctx.render('home/login', {})
    })

    .post('login', async(ctx) => {
        ctx.body = ctx.request.body
    })

    .get('upload', async(ctx) => {
        await ctx.render('home/upload', {})
    })

    .post('upload', async(ctx) => {
        let result = await upload(ctx, {
            path: path.join( path.dirname(__dirname), 'upload')
        })
        ctx.body = result
    })

module.exports = router