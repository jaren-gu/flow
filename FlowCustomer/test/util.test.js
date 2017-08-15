let util = require('../utils/utils');
let should = require('should');

describe('test/util.js', () => {
    /**
     * isObject
     */
    it('isObject("2") should be false', () => {
        util.isObject('2').should.equal(false);
    })

    it('isObject({}) should be true', () => {
        util.isObject({}).should.equal(true);
    })

    /**
     * isFunction
     */
    it('isFunction("2") should be false', () => {
        util.isFunction('2').should.equal(false);
    })

    it('isFunction(()=>{}) should be true', () => {
        util.isFunction(() => {}).should.equal(true);
    })

    /**
     * isArray
     */
    it('isArray("2") should be false', () => {
        util.isArray('2').should.equal(false);
    })

    it('isArray([]) should be true', () => {
        util.isArray([]).should.equal(true);
    })

    /**
     * isBool
     */
    it('isBool(2) should be false', () => {
        util.isBool(2).should.equal(false);
    })

    it('isBool(false) should be true', () => {
        util.isBool(false).should.equal(true);
    })

    /**
     * isString
     */
    it('isString(2) should be false', () => {
        util.isString(2).should.equal(false);
    })

    it('isString("2") should be true', () => {
        util.isString('2').should.equal(true);
    })

    /**
     * isNumber
     */
    it('isNumber(2) should be true', () => {
        util.isNumber(2).should.equal(true);
    })

    it('isNumber("2") should be false', () => {
        util.isNumber('2').should.equal(false);
    })

    /**
     * isEmpty
     */
    it('isEmpty([1]) should be false', () => {
        util.isEmpty([1]).should.equal(false);
    })
    
    it('isEmpty({1:1}) should be false', () => {
        util.isEmpty({1:1}).should.equal(false);
    })

    it('isEmpty("1") should be false', () => {
        util.isEmpty('1').should.equal(false);
    })

    it('isEmpty("") should be true', () => {
        util.isEmpty('').should.equal(true);
    })

    it('isEmpty({}) should be true', () => {
        util.isEmpty({}).should.equal(true);
    })

    it('isEmpty(undefined) should be true', () => {
        util.isEmpty(undefined).should.equal(true);
    })

    it('isEmpty(null) should be true', () => {
        util.isEmpty(null).should.equal(true);
    })

    it('isEmpty([]) should be true', () => {
        util.isEmpty([]).should.equal(true);
    })

})