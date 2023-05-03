using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndCode : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    void Start()
    {
        ScoreText.text = "Score : " + Score.score;
    }
}
