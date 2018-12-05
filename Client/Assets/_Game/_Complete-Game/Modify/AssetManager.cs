using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Object = UnityEngine.Object;

public class AssetManager : MonoBehaviour
{

    public static AssetManager Instance;

  

    void Awake()
    {
        Instance = this;
    }




    public void LoadAsset(string path, string resName, Action<Object> callBack)
    {
        StartCoroutine(GetAsset(path, resName, callBack));
    }


    IEnumerator GetAsset(string path,string resName,Action<Object> callBack)
    {
        UnityWebRequest request = UnityWebRequest.GetAssetBundle(path);
        yield return request.Send();
        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);

        if (callBack != null)
        {
            callBack(ab.LoadAsset(resName));
        }
        ab.Unload(false);
        yield return null;
    }





}
