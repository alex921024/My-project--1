using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneload : MonoBehaviour
{
    public void DifficultChange1()
    {
        // �M���C���@���̰����O��
        PlayerPrefs.DeleteKey("BestScore");

        // �M���C���G���̰����O��
        PlayerPrefs.DeleteKey("Best1Score");

        // �[������1�]�C���@�������׿�ܭ����^
        SceneManager.LoadScene(1);
    }
    public void DifficultChange2()
    {
        // �[������2�]�C���G�������׿�ܭ����^
        SceneManager.LoadScene(2);
    }
    public void LoadNextScene1_1()
    {
        // �[������3�]�C���@²�檺��ڹC�������^
        SceneManager.LoadScene(3);
    }
    public void LoadNextScene1_2()
    {
        // �[������4�]�C���@���q����ڹC�������^
        SceneManager.LoadScene(4);
    }
    public void LoadNextScene1_3()
    {
        // �[������5�]�C���@�x������ڹC�������^
        SceneManager.LoadScene(5);
    }
    public void LoadNextScene2_1()
    {
        // �[������4�]�C���G²�檺��ڹC�������^
        SceneManager.LoadScene(6);
    }
    public void LoadNextScene2_2()
    {
        // �[������4�]�C���G²�檺��ڹC�������^
        SceneManager.LoadScene(7);
    }
    public void LoadNextScene2_3()
    {
        // �[������4�]�C���G²�檺��ڹC�������^
        SceneManager.LoadScene(8);
    }
    public void home()
    {
        // �[������0�]�����^
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        // �h�X���ε{��
        Application.Quit();
    }
}
