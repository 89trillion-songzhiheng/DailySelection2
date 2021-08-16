using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using DG.Tweening;

/// <summary> MyMethod is a method in the MyClass class.
/// 硬币移动实现类
/// </summary>
public class CoinMove : MonoBehaviour
{
    public GameObject canvas;  //展示金币飞行动画 
    public GameObject content; //宝箱父类对象
    public GameObject coin;  //硬币对象
    public GameObject coinImage;  //金币图片
    public Text coinNumber;  //获取当前总金币数
    public GameObject coinTitle;  //金币标题
    
    //计算宝箱相对位置
    public PrefabTreasure prefabTreasure;  //宝箱预制体实体类对象
    public GameObject shopView;  //购买页面获取相对位置
    public GameObject treasurePanel;  //存放宝箱的面板
    public GameObject viewPort; //宝箱父类对象

    private int coinLargeCount = 15; //金币最大生成数
    private GameObject coinPrefab; //生成硬币的预制件实例
    private int coinPrefabCount = 0; //计算预制件生成个数
    private Vector3 coinPrefabPosition; //硬币预制件实例生成坐标
    private Vector3 tragetPosition; //硬币预制件目标路径
    
    // Start is called before the first frame update
    void Start()
    {
        //金币移动目标地址
         tragetPosition = coinImage.transform.localPosition + coinTitle.transform.localPosition;
         CreatTreasure();
    }
    
    /// <summary> MyMethod is a method in the MyClass class.
    /// 生成宝箱实例，并绑定宝箱按钮点击事件
    /// </summary>
    public void CreatTreasure()
    {
        PrefabTreasure preTreasure = Instantiate(prefabTreasure, treasurePanel.transform);
        
        preTreasure.button.onClick.AddListener(() => { CreatAndMoveCoin();});
    }
    
    /// <summary> MyMethod is a method in the MyClass class.
    /// 生成金币实例并通过DoTween实现移动
    /// </summary>
    public void CreatAndMoveCoin()
    {
        //通过初始化金币生成位置
        coinPrefabPosition =  prefabTreasure.transform.localPosition + treasurePanel.transform.localPosition + 
                              content.transform.localPosition + viewPort.transform.localPosition + 
                              shopView.transform.localPosition;
        
        //保证金币数最大为15
        if (coinPrefabCount < coinLargeCount) 
        {
            coinPrefabCount = coinPrefabCount + 5;
        }
        
        //初始化预制件实例
        coinPrefab = Instantiate(coin, canvas.transform);
        coinPrefab.SetActive(true);
        coinPrefab.transform.localPosition = coinPrefabPosition;

        //使用DoTween实现金币移动
        coinPrefab.transform.DOLocalMove(tragetPosition, 0.15f).SetLoops(coinPrefabCount,LoopType.Restart).OnStepComplete(() =>
        {
            coinNumber.text = (int.Parse(coinNumber.text) + 1).ToString();
        }).OnComplete((() => Destroy(coinPrefab)));
        
    }
}
