using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


/*
 * 移动硬币
 */
public class CoinMove : MonoBehaviour
{
    public GameObject coinPanel; //展示金币飞行动画 
    public GameObject coin; //硬币对象
    public GameObject treasure; //宝箱对象
    public Button button; //按钮
    
    public Text buttonText; //获取按钮文本框，
    public Text coinNumber; //获取当前总金币数    
    
    private GameObject coinPrefab; //生成硬币的预制件实例
    private string buttonTextData;  //存放上述按钮文本框的数据
    private bool isMove = false; //控制update函数调用
    
    private int coinPrefabCount = 1; //计算预制件生成个数
    private int currentLargest=0; //获取当前生成金币最大数
    private int lastBiggest = 0; //获取上次生成金币最大数
    
    private Vector3 coinPrefabPosition; //硬币预制件实例生成坐标
    private Vector3 coinPrefabLocalscale; //硬币预制件实例缩放数值
    private Vector3 tragetPosition; //硬币预制件目标路径
    
    // Start is called before the first frame update
    void Start()
    {
        //金币移动目标地址
        tragetPosition = new Vector3(190, 820, 0);
        
        Debug.Log(treasure.transform.position);
        Debug.Log(treasure.transform.TransformDirection(treasure.transform.position));
        //获取按钮文本，获取当前可生成金币的最大数
        buttonTextData= buttonText.text;
        lastBiggest = int.Parse(buttonTextData);

        button.onClick.AddListener(CreatCoin);
    }
    
    public void CreatCoin()
    {
        //初始化位置与缩放倍数
        coinPrefabPosition = new Vector3(-350,-600,0);
        coinPrefabLocalscale = new Vector3(1, 1, 0);
        
        //获取按钮点击后的文本框数值
        buttonTextData= buttonText.text;
        currentLargest = int.Parse(buttonTextData);
        
        //初始化预制件实例
        coinPanel.SetActive(true);
        coinPrefab  = Instantiate(coin);
        coinPrefab.transform.SetParent(coinPanel.transform);
        coinPrefab.SetActive(true);
        coinPrefab.transform.localPosition = coinPrefabPosition;
        coinPrefab.transform.localScale = coinPrefabLocalscale;
            
        //调用update函数
        isMove = true;
    }
    
    public void MoveCoin()
    {
        //判断硬币是否到达目标地点
        if (coinPrefab.transform.localPosition != tragetPosition )
        {
            //控制硬币移动
            coinPrefab.transform.localPosition = Vector3.MoveTowards(coinPrefab.transform.localPosition,
                tragetPosition, 200f);
        }
        else
        { 
            coinNumber.text = (int.Parse(coinNumber.text) + 1).ToString();
            
            //销毁到达目标地的实例
            Destroy(coinPrefab);
            
            coinPrefabCount++;
        
            if (coinPrefabCount <= lastBiggest)
            {
                coinPrefab = Instantiate(coin);
                coinPrefab.SetActive(true);
                coinPrefab.transform.SetParent(coinPanel.transform);
                coinPrefab.transform.localPosition = coinPrefabPosition;
                coinPrefab.transform.localScale = coinPrefabLocalscale;
            }
            else
            {
                coinPanel.SetActive(false);
                lastBiggest = currentLargest;
                isMove = false;
                coinPrefabCount = 1;
            }
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            if (Time.frameCount %1 ==0)
            {
                enabled = true;
                MoveCoin();
            }
        }
    }
}
