// 表格基础功能类
class LearnCommon {
    /* 构造方法
     * method constructor
     */
    constructor() { 
    }
    //#region open弹框
    openDialog(option) {
        if (this.isMobile()) {
            option.width = 'auto';
            option.height = 'auto';
        }
        else {
            if (option&&!option.height) {
                option.height = ($(window).height() - 50) + 'px';
            }
        }
        var _option = $.extend({
            type: 2,
            title: '',
            width: '768px',
            content: '',
            maxmin: true,
            shade: 0.4,
            btn: ['确认', '关闭'],
            callback: null,
            shadeClose: false,
            fix: false,
            closeBtn: 1
        }, option);
        layer.open({
            type: _option.type, // 2表示content的值为url，1表示content的值为html
            area: [_option.width, _option.height],
            maxmin: _option.maxmin,
            shade: _option.shade,
            title: _option.title,
            content: _option.content,
            btn: _option.btn,
            shadeClose: _option.shadeClose, // 弹层外区域关闭     
            fix: _option.fix,
            closeBtn: _option.closeBtn,  // 1表示带关闭，0表示不带
            yes: _option.callback,
            cancel: function (index) {
                return true;
            }
        });
    }
    //#endregion 通用
    isMobile() {
        return navigator.userAgent.match(/(Android|iPhone|SymbianOS|Windows Phone|iPad|iPod)/i);
    }
    //#region
    //#endregion

    //#region
    //#endregion
    
}
