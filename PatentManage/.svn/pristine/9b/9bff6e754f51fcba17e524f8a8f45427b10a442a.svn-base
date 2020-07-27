<template>
    <div :style="{height}">
        <div class="tool">
            <el-button size="mini" type="primary" icon="el-icon-s-grid" @click="changeView" v-if="isChangeViewShow"></el-button>
            <el-button size="mini" type="primary" icon="el-icon-search" @click="search" v-if="isSearchShow"></el-button>
            <el-button type="primary" icon="el-icon-zoom-in" size="mini" @click="zoomOut"></el-button>
            <el-button type="primary" icon="el-icon-zoom-out" size="mini" @click="zoomIn"></el-button>
        </div>
        <div id="jsmind_container"></div>
        <div v-show="menuVisible">
            <ul id="menu" class="menu">
                <li class="menu_item" @click="findNextNorm">权重划分</li>
                <li class="menu_item" @click="addNextNorm">添加子指标</li>
            </ul>
        </div>
    </div>
</template>

<script>
    import "./jsmind.js";
    import "./jsmind.css";
    import './jsmind.draggable.js'
    import './jsmind.screenshot.js'

    export default {
        name: "jsMind",
        props: {
            height: {
                type: String,
                required: true
            },
            isChangeViewShow: {
                type: Boolean,
                required: false,
                default:true
            },
            isSearchShow: {
                type: Boolean,
                required: false,
                default:true
            }
        },
        methods: {
            show(val) {
                this.values = val;
                // 默认配置
                let options = {
                    container: "jsmind_container",
                    editable: false, // 是否启用编辑
                    theme: "primary", // 主题
                    mode: "full", // 显示模式
                    support_html: false, // 是否支持节点里的HTML元素
                    view: {
                        engine: "canvas", // 思维导图各节点之间线条的绘制引擎
                        hmargin: -15, // 思维导图距容器外框的最小水平距离
                        vmargin: -10, // 思维导图距容器外框的最小垂直距离
                        line_width: 2, // 思维导图线条的粗细
                        line_color: "#428bca" // 思维导图线条的颜色#428bca
                    },
                    layout: {
                        hspace: 30, // 节点之间的水平间距
                        vspace: 20, // 节点之间的垂直间距
                        pspace: 15 // 节点与连接线之间的水平间距（用于容纳节点收缩/展开控制器）
                    },
                    shortcut: {
                        enable: false, // 是否启用快捷键
                        handles: {}, // 命名的快捷键事件处理器
                        mapping: {
                            // 快捷键映射
                            addchild: 45, // <Insert>
                            addbrother: 13, // <Enter>
                            editnode: 113, // <F2>
                            delnode: 46, // <Delete>
                            toggle: 32, // <Space>
                            left: 37, // <Left>
                            up: 38, // <Up>
                            right: 39, // <Right>
                            down: 40 // <Down>
                        }
                    },
                    default_event_handle: {
                        enable_mousedown_handle: true,
                        enable_click_handle: true,
                        enable_dblclick_handle: true
                    },
                };
                // options = Object.assign(options, this.options);
                this.jm = window.jsMind.show(options, this.values, this.jsmindNodeClick);
                this.jm.expand_all();
                this.jm.view.zoomOut();
            },
            jsmindNodeClick(val, e) {
                if (e.button === 0) {
                    this.$emit('nodeClick',val);
                } else if (e.button === 2) {
                    if (val!=null){
                        this.rightClick(e,val);
                    }
                }
            },
            //右键点击
            rightClick(MouseEvent,val) { // 鼠标右击触发事件
                this.rightClickId=val;
                this.menuVisible = false; // 先把模态框关死，目的是 第二次或者第n次右键鼠标的时候 它默认的是true
                this.menuVisible = true ; // 显示模态窗口，跳出自定义菜单栏
                var menu = document.querySelector('#menu');
                document.addEventListener('click', this.foo); // 给整个document添加监听鼠标事件，点击任何位置执行foo方法
                menu.style.left = MouseEvent.clientX -190+ 'px';
                menu.style.top = MouseEvent.clientY -60 + 'px'
            },
            foo() { // 取消鼠标监听事件 菜单栏
                this.menuVisible = false;
                document.removeEventListener('click', this.foo) // 要及时关掉监听，不关掉的是一个坑，不信你试试，虽然前台显示的时候没有啥毛病，加一个alert你就知道了
            },
            handleScroll: function (e) {
                if (this.menuVisible){
                    this.menuVisible = false;
                }
            },
            zoomIn(){
                this.jm.view.zoomOut();
            },
            zoomOut(){
                this.jm.view.zoomIn()
            },
            findNextNorm(){
                this.$emit('findClick',this.rightClickId);
            },
            addNextNorm(){
                this.$emit('addClick',this.rightClickId);
            },
            changeView(){
                this.$emit('changeView');
            },
            search(){
                this.$emit('search');
            },
            selectNode(val){
                if (val instanceof Array){
                    val.forEach(item=>{
                        this.jm.select_node(item);
                    })
                }
            },
        },
        mounted() {
            window.addEventListener('scroll', this.handleScroll, true);  // 监听（绑定）滚轮滚动事件
        },
        data() {
            return {
                jm: {},
                menuVisible: false,
                zoomStep:50,
                rightClickId:0
            }
        }
    };
</script>
<style scoped>
    #jsmind_container {
        height: 100%;
    }
    .tool{
        width: 100%;
        text-align:right;
    }
    .menu_item {
        line-height: 20px;
        text-align: center;
        margin-top: 10px;
        color: black;
    }

    .menu {
        z-index:9999;
        height: 70px;
        width: 100px;
        position: absolute;
        border-radius: 10px;
        border: 1px solid #999999;
        background-color: #f4f4f4;
    }

    li:hover {
        background-color: #1790ff;
        color: white;
    }
    li{font-size:15px}
</style>
