using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highscoreText;
    public GameObject gameOverScreen;
    
    private bool birdAlive = true;

    private void Start() {
        highscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd) {
        if (!birdAlive)
            return;
        
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver() {
        birdAlive = false;

        if (playerScore > PlayerPrefs.GetInt("Highscore")) {
            PlayerPrefs.SetInt("Highscore", playerScore);
            highscoreText.text = playerScore.ToString();
        }

        gameOverScreen.SetActive(true);
    }

    public bool IsBirdAlive() {
        return birdAlive;
    }
}
