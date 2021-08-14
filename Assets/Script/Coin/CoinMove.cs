using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using DG.Tweening;

/*
  移动硬币
 */
public class CoinMove : MonoBehaviour
{
    public GameObject canvas; //展示金币飞行动画 
    public GameObject coin; //硬币对象
    public Button button; //宝箱卡片按钮
    public GameObject treasure; //宝箱卡片
    public GameObject coinImage; //金币图片
    public GameObject coinTitle; //金币标题
    public GameObject tsePanel;
    public GameObject content;
    public GameObject viewPort;
    public GameObject shopView; //购买页面获取相对位置
    
    public Text coinNumber; //获取当前总金币数    

    private GameObject coinPrefab; //生成硬币的预制件实例
    
    private int coinPrefabCount = 0; //计算预制件生成个数

    private Vector3 coinPrefabPosition; //硬币预制件实例生成坐标
    private Vector3 coinPrefabLocalscale; //硬币预制件实例缩放数值
    private Vector3 tragetPosition; //硬币预制件目标路径

  
    // Start is called before the first frame update
    void Start()
    {
        //金币移动目标地址
        tragetPosition = coinImage.transform.localPosition + coinTitle.transform.localPosition;
        
        coinPrefabLocalscale = new Vector3(1, 1, 1);
        button.onClick.AddListener(CreatAndMoveCoin);
    }
    
    
    /// <summary> MyMethod is a method in the MyClass class.
    /// 生成金币实例并进行移动
    /// </summary>
    public void CreatAndMoveCoin()
    {
        //初始化金币生成位置
        coinPrefabPosition = shopView.transform.localPosition + treasure.transform.localPosition +
                             tsePanel.transform.localPosition + content.transform.localPosition +
                             viewPort.transform.localPosition;
        if (coinPrefabCount < 15)
        {
            coinPrefabCount = coinPrefabCount + 5;
        }
        
        //初始化预制件实例
        coinPrefab = Instantiate(coin);
        coinPrefab.transform.SetParent(canvas.transform);
        coinPrefab.SetActive(true);
        coinPrefab.transform.localPosition = coinPrefabPosition;
        coinPrefab.transform.localScale = coinPrefabLocalscale;
        
        coinPrefab.transform.DOLocalMove(tragetPosition, 0.25f).SetLoops(coinPrefabCount,LoopType.Restart).OnStepComplete(() =>
        {
            coinNumber.text = (int.Parse(coinNumber.text) + 1).ToString();
        }).OnComplete((() => Destroy(coinPrefab)));
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
