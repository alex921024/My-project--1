using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneload : MonoBehaviour
{
    public void DifficultChange1()
    {
        // 清除遊戲一的最高分記錄
        PlayerPrefs.DeleteKey("BestScore");

        // 清除遊戲二的最高分記錄
        PlayerPrefs.DeleteKey("Best1Score");

        // 加載場景1（遊戲一的難易度選擇頁面）
        SceneManager.LoadScene(1);
    }
    public void DifficultChange2()
    {
        // 加載場景2（遊戲二的難易度選擇頁面）
        SceneManager.LoadScene(2);
    }
    public void LoadNextScene1_1()
    {
        // 加載場景3（遊戲一簡單的實際遊戲頁面）
        SceneManager.LoadScene(3);
    }
    public void LoadNextScene1_2()
    {
        // 加載場景4（遊戲一普通的實際遊戲頁面）
        SceneManager.LoadScene(4);
    }
    public void LoadNextScene1_3()
    {
        // 加載場景5（遊戲一困難的實際遊戲頁面）
        SceneManager.LoadScene(5);
    }
    public void LoadNextScene2_1()
    {
        // 加載場景4（遊戲二簡單的實際遊戲頁面）
        SceneManager.LoadScene(6);
    }
    public void LoadNextScene2_2()
    {
        // 加載場景4（遊戲二簡單的實際遊戲頁面）
        SceneManager.LoadScene(7);
    }
    public void LoadNextScene2_3()
    {
        // 加載場景4（遊戲二簡單的實際遊戲頁面）
        SceneManager.LoadScene(8);
    }
    public void home()
    {
        // 加載場景0（首頁）
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        // 退出應用程式
        Application.Quit();
    }
}
