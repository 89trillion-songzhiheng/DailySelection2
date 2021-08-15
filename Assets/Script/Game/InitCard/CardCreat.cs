using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


/// <summary> MyMethod is a method in the MyClass class.
/// 卡片生成类
/// </summary>
public class CardCreat : MonoBehaviour
 {
     public GameObject cardPanel; //卡片面板，用于存放卡片
     public RectTransform cardPanelRect; //获取cardPanel的RectTransform属性
     public Text coinCount; //获取当前可用金币数
     public PrefabEmptyCard emptyCard; //不够三的倍数，进行补卡对象
     public PrefabCard prefabCard; //卡片预制体实体类对象
     
     private  string jsonData; //存放json文件中的数据
     private TextAsset jsonFile; //获取json文件
     
     void Start ()
     {
         CreatCard();
     }

    
     /// <summary> MyMethod is a method in the MyClass class.
     /// 卡片生成方法
     /// </summary>
     public  void CreatCard ()
     {
         int columnCard = 0; //纵向卡片数量；
         int costGold = 0;   //json字段中的costGold
         int nullCard = 0;   //填补该数量卡片实现3的倍数
         int number = 0;     //接收生成的随机数
         string subType = ""; //json字段中的subType
         
         jsonFile = (TextAsset)Resources.Load("data");
         jsonData=jsonFile.text;
         
         //将json数据格式化
         var jsonNode  = JSONNode.Parse (jsonData);
         JSONArray jsonArray=jsonNode[0].AsArray;
         
         //循环读取json数据，将数据添加到生成的卡片实例中
         foreach (JSONNode jsonField in jsonArray)
         {
             PrefabCard  CardPrefab = Instantiate(prefabCard,cardPanel.transform);

             CardPrefab.buyButton.onClick.AddListener(() => { Buy(CardPrefab);});
             
             costGold = jsonField["costGold"];
             subType = jsonField["subType"].ToString();
             
             
             //根据'subType'字段是否为空，决定卡片要填充的数据
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
                 PrefabEmptyCard EmptyCardPrefab = Instantiate(emptyCard,cardPanel.transform);
                 EmptyCardPrefab.lose.sprite = Resources.Load<Sprite>("DailySelection/Card/shop_lock");
             }
             
             //根据纵向卡片数量，设置卡片面板的高度
             columnCard = (nullCard + jsonArray.Count) / 3;
             cardPanelRect.sizeDelta = new Vector2(250,600*columnCard);
         }
       
     }

     /// <summary> MyMethod is a method in the MyClass class.
     /// 点击购买，减少相应的金币数并变换购买状态
     /// </summary>
     public void Buy(PrefabCard cardPrefab)
     {
         coinCount.text = (int.Parse(coinCount.text) - int.Parse(cardPrefab.btnText.text)).ToString();
         
         cardPrefab.button.SetActive(false);  
         cardPrefab.buy.SetActive(true);
         
     }
}
        