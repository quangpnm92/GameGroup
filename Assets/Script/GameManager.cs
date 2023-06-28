using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI currentTimerText;
    [SerializeField] TextMeshProUGUI highestTimerText;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        currentTimerText.text = "Score: " + timer.ToString("0.00");
        CheckhighScore();
    }

    void CheckhighScore()
    {
        if (timer > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", timer);
            UpdateHighScore();
        }
    }

    void UpdateHighScore()
    {
        highestTimerText.text = $"HighScore: {PlayerPrefs.GetFloat("HighScore",0).ToString("0.00")}";
    }
}
