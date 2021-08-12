using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/*
  更改购买状态
 */
public class buy : MonoBehaviour
{
    
    public GameObject buyBefore; //购买前图标
    public GameObject buyAfter; //购买后图标
    
    public Button button; //对象按钮
    public Text btntext; //购买需要的金币数
    
    private Text number; //获取当前可用金币数
    private int countcoin; //获取可用金币数
    
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(ChangeStatus);
    }
    public void ChangeStatus()
    {
        int currentNumber = 0; //当前拥有的总金币数
        
        number = GameObject.Find("number").transform.GetComponent<Text>();

        if (int.Parse(number.text) >= int.Parse(btntext.text))
        {
            currentNumber = int.Parse(number.text);
            currentNumber -= int.Parse(btntext.text);;
            number.text = currentNumber.ToString();
        
            buyBefore.SetActive(false);
            buyAfter.SetActive(true);   
        }

    }
    // Update is called once per frame
    void Update()
    {
        
         
    }
}
