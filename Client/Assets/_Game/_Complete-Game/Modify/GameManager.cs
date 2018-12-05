using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private string assetBundleDir;

    // Use this for initialization
    void Start () {

        //todo Load From Database

         assetBundleDir= Path.Combine(Application.streamingAssetsPath, "_Assets/_Bundles/");
	    var pathEnv = Path.Combine(assetBundleDir, "game/env.eae");





        AssetManager.Instance.LoadAsset(pathEnv,"Environment",
            (o) =>
            {
                if (o != null)
                {
                    GameObject env=o as GameObject;
                    Instantiate(env);
                }
            }
            
            );
		
	}
	
	
}
