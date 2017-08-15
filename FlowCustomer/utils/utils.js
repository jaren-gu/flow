'use strict';

var toString = Object.prototype.toString;

/**
 * 判断传入值是否对象
 * @param {object} obj 
 */
function isObject(obj) {
    return obj !== null && typeof obj === 'object';
}

/**
 * 判断对象是否数组
 * @param {object} obj 
 */
function isArray(obj) {
    return toString.call(obj) === '[object Array]';
}

/**
 * 判断对象是否函数
 * @param {object} obj 
 */
function isFunction(obj){
    return toString.call(obj) === '[object Function]';
}

/**
 * 判断对象是否布尔值
 * @param {object} obj 
 */
function isBool(obj){
    return toString.call(obj) === '[object Boolean]';
}

/**
 * 判断对象是否字符串
 * @param {Object} obj 
 */
function isString(obj) {
    return typeof obj === 'string';
}

/**
 * 判断对象是否数值
 * @param {object} obj 
 */
function isNumber(obj) {
    return typeof obj === 'number';
}

/**
 * 检查传入值是否为空
 * @param {object|string} obj 
 */
function isEmpty(obj){
    if (obj === null)
        return true;

    if (typeof obj === 'undefined')
        return true;

    if(typeof obj === 'object')
        return Object.keys(obj).length === 0;
    
    if (typeof obj === 'string')
        return obj.length === 0;
}

module.exports = {
    isObject,
    isFunction,
    isArray,
    isBool,
    isString,
    isNumber,
    isEmpty
}