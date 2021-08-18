# DailySelection2

**整体大纲**
 1.动态加载卡片资源，根据实际要求进行场景布局。
 2.设计游戏脚本，绑定对应的游戏对象，实现事件交互。
 
**目录结构**  
>Config  
>>JsonRead.cs  //读取json数据  
>>JsonRead.cs.meta  
>Config.meta  
>Controller  
>>DailySelection  
>>>CardCreat.cs  //创建卡片  
>>>CardCreat.cs.meta  
>>DailySelection.meta  
>>TitleCreat.cs  //创建标题  
>>TitleCreat.cs.meta  
>>Treasure  
>>>CoinMove.cs  //金币移动  
>>>CoinMove.cs.meta  
>>Treasure.meta  
>>ViewChange.cs  
>>ViewChange.cs.meta  
>Controller.meta  
>Data  
>>PrefabCard.cs //卡片预置体  
>>PrefabCard.cs.meta  
>>PrefabTitle.cs //标题预置体  
>>PrefabTitle.cs.meta  
>>PrefabTreasure.cs //宝箱预置体  
>>PrefabTreasure.cs.meta  
>Data.meta  
 
**界面结构**. 
  Hierarchy:  
    1.Canvas:  
     1).StartView //开始界面. 
     2).ShopView。//购买界面. 
     3).BackButton //回退到开始界面. 
     4).CoinPanel //展示金币飞行的面板. 
     5).CoinTitle //展示当前金币数. 
     
  Prefabs:
    1.Card:卡片预置体 
    2.Title:标题预置体 
    3.EmptyCard空卡预置体 
    4.Treasure:宝箱预置体 
    5.CoinImg硬币预置体
  
**流程图**  

![image](https://github.com/89trillion-songzhiheng/DailySelection2/blob/main/Picture/newTrepic.png)
