using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

namespace Script.Config
{
    /// <summary> MyMethod is a method in the MyClass class.
    /// json读取类
    /// </summary>
    public  class JsonRead 
    {
        private static string jsonData; //存储json数据
        private static TextAsset jsonFile; //json文件
        private static JSONNode jsonNode; //获取json数据

        public static JSONNode GetJsonNode()
        {
            jsonFile = (TextAsset) Resources.Load("Data");
            jsonData=jsonFile.text;
            jsonNode = JSONNode.Parse (jsonData);
            return jsonNode;
        }
    }

    
}