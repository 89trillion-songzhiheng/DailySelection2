using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary> MyMethod is a method in the MyClass class.
/// 界面转换
/// </summary>
public class ViewChange : MonoBehaviour
{
    public Button backButton; //后退按钮
    public Button startButton; //开始按钮
    public GameObject backObject; //后退按钮对象
    public GameObject coinTitle; //金币标题
    public GameObject startView; //开始界面
    public GameObject shopView; //商品展示页面
    
   
    void Start()
    {
        startView.SetActive(true);
        shopView.SetActive(false);
        backObject.SetActive(false);
        coinTitle.SetActive(false);
        
        startButton.onClick.AddListener(StarShop);
        backButton.onClick.AddListener(GoBack);
    }

    public void StarShop()
    {
        startView.SetActive(false);
        shopView.SetActive(true);
        backObject.SetActive(true);
        coinTitle.SetActive(true);
    }
    
    public void GoBack()
    {
        startView.SetActive(true);
        shopView.SetActive(false);
        backObject.SetActive(false);
        coinTitle.SetActive(false);
    }
}
