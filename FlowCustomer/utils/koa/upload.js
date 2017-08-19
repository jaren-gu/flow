const inspect = require('util').inspect
const path = require('path')
const fs = require('fs')
const Busboy = require('busboy')

const savePath = path.join(__dirname, './upload')

/**
 * 创建目录
 * @param {string} 需要创建的目录 
 * @return {boolean} 创建结果
 */
function createDir(dirname) {
    if (fs.existsSync(dirname)) {
        return true
    } else {
        if (createDir(path.dirname(dirname))) {
            fs.mkdirSync(dirname)
            return true
        }
    }
}

/**
 * 获取文件扩展名
 * @param {string} filename 
 */
function getExtName(filename) {
    let nameList = filename.split('.')
    return nameList[nameList.length - 1]
}

/**
 * 
 * @param {Object} ctx koa上下文
 * @param {Object} options 上传参数
 */
function uploadFile(ctx, options) {
    let busboy = new Busboy({
        headers: ctx.req.headers
    })

    let result = {
        success: false,
        formData: {}
    }

    let fileType = options.fileType || 'common'
    let filePath = path.join(options.path, fileType)
    let mkdirResult = createDir(filePath)


    if (mkdirResult) {
        return new Promise((resolve, reject) => {
            console.log('文件上传中');

            busboy.on('file', (fieldname, file, filename, encoding, mime) => {
                console.log(`accept ${filename} from ${fieldname}`)

                let saveName = Math.random().toString(16).substr(2) + '.' + getExtName(filename)
                let uploadPath = path.join(filePath, saveName)

                // set save path
                file.pipe(fs.createWriteStream(uploadPath))

                // after resolve file data
                file.on('end', () => {
                    result.success = true
                    result.message = 'upload success'

                    console.log('文件上传成功')
                    resolve(result)
                })
            })

            busboy.on('field', (fieldname, val, fieldnameTruncated, valTruncated, encoding, mimetype) => {
                result.formData[fieldname] = inspect(val)
            })

            busboy.on('finish', function () {
                console.log('文件上传结束')
                resolve(result)
            })

            busboy.on('error', function (err) {
                console.log('文件上传出错')
                reject(result)
            })

            ctx.req.pipe(busboy)
        })
    } else {
        reject(result)
    }
}

module.exports = uploadFile