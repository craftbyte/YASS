using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHelper : MonoBehaviour
{
    public static ScoreHelper Instance;

    private int score = 0;
    public GameObject DisplayElement;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of ScoreHelper!");
        }
        Instance = this;
    }
    void Start() {
        DisplayElement.GetComponent<Text>().text = score.ToString("0000000");
    }
    public void AddScore(int increment) {
        score += increment;
        PlayerConfig.Score = score;
        DisplayElement.GetComponent<Text>().text = score.ToString("0000000");
    }
}
