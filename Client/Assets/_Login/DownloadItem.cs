using System;
using System.IO;

public abstract class DownloadItem
{

    /// <summary>
    /// 网络资源url路径
    /// </summary>
    protected string m_srcUrl;
    /// <summary>
    /// 资源下载存放路径，不包含文件名
    /// </summary>
    protected string m_savePath;
    /// <summary>
    /// 文件名,不包含后缀
    /// </summary>
    protected string m_fileNameWithoutExt;
    /// <summary>
    /// 文件后缀
    /// </summary>
    protected string m_fileExt;
    /// <summary>
    /// 下载文件全路径，路径+文件名+后缀
    /// </summary>
    protected string m_saveFilePath;
    /// <summary>
    /// 原文件大小
    /// </summary>
    protected long m_fileLength;
    /// <summary>
    /// 当前下载好了的大小
    /// </summary>
    protected long m_currentLength;
    /// <summary>
    /// 是否开始下载
    /// </summary>
    protected bool m_isStartDownload;
    public bool isStartDownload
    {
        get
        {
            return m_isStartDownload;
        }
    }

    public DownloadItem(string url, string path)
    {
        m_srcUrl = url;
        m_savePath = path;
        m_isStartDownload = false;
        m_fileNameWithoutExt = Path.GetFileNameWithoutExtension(m_srcUrl);
        m_fileExt = Path.GetExtension(m_srcUrl);
        m_saveFilePath = string.Format("{0}/{1}{2}", m_savePath, m_fileNameWithoutExt, m_fileExt);
    }


    public virtual void StartDownload(Action callback = null)
    {
        if (string.IsNullOrEmpty(m_srcUrl) || string.IsNullOrEmpty(m_savePath))
        {
            return;
        }
    }


    public abstract float GetProcess();


    public abstract long GetCurrentLength();

    
    public abstract long GetLength();

    public abstract void Destroy();
}
