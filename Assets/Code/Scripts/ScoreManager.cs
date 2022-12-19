using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private int score;

    private void Awake()
    {
        instance = this;
    }

    public int GetScore() => score;

    public void AddScore(int points = 10)
    {
        score += points;
    }
    public void ReduceScore(int points = 5)
    {
        score -= points;
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("highScore");
    }
    public void SetScore()
    {
        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
