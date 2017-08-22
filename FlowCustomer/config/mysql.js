const mysql = require('mysql')

const pool = mysql.createPool({
    host: '192.168.0.100',
    user: 'root',
    password: '123123',
    database: 'koa'
})

let db = {
    query(sql, values) {
        return new Promise((resolve, reject) => {
            pool.getConnection(function (err, connection) {

                if (err) {
                    reject(err)
                }
                connection.connect()

                connection.query(sql, values, (error, results, fields) => {

                    if (error) {
                        reject(err)
                    } else {
                        resolve(results)
                    }
                })

                connection.release()
            })
        })
    },

    error: ''
}

module.exports = db