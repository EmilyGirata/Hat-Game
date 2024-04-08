using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score2 : MonoBehaviour
{
    public Text scoreText;
    public int ballValue;
    public int ballValue2;

    private int score;


    void Start()
    {
        score = 0;
        UpdateScore();
    }

    void OnTriggerEnter2D()
    {
        score += ballValue;
        score -= ballValue;
        score += ballValue2;
        UpdateScore();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bowl2")
        {
            score += ballValue;
            UpdateScore();
        }

        else if (collision.gameObject.tag == "Bomb2")
        {
            score -= ballValue;
            UpdateScore();
        }

        else if (collision.gameObject.tag == "Bowl3")
        {
            score += ballValue2;
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score:\n" + score;

    }
}
