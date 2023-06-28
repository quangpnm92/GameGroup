using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class getHighesScore : MonoBehaviour
{
    public Text highestScore;
    void Start()
    {
        highestScore.text = PlayerPrefs.GetFloat("Your Score", 0).ToString("0.00");
    }
}
