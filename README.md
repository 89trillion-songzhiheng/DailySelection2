# DailySelection2

**整体大纲**
  1.设计场景，使用的UI组件，图片资源
  2.设计脚本对游戏对象，触发事件进行设计

**目录结构**
├── Back //后退
│   ├── Back.cs      //回退到开始页面
│   └── Back.cs.meta
├── Back.meta
├── Coin //金币
│   ├── CoinMove.cs  //金币移动到指定地点
│   └── CoinMove.cs.meta
├── Coin.meta
├── Gamestart //开始页面
│   ├── Viewstart.cs      //由开始界面移动到购买界面
│   └── Viewstart.cs.meta
├── Gamestart.meta
├── InitCard //初始化卡片
│   ├── CardCreat.cs        //创建卡片
│   ├── CardCreat.cs.meta
│   ├── PerfabCard.cs       //卡片预制件
│   ├── PerfabCard.cs.meta
│   ├── PerfabCardPanel.cs  //卡片面板预制件，存放生成的卡片
│   ├── PerfabCardPanel.cs.meta
│   ├── PerfabEmptyCard.cs  //空卡预制件，当卡片不够三的倍数，进行补卡
│   ├── PerfabEmptyCard.cs.meta
│   ├── Treasure.cs //宝箱操作
│   └── Treasure.cs.meta
├── InitCard.meta
├── ParsingJSON   //json解析工具类
│   ├── SimpleJSON.cs
│   ├── SimpleJSON.cs.meta
│   ├── SimpleJSONBinary.cs
│   ├── SimpleJSONBinary.cs.meta
│   ├── SimpleJSONDotNetTypes.cs
│   ├── SimpleJSONDotNetTypes.cs.meta
│   ├── SimpleJSONUnity.cs
│   └── SimpleJSONUnity.cs.meta
├── ParsingJSON.meta
├── Shop //购买
│   ├── buy.cs //更改购买状态
│   └── buy.cs.meta
└── Shop.meta

**界面结构**
  Hierarchy：
    1.Canvas: 
     1).StartView //开始界面
     2).ShopView。//购买界面
     3).BackButton //回退到开始界面
     4).CoinPanel //展示金币飞行的面板
     5).CoinTitle //展示当前金币数
