// 表格基础功能类
class LearnIndex {
    /* 构造方法
     * method constructor
     */
    constructor() {
        //layer元素
        this.$ = null;
        this.upload = null;
        this.form = null;
        this.tree = null;
        this.element = null;
        this.laydate = null;
        this.layer = null; 
    }

    defaultInit() {
        layui.use(['form', 'tree', 'upload', 'element', 'laydate'], function () {
            LearnIndex.$ = layui.jquery;
            LearnIndex.upload = layui.upload;
            LearnIndex.form = layui.form;
            LearnIndex.tree = layui.tree;
            LearnIndex.element = layui.element;
            LearnIndex.laydate = layui.laydate;
            LearnIndex.layer = layer; 
        })
    }
    init() {
        
    }
}
