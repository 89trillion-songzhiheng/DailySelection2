using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


/*
  卡片生成
 */
        
public class CardCreat : MonoBehaviour
 {
     public PerfabEmptyCard emptyCard; //不够三的倍数，进行补卡对象
     public PerfabCard perfabCard; //卡片预制体实体类对象
     public GameObject cardPanel; //卡片面板，用于存放卡片
     public  Text coincount; //获取当前可用金币数

     private  string jsonData; //存放json文件中的数据
     private TextAsset jsonFile; //获取json文件
     void Start ()
     {
         jsonFile = (TextAsset)Resources.Load("data");
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
             PerfabCard  CardPrefab = Instantiate(perfabCard,cardPanel.transform);

             CardPrefab.buyButton.onClick.AddListener(() => { Buy(CardPrefab);});
             
             type = jsonField["type"];
             costGold = jsonField["costGold"];
             subType = jsonField["subType"].ToString();
             
             CardPrefab.btnImage.rectTransform.sizeDelta  = new Vector2(49, 44);
             
             //如果卡片类型为空
             if (jsonField["subType"] == null)
             { 
                 System.Random random= new System.Random();
                 number = random.Next(1,3);
                 CardPrefab.btnText.text = "0";
                 CardPrefab.backColor.color = new Color(1,1,1,0);
                 
                 if (number == 1)
                 {
                     CardPrefab.backImage.sprite = Resources.Load<Sprite>("DailySelection/Coin/coin_1");
                     CardPrefab.btnImage.sprite  = Resources.Load<Sprite>("DailySelection/Coin/coin");
                     CardPrefab.cardName.text = "金币";
                 }
                 else
                 {
                     CardPrefab.backImage.sprite = Resources.Load<Sprite>("DailySelection/Diamond/diamond_2");
                     CardPrefab.btnImage.sprite = Resources.Load<Sprite>("DailySelection/Diamond/diamond_2");
                     CardPrefab.cardName.text = "钻石";
                 }
                 
             }
             else
             {
                 //初始化卡片
                 CardPrefab.btnText.text = costGold.ToString();
                 CardPrefab.btnImage.sprite  = Resources.Load<Sprite>("DailySelection/Coin/coin");
                 CardPrefab.backImage.sprite = Resources.Load<Sprite>("DailySelection/Card/"+subType+"");    
             }
         }
         
         //卡片数量不够3的倍数，进行补缺
         nullCard = jsonArray.Count % 3;
         if (nullCard !=0)
         {
             for (int i = 0; i < (3-nullCard); i++)
             {
                 PerfabEmptyCard EmptyCardPrefab = Instantiate(emptyCard,cardPanel.transform);
                 EmptyCardPrefab.lose.sprite = Resources.Load<Sprite>("DailySelection/Card/shop_lock");
                 EmptyCardPrefab.lose.rectTransform.sizeDelta = new Vector2(156, 218);
             }
             
             //根据纵向卡片数量，设置卡片面板的高度
             columnCard = (nullCard + jsonArray.Count) / 3;
             cardPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(250,600*columnCard);
         }
         
     }
     
     public void Buy(PerfabCard cardPrefab)
     {
         coincount.text = (int.Parse(coincount.text) - int.Parse(cardPrefab.btnText.text)).ToString();
         
         cardPrefab.button.SetActive(false);  
         cardPrefab.buy.SetActive(true);
         
     }
}
        