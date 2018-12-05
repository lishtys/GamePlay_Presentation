using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaCallCSharpExample : MonoBehaviour {

    private LuaEnv env;
    // Use this for initialization
    void Start () {
		Intro();
	}



    void Intro()
    {
        env = new LuaEnv();
        env.DoString("require 'luaCallCSharpExample'");

     
        
    }


}
