using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 开始界面
 */
public class Viewstart : MonoBehaviour
{

    public Button startButton; //开始按钮
    public GameObject backButotn; //回退按钮
    public GameObject coinTitle; //金币数
    public GameObject startView; //开始界面
    public GameObject shopView; //商品展示页面
    
    // Start is called before the first frame update
    void Start()
    {
        startView.SetActive(true);
        shopView.SetActive(false);
        backButotn.SetActive(false);
        coinTitle.SetActive(false);
        startButton.onClick.AddListener(SceneChange);
    }

    public void SceneChange()
    {
        startView.SetActive(false);
        shopView.SetActive(true);
        backButotn.SetActive(true);
        coinTitle.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
