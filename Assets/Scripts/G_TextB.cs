using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class G_TextB : MonoBehaviour
{
    private TextMeshProUGUI _textB;
    public static G_TextB G_TextB2;

    private void Awake()
    {
        if(!G_TextB2)
        {
            G_TextB2 = this;
        }
    }

    void Start()
    {
        _textB = GetComponent<TextMeshProUGUI>();
        var textBColor = _textB.color;
        textBColor.a = 0;
        _textB.color = textBColor;
    }

    public IEnumerator TextB()
    {
        var textBColor = _textB.color;
        for (int i = 0; i < 2; i++)
        {
            textBColor.a = 1;
            _textB.color = textBColor;
            yield return new WaitForSeconds(1);
            textBColor.a = 0;
            _textB.color = textBColor;
            yield return new WaitForSeconds(1);
        }
    }
}
