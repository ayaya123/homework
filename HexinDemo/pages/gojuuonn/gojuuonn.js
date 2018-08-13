//const Util = require('../../utils/util.js')
const Data = require('../../data.js')
Page({
  //data 将会以 JSON 的形式由逻辑层传至渲染层，所以其数据必须是可以转成 JSON 的格式：字符串，数字，布尔值，对象，数组。
  //此处 forfoot 用数据徐循环则没什么意思了 无法绑定 并 调用回调 data中也无法存function;
  data: {
    minHeight:'',
    mojiList:[],
    // fortest:'test',
    hiraganaShow:true,
    //无法操作dom 都需要靠data绑定
  /*  changeKANAText:'あ',
    tabnow:'seionn',
    sannbunn:false
  */  
  },
  onLoad: function () {
    let that = this;
    //获取系统信息
    wx.getSystemInfo({
      success: function(res) {
        that.setData({
          minHeight: res.windowHeight
        })
      }
    })
    that.setData({
      mojiList: Data.zhuzhu
    })
    
  },
  //eventHandle  需在相应的Page定义中写上相应的事件处理函数...mdzz
  /*changeKANA(e){
    //e 不知道能咋用
    let show = this.data.hiraganaShow;
    this.setData({
      hiraganaShow: !show
    })  
    !show?this.setData({changeKANAText: 'あ'}):this.setData({changeKANAText: 'ア'})
  },*/
  toSEIONN(){
    this.setData({
      mojiList: Data.seionn,
      tabnow:'seionn',
      sannbunn:false
    })
  },
  toDAKUONN(){
    this.setData({
      mojiList: Data.dakuonn,
      tabnow:'dakuonn',
      sannbunn:false
    })
  },
  toYOUONN(){
    this.setData({
      mojiList: Data.youonn,
      tabnow:'youonn',
      sannbunn:true
    })
  },
  toAAAAA() {
    this.setData({
      mojiList: Data.aaaaa,
      tabnow: 'aaaaa',
      sannbunn: true
    })
  },
  toEEEEE() {
    this.setData({
      mojiList: Data.eeeee,
      tabnow: 'eeeee',
      sannbunn: true
    })
  },
  toFFFFF() {
    this.setData({
      mojiList: Data.fffff,
      tabnow: 'fffff',
      sannbunn: true
    })
  },
  toZHUZHU() {
    this.setData({
      mojiList: Data.zhuzhu,
      tabnow: 'zhuzhu',
      sannbunn: true
    })
  }
})
