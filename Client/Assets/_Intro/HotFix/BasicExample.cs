using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XLua;

public class BasicExample : MonoBehaviour
{


    private LuaEnv env;
	// Use this for initialization
	void Start () {

        CustomLoader();
  
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


    void CustomLoader()
    {
       env=new LuaEnv();
       env.AddLoader(EAELoader);
       env.AddLoader(RealLoader);
       env.DoString("require 'luaExample'");
    }


    private byte[] EAELoader(ref string filePath)
    {
        Debug.Log(" Enter EAELoader function!");
        return null;
    }


    private byte[] RealLoader(ref string filePath)
    {
      return  Encoding.UTF8.GetBytes(File.ReadAllText(Application.streamingAssetsPath + "/_Assets/_Lua/" + filePath + ".lua.txt"));
    }

    void OnDestroy()
    {
        env.Dispose();
    }
}
