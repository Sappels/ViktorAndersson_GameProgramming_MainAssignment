using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;

    private static Score instance;
    public static Score Instance { get { return instance; } }

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScoreToSessionScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
        SaveManager.Instance.Save(score.ToString());
    }
}
