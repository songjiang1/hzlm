/// <reference path="/wwwroot/lib/learnlearn.data.js" />
///封装模块 
(function (window, $) {
    var Myth = window.Myth = function () { };
    Myth.fn = Myth.prototype;
    var lr = Myth.lr = Myth.fn.lr = {}; 
    var data = lr.data = {
        dataDict: [],//字典数据
        dataAuthority: [],//存放当前用户所拥有的权限
        ButtonList: [],//保存的时存储的配置 ,保存之后的数据 
        sheetaddCount: 0,
    };
    Myth.QueryString = Myth.fn.QueryString = function (queryStringName) {
        var result = location.search.match(new RegExp("[\?\&]" + queryStringName + "=([^\&]+)", "i"));
        if (result == null || result.length < 1) {
            return "";
        }
        return result[1];
    }; 
})(window, jQuery); 
