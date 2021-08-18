using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary> MyMethod is a method in the MyClass class.
/// 卡片预制体实体类
/// </summary>
public class PrefabCard : MonoBehaviour
{
    public GameObject prefabCard; //卡片预置体对象
    public Image backColor; //卡片背景色
    public Image backImage; //卡片背景图
    public Image btnImage; //按钮图像
    public Text btnText; //按钮文字
    public GameObject button; //按钮对象
    public GameObject buy; //购买成功图标
    public Button buyButton; //购买按钮
    public Text cardName; //卡片名称
}
