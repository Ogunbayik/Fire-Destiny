using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI scoreText;

    private int currentScore;

    private int addScorePoint = 10;

    private void OnEnable()
    {
        Enemy.OnTriggerEnemy += AddScore;
    }

    private void OnDisable()
    {
        Enemy.OnTriggerEnemy -= AddScore;
    }
    void Start()
    {
        currentScore = 0;

        scoreText.text = "SCORE: " + currentScore;
    }
    private void AddScore(int score)
    {
        score = addScorePoint;

        currentScore += score;
        scoreText.text = "SCORE: " + currentScore;
    }
}
