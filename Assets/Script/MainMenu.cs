using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// MainMenu场景的UI事件
/// </summary>
public class MainMenu : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int index = i;
            transform.GetChild(i).GetComponent<Button>().onClick.AddListener(() =>
            { 
                JumpScene(index + 1);
            });
        }
    }

    /// <summary>
    /// 事件：跳转场景
    /// </summary>
    private void JumpScene(int sceneIndexNum)
    {
        Debug.Log(sceneIndexNum);
        SceneManager.LoadScene(sceneIndexNum);
    }
}
