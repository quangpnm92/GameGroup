using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class getHighesScore : MonoBehaviour
{
    public Text highestScore;
    public Text currentScore;
    void Start()
    {
        highestScore.text = GameManager.getHighestTimer().ToString("0.00");
        currentScore.text = GameManager.getCurrentTimer().ToString("0.00");
    }
}
