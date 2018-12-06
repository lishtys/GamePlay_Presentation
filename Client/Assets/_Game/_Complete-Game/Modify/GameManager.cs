﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using XLua;

[Hotfix]
public class GameManager : MonoBehaviour
{

    public List<CompleteProject.EnemyManager> EnemyManagers;
    private int tick = 0;
    public GameObject EnemyGameObject;
    private string assetBundleDir;

    public Dictionary<string, List<string>> EnemyDictionary=new Dictionary<string, List<string>>();
    // Use this for initialization
    void Start () {

        

        InitEnemyPool();
        InitEnemyManager();

        assetBundleDir= Path.Combine(Application.streamingAssetsPath, "_Assets/_Bundles/");
	  
        LoadEnv();
        LoadEnemy();
	}

    void RandomBullet()
    {
       var ps=  FindObjectOfType<PlayerShooting>();
      var r=  Random.Range(0, 10);

        if(r%3==0)
        ps.BounceTimer = 0;
        if(r%3==1)
        ps.PierceTimer = 0;
        if (r % 3 == 2)
        {
            ps.BounceTimer = 10;
            ps.PierceTimer = 10;
        }

    }


    void AddEnemy(string assetBundleTag,string resName)
    {
        if(!EnemyDictionary.ContainsKey(assetBundleTag)) 

        EnemyDictionary[assetBundleTag] = new  List<string>();

        EnemyDictionary[assetBundleTag].Add(resName);
    }

    [LuaCallCSharp]
    void InitEnemyPool()
    {
        AddEnemy("game/enemy.eae", "ZomBunny");
        AddEnemy("game/enemy.eae", "ZomBear");
        AddEnemy("game/enemy.eae", "Hellephant");
    }

    void InitEnemyManager()
    {
        EnemyManagers = EnemyGameObject.GetComponents<CompleteProject.EnemyManager>().ToList();
    }


    void LoadEnv()
    {
        var pathEnv = Path.Combine(assetBundleDir, "game/env.eae");
        AssetManager.Instance.LoadAsset(pathEnv, "Environment",
            (o) =>
            {
                if (o != null)
                {
                    GameObject env = o as GameObject;
                    Instantiate(env);
                }
            }
        );

        var pathLight = Path.Combine(assetBundleDir, "game/env.eae");
        AssetManager.Instance.LoadAsset(pathLight, "Lighting",
            (o) =>
            {
                if (o != null)
                {
                    GameObject env = o as GameObject;
                    Instantiate(env);
                }
            }
        );
    }

    [LuaCallCSharp]
    void Update()
    {

    }

    void LoadEnemy()
    {
        foreach (var pair in EnemyDictionary)
        {
            var path= Path.Combine(assetBundleDir, pair.Key);

            foreach (var resName in pair.Value)
            {
                AssetManager.Instance.LoadAsset(path, resName,
                    (o) =>
                    {
                        if (o != null)
                        {
                            GameObject enemy = o as GameObject;
                            var k = pair.Value.IndexOf(resName);
                            EnemyManagers[k].enemy = enemy;
                        }
                    }
                );
            }

       
        }


    }

       
}
