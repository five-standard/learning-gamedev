using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] public TextMeshProUGUI Scoretext;
    public static float score;

    void Awake()
    {
        if (!instance)
            instance = this;
    }

    private void Start()
    {
        score = 0;
        Scoretext.text = "0 Score";
    }

    public void addscore(int num)
    {
        score += num;
        Scoretext.text = score + " Score";
    }
}
