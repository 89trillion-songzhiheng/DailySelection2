using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> MyMethod is a method in the MyClass class.
/// 生成标题类
/// </summary>
public class TitleCreat : MonoBehaviour
{
    public GameObject cardTitle; //卡片标题
    public PrefabTitle prefabTitle; //标题预制体实体类对象
    public GameObject treasureTitle; //宝箱标题
    // Start is called before the first frame update
    void Start()
    {
        prefabTitle = Instantiate(prefabTitle, cardTitle.transform);
        prefabTitle.titleText.text = "每日精选";
        
        prefabTitle = Instantiate(prefabTitle, treasureTitle.transform);
        prefabTitle.titleText.text = "宝箱";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
