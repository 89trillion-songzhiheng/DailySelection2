using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

/// <summary> MyMethod is a method in the MyClass class.
/// json读取类
/// </summary>
public class JsonRead : MonoBehaviour
{
    private string jsonData; //存储json数据
    private TextAsset jsonfile; //json文件
    public JSONNode jsonNode; //获取json数据

    private void Awake()
    {
        jsonfile = (TextAsset) Resources.Load("Data");
        jsonData=jsonfile.text;
        jsonNode = JSONNode.Parse (jsonData);
    }
}
