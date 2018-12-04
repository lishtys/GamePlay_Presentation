using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class LoadExampleDependency : MonoBehaviour {

    IEnumerator Start()
    {
        var path = Path.Combine(Application.streamingAssetsPath, "unitychan.eae");
        var pathPlane = Path.Combine(Application.streamingAssetsPath, "simple/plane");
        var winManifest = Path.Combine(Application.streamingAssetsPath, "Windows");

        #region Load From File
        //        var ab = AssetBundle.LoadFromFile(path);
        //        if (ab == null)
        //        {
        //            Debug.Log("Failed to load AssetBundle!");
        //            yield return null;
        //        } 
        #endregion


        #region Load From Memeory
        //        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
        //        yield return request;
        //        var ab = request.assetBundle;



        //         var ab = AssetBundle.LoadFromMemory(File.ReadAllBytes(path)); 
        #endregion


        #region WWW

        //        while(Caching.ready == false)
        //        {
        //            yield return null;
        //        }
        //
        //       
        //       WWW www = WWW.LoadFromCacheOrDownload(path, 1);
        //        yield return www;
        //        if ( string.IsNullOrEmpty(www.error)==false )
        //        {
        //            Debug.Log(www.error);
        //            yield break ;
        //        }
        //        AssetBundle ab = www.assetBundle;

        #endregion

        #region WebRequest

        UnityWebRequest request = UnityWebRequest.GetAssetBundle(path);
        yield return request.Send();
        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
        #endregion

        //Load Content
        var prefab = ab.LoadAsset<GameObject>("UnityChan");
        Instantiate(prefab);


        //Check Size

        request = UnityWebRequest.GetAssetBundle(pathPlane);
        yield return request.Send();
        ab = DownloadHandlerAssetBundle.GetContent(request);

        prefab = ab.LoadAsset<GameObject>("Plane");
        Instantiate(prefab);
       
        #region Manifest

        request = UnityWebRequest.GetAssetBundle(winManifest);
        yield return request.Send();
        ab = DownloadHandlerAssetBundle.GetContent(request);
        AssetBundleManifest manifest = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");


        string[] strs = manifest.GetAllDependencies("simple/plane");
        foreach (string name in strs)
        {
            print(name);
            AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + name);
        }

        #endregion

        ab.Unload(false);
        yield return null;

    }
}
