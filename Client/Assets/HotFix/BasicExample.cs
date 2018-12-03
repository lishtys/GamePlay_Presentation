using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class BasicExample : MonoBehaviour
{


    private LuaEnv env;
	// Use this for initialization
	void Start () {

      Basic();
	}


    void Intro()
    {
        env = new LuaEnv();

        // Using Lua Native Print Method
        env.DoString("print('Go Split')");

        // Call CSharp  -> CS Prefix
        env.DoString("CS.UnityEngine.Debug.Log('Go Split')");

        var luaContent = Resources.Load<TextAsset>("luaExample");

        env.DoString(luaContent.text);
    }


    void Basic()
    {
       env=new LuaEnv();

       // -> Load and Run -> From Resources
       env.DoString("require 'luaExample'");
    }


    void OnDestroy()
    {
        env.Dispose();
    }
}
