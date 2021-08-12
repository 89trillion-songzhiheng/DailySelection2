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
    
    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(GoBack);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
   
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
