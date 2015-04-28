using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTrack : MonoBehaviour
{
    static public ScoreTrack Instance;

    Text scoreText;
    int score = 0;

	void Awake()
    {
        Instance = this;
        scoreText = GetComponent<Text>();
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "SCORE: " + score.ToString();
    }
}
