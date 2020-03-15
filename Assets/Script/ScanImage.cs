using BaiduARUnitySDK;
using UnityEngine;
/// <summary>
/// 扫描图处理类
/// </summary>
public class ScanImage : MonoBehaviour
{
    public GameObject go_Prefab;                 //扫码后所显示的预设体
    private GameObject m_MyProfab = null;        //判定是否已生成预设
    private Transform m_ParentContainer;         //容器 用于存放预设体控制其隐藏
    private BaiduARImageRecognitionResult result; 
    void Start()
    {
        Screen.SetResolution(1080, 1920,true);
        result = GetComponent<BaiduARImageRecognitionResult>();
        result.OnRespond.AddListener(ResultEvent);
        m_ParentContainer = GameObject.Find("Parent").transform; 
    }
    /// <summary>
    /// 识别到识别图之后触发
    /// </summary>
    private void ResultEvent()
    {
        Debug.Log("已识别到识别图");
        for (int i = 0; i < m_ParentContainer.childCount; i++)
        {
            m_ParentContainer.GetChild(i).gameObject.SetActive(false);
            Debug.Log("隐藏容器所有物体");
        }
        if (m_MyProfab == null)
        {
            m_MyProfab = Instantiate(go_Prefab);
            m_MyProfab.transform.SetParent(m_ParentContainer);
            Debug.Log("实例化生成特效，放置在容器下");
        }
        else
        {
            m_MyProfab.gameObject.SetActive(true);
        }
    }
}
