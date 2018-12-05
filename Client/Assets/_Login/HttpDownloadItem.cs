using System;
using System.Collections;
using System.IO;
using UnityEngine;

/// <summary>
/// WWW的方式下载
/// </summary>
public class WWWDownloadItem : DownloadItem
{

    WWW m_www;

    public WWWDownloadItem(string url, string path) : base(url, path)
    {

    }

    public override void StartDownload(Action callback = null)
    {
        base.StartDownload();
        DownloadHelper.Instance.StartCoroutine(Download(callback));
    }

    IEnumerator Download(Action callback = null)
    {
        m_www = new WWW(m_srcUrl);
        m_isStartDownload = true;
        yield return m_www;
        m_isStartDownload = false;

        if (m_www.isDone)
        {
            byte[] bytes = m_www.bytes;

            Debug.Log("Unzip File :" +m_fileNameWithoutExt);
            if (Directory.Exists(CheckResources.AssetFolder))
            {
                Directory.Delete(CheckResources.AssetFolder,true);
            }

            ZipUtility.UnzipFile(bytes, CheckResources.AssetFolder);

            if (callback != null)
            {
                callback();
            }
        }
        else
        {
            Debug.Log("Download Error:" + m_www.error);
        }

        if (callback != null)
        {
            callback();
        }
    }

    public override float GetProcess()
    {
        if (m_www != null)
        {
            return m_www.progress;
        }
        return 0;
    }

    public override long GetCurrentLength()
    {
        if (m_www != null)
        {
            return m_www.bytesDownloaded;
        }
        return 0;
    }

    public override long GetLength()
    {
        return 0;
    }

    public override void Destroy()
    {
        if (m_www != null)
        {
            m_www.Dispose();
            m_www = null;
        }
    }
}
