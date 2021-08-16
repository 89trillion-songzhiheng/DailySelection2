  # DailySelection
  
  **界面结构**
   Hierarchy：
     1）Camera：负责查看界面。
     2）Canvas: 画布，包含所用的UI组件。
                1.使用Scrollview 展示商品位。
                2.使用Button与脚本进行事件的交互。
                3.使用Image进行图像渲染。
   prefab：
     1）Button: 根据货币类型设置两种类型的预制件。
     2）Image：图像的基本预制件。

  **代码结构**
    1）Parsing JSON：负责解析json文件。
    2）Event: 处理按钮点击事件
    3）GameObj：处理游戏对象
  
  **流程图**
    