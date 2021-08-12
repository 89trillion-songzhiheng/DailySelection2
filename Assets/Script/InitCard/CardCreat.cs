using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


/*
 * 卡片生成
 */
        
public class CardCreat : MonoBehaviour
 {
     public PerfabEmptyCard emptyCard; //不够三的倍数，进行补卡对象
     public PerfabCard perfabCard; //卡片预制体实体类对象
     public TextAsset jsonFile; //获取json文件
     public GameObject cardPanel; //卡片面板
     
     private int abscissaCardCount = 0;  //获取横坐标方向的卡片数量
     private int ordinateCardCount = 0; //获取纵坐标方向的卡片数量
     private  string jsonData; //存放json文件中的数据
     
     void Start ()
     {
         jsonData=jsonFile.text;
         CreatCard();
     }
     
     public  void CreatCard ()
     {
         int type = 0; //json字段中的type
         int costGold = 0; //json字段中的costGold
         string subType = ""; //json字段中的subType
         
         int nullCard = 0; //填补该数量卡片实现3的倍数
         int columnCard = 0; //纵向卡片数量；
         int number = 0; //接收生成的随机数
         
         //将json数据格式化
         var jsonNode  = JSONNode.Parse (jsonData);
         JSONArray jsonArray=jsonNode[0].AsArray;
         
         //循环读取json数据
         foreach (JSONNode jsonField in jsonArray)
         {
             PerfabCard  CardPrefab = Instantiate(perfabCard);
             CardPrefab.transform.SetParent(cardPanel.transform);
             CardPrefab.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
             
             
             type = jsonField["type"];
             costGold = jsonField["costGold"];
             subType = jsonField["subType"].ToString();
         
             //如果卡片类型为空
             if (jsonField["subType"] == null)
             { 
                 System.Random random= new System.Random();
                 number = random.Next(1,3);
                 CardPrefab.btnText.text = "0";
                 CardPrefab.btnImage.color = new Color(1,1,1,0);
                 CardPrefab.btnImage.rectTransform.sizeDelta = new Vector2(80, 87);
                 
                 if (number == 1)
                 {
                     CardPrefab.backImage.sprite = Resources.Load<Sprite>("DailySelection/coin/coin_1");
                     CardPrefab.backColor.color = new Color(1,1,1,0);
                     CardPrefab.cardName.text = "金币";
                 }
                 else
                 {
                     CardPrefab.backImage.sprite = Resources.Load<Sprite>("DailySelection/diamond/diamond_2");
                     CardPrefab.backColor.color = new Color(1,1,1,0);
                     CardPrefab.cardName.text = "钻石";
                 }
             }
             else
             {
                 //判断货币类型
                 if ( type==3)
                 {
                     CardPrefab.btnText.text = costGold.ToString();
                     CardPrefab.btnImage.sprite  = Resources.Load<Sprite>("DailySelection/coin/coin");
                     CardPrefab.btnImage.rectTransform.sizeDelta  = new Vector2(49, 44);
                     CardPrefab.backImage.sprite = Resources.Load<Sprite>("DailySelection/card/"+subType+"");
                 }
             }
             abscissaCardCount++;
             ordinateCardCount++;
         }
         
         //卡片数量不够3的倍数，进行补缺
         nullCard = jsonArray.Count % 3;
         if (nullCard !=0)
         {
             for (int i = 0; i < (3-nullCard); i++)
             {
                 PerfabEmptyCard EmptyCardPrefab=   Instantiate(emptyCard);
                 EmptyCardPrefab.transform.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
                 EmptyCardPrefab.transform.SetParent(cardPanel.transform);
                 EmptyCardPrefab.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
                 EmptyCardPrefab.lose.sprite = Resources.Load<Sprite>("DailySelection/card/shop_lock");
                 EmptyCardPrefab.lose.rectTransform.sizeDelta = new Vector2(156, 218);
                 abscissaCardCount++;
                 ordinateCardCount++;
             }
             columnCard = (nullCard + jsonArray.Count) / 3;
             cardPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(250,600*columnCard);
         }
     }
     
}
        