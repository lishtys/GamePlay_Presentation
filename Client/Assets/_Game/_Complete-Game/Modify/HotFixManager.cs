using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XLua;

public class HotFixManager : MonoBehaviour
{

    private LuaEnv luaEnv;


    // Use this for initialization
    void Awake()
    {

        luaEnv = new LuaEnv();

        luaEnv.AddLoader(CustomLoader);

        luaEnv.DoString("require 'shooter' ");
    }

    private byte[] CustomLoader(ref string filePath)
    {
        var fPath = Application.streamingAssetsPath + "/_Assets/_Game/" + filePath + ".lua.txt";
        return Encoding.UTF8.GetBytes(File.ReadAllText(fPath));
    }


    void OnDisable()
    {
        luaEnv.DoString("require 'shooterFree' ");
    }

    void OnDestroy()
    {
        luaEnv.Dispose();
    }
}
