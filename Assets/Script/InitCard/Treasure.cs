using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 修改宝箱花费的金币数
 */
public class Treasure : MonoBehaviour
{
    
    public Text btnText; //宝箱
    
    public Button button; //宝箱按钮
    
    private int num = 5;  //初始数值

    // Start is called before the first frame update
    void Start()
    {
        
        button.onClick.AddListener(ChangeNum);
    }
    
    public void ChangeNum()
    {
        if (num<15)
        {
            num = num + 5;
            btnText.text = num.ToString();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
