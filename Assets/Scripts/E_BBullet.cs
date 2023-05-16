using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_BBullet : MonoBehaviour
{
    void Update()
    {
        transform.position = transform.forward;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
