using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownloadHelper : MonoBehaviour
{

    public static DownloadHelper Instance;

    void Awake()
    {
        Instance = this;
    }

    void StartTask(IEnumerator ir)
    {
        StartCoroutine(ir);
    }
}
