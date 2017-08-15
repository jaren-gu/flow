const fs = require('fs');

let fileReader = async (filePath,next) => {
    return new Promise(( resolve, reject ) => {
        fs.readFile(filePath, "binary", ( err, data ) => {
          if ( err ) {
            reject( err )
          } else {
            resolve( data )
          }
        })
      })
}

module.exports = fileReader;