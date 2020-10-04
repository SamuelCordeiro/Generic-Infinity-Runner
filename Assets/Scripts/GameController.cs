using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public float scorePerSecond;
    public float scoreUpdated;
    public Text coinText;
    public int coinScore;
    public Text totalBulletText;
    public int totalBullet;
    public GameObject gameOver;
    public Text gameOverScore;
    public Text gameOverCoinScore;
    public bool isPlayerAlive;
    public static GameController current;

    void Start()
    {
        current = this;
        totalBullet = 10;
        isPlayerAlive = true;
    }

    void Update()
    {
        ScoreUpgrade();  
    }
    private void ScoreUpgrade()
    {
        if(isPlayerAlive)
        {
            scoreUpdated += scorePerSecond * Time.deltaTime;
            score = (int)scoreUpdated;
            scoreText.text = score.ToString() + " m";
            coinText.text = coinScore.ToString();
            totalBulletText.text = totalBullet.ToString();
        }
    }

    public void AddScore(float value)
    {
        scoreUpdated += value;
    }

    public void AddCoinScore(int value)
    {
        coinScore += value;
    }

    public void AddBullets(int value)
    {
        totalBullet += value;
    }

    public void SubBullets()
    {
        totalBullet --;
    }
    public void GameOver()
    {
        isPlayerAlive = false;
        gameOver.SetActive(true);
        gameOverScore.text = score.ToString() + " m";
        gameOverCoinScore.text = "x " + coinScore.ToString();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
}
