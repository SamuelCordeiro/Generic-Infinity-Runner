using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public float scorePerSecond;
    public float scoreUpdated;
    public Text coinText;
    public int coinScore;
    public static GameController current;
    // Start is called before the first frame update
    void Start()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        scoreUpdated += scorePerSecond * Time.deltaTime;
        score = (int)scoreUpdated;
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();
    }

    public void AddScore(float value)
    {
        scoreUpdated += value;
    }

    public void AddCoinScore(int value)
    {
        coinScore += value;
    }
}
