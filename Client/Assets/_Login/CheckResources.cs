using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XLua;

public class CheckResources : MonoBehaviour
{
    private string bundleDir = "";

    public static string AssetFolder;


    public Text InfoText;

    void Start()
    {
        InitConfigs();

        StartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
    }


    void EnableStartButton()
    {
        StartButton.gameObject.SetActive(true);
    }



    void InitConfigs()
    {
        string address = File.ReadAllText(Application.streamingAssetsPath + "/SeverConfig.txt");
        bundleDir = address + "/Assets/";
        AssetFolder = Application.streamingAssetsPath + "/_Assets";
    }

    private DownloadItem currentItem;

    void DownloadAsset(string filePath)
    {
        string url = bundleDir + filePath;
        currentItem = new WWWDownloadItem(url, Application.streamingAssetsPath);
        currentItem.StartDownload(DownloadFinish);
    }


    public void GetUpdate(string filePath)
    {
        InfoText.text+= "Get Assets :" + filePath+"\n";
        DownloadAsset(filePath);
    }

  
  
    int count = 0;

    void Update()
    {
        count++;

        if (count % 2 == 0)
        {
            if (currentItem != null && currentItem.isStartDownload)
            {
                InfoText.text +=("Download Process " + currentItem.GetProcess() + "------Downloaded Data ---" + currentItem.GetCurrentLength())+"\n";
            }
        }
    }

    void DownloadFinish()
    {
#if UNITY_EDITOR
       AssetDatabase.Refresh();
#endif
        InfoText.text +=  "Complete ! \n";
        EnableStartButton();
    }


    public Button StartButton;



}
