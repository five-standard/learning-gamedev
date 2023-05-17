using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_BBullet : MonoBehaviour
{
    void Update()
    {
        if (E_Boss.Wpt == "Rotate" || E_Boss.Wpt == "Random")
        {
            transform.Translate(transform.right * (Time.deltaTime * 15));
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
