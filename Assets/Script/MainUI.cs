using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainUI : MonoBehaviour
{
    public GameObject go_PanelWarning;
    public Text txt_Warning;
    public GameObject go_PanelLoading;
    public Button btn_Yes;

    public BaiduARImageRecognition scr_imgRecognition;
    public BaiduARWebCamera scr_webCamera;
    // Use this for initialization
    void Start()
    {
        btn_Yes.onClick.AddListener(() =>  Application.Quit());
        scr_imgRecognition.OnErrorEvent.AddListener(ShowWarningHint);
        go_PanelLoading.SetActive(true);
        go_PanelWarning.SetActive(false);
    }
    private void Update()
    {
        //判断手机摄像机是否已启动
        if (scr_webCamera.isLoad)
        {
            go_PanelLoading.SetActive(false); 
        }
    }

    /// <summary>
    /// 事件：id或密钥错误时调用
    /// </summary>
    private void ShowWarningHint(string num,string msg)
    {
        go_PanelWarning.SetActive(true);
        txt_Warning.text = "num:" + num + ",msg:" + msg;
    }
}
