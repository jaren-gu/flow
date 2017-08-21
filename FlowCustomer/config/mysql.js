const mysql = require('mysql')

const connection = mysql.createConnection({
    host:'192.168.0.100',
    user:'root',
    password:'123123',
    database:'koa'
})

let db = {
    query(sql){
        connection.query(sql,(err,result,fields)=>{

            if(err){
                db.error = err;
                console.log(err)
                return false;
            }

            console.log(result)
            console.log(fields)

            connection.release()
        })
    },

    error:''
}

module.exports = db;