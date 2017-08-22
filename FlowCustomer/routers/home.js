const Router = require('koa-router')
const path = require('path')
const upload = require('../utils/koa/upload')

let router = new Router()


let mysql = require('../config/mysql')

router
    //首页
    .get('/', async(ctx) => {
        await ctx.render('home/index', {})
    })

    //关于
    .get('about', async(ctx) => {
        await ctx.render('home/about', {})
    })

    //注册
    .get('register', async(ctx) => {
        await ctx.render('home/register', {})
    })

    //相应注册
    .post('register', async(ctx) => {
        ctx.body = ctx.request.body
    })

    //登录
    .get('login', async(ctx) => {
        await ctx.render('home/login', {})
    })

    //相应登录
    .post('login', async(ctx) => {
        ctx.body = ctx.request.body
    })

    //上传
    .get('upload', async(ctx) => {
        await ctx.render('home/upload', {})
    })

    //相应上传
    .post('upload', async(ctx) => {
        let result = await upload(ctx, {
            path: path.join(path.dirname(__dirname), 'upload')
        })
        ctx.body = result
    })

module.exports = router