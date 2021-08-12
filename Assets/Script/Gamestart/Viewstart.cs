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
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(SceneChange);
    }

    public void SceneChange()
    {
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
