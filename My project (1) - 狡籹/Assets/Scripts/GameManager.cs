using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score;
    public bool IsGameOver;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TMP_Text gameOverScoreText;
    [SerializeField] private TMP_Text gameOverBestScoreText;
    public void AddScore()
    { 
        Score++;
        scoreText.text=Score.ToString();
    }
    public void SetGameOver()
    {
        IsGameOver = true;
        gameOverMenu.SetActive(true);
        int bestScore = PlayerPrefs.GetInt("Best1Score", 0);
        if (bestScore < Score) 
        { 
            bestScore = Score;
            PlayerPrefs.SetInt("Best1Score", bestScore);
        }
        gameOverScoreText.text = "Score : " + Score.ToString();
        gameOverBestScoreText.text= "Best1Score : "+bestScore.ToString();
    }
    public void Retry()
    {
        SceneManager.LoadScene("GamePlay");
    }

}
