using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
[LuaCallCSharp]
public class CSharpCallLuaExample : MonoBehaviour {

    private LuaEnv env;


    void Start()
    {
        FunctionCall();
    }

    //Low Performance 
    void GetVariablesFromTable()
    {
        env=new LuaEnv();

        env.DoString("require 'luaVariableExample'");

        var id=  env.Global.Get<int>("ID");
        var name=  env.Global.Get<string>("Name");

        Debug.Log(" Global Variable ID is "+id+" - Name is "+name);

         var md= env.Global.Get<MeshData>("MeshData");

        Debug.Log(md.position+ md.scale);

    }

    [CSharpCallLua]
    delegate void TestFunction(int a, int b);

    void FunctionCall()
    {
        env = new LuaEnv();

        env.DoString("require 'luaVariableExample'");

        var fTest= env.Global.Get<Action>("Test");

        var fTest1 = env.Global.Get<TestFunction>("Test1");
        fTest();
        fTest1(23,45);


        LuaFunction lFunc = env.Global.Get<LuaFunction>("Test1");
        lFunc.Call(112, 1);
    }

}

public class MeshData
{
    public string position;
    public int scale;
}


