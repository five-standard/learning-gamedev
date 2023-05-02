using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] public TextMeshProUGUI Scoretext;
    [SerializeField] private int score = 0;

    void Awake()
    {
        if (!instance)
            instance = this;
    }

    private void Start()
    {
        Scoretext.text = "0 Score";
    }

    public void addscore(int num)
    {
        score += num;
        Scoretext.text = score + " Score";
    }
}
