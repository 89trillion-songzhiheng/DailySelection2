using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*
 返回开始界面
 */
public class Back : MonoBehaviour
{

    public Button backButton; //后退按钮
    public GameObject startView; //开始页面
    public GameObject backButtonGameObject; //后退按钮对象
    public GameObject coinTitle; //金币数量
    public GameObject shopView; //商品展示页面
    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(GoBack);
    }

    public void GoBack()
    {
        startView.SetActive(true);
        shopView.SetActive(false);
        backButtonGameObject.SetActive(false);
        coinTitle.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
