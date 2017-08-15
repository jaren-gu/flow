let util = require('../utils/utils');
let should = require('should');

describe('test/util.js', () => {
    /**
     * isNumber 测试
     */
    it('isNumber(2) should be true', () => {
        util.isNumber(2).should.equal(true);
    })

    it('isNumber("2") should be false', () => {
            util.isNumber('2').should.equal(false);
    })
    
})