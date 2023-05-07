using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float launchSpeed = 12.0f;
    [SerializeField] private int RorL;

    void Awake()
    {
        RorL = Random.Range(0, 2);
    }
    void Update()
    {
        movecontrol();
    }

    void movecontrol()
    {
        float distanceX = launchSpeed * Time.deltaTime;
        if (RorL == 0)
        {
            this.gameObject.transform.Translate(1 * distanceX, 0, 0);
        }
        else
        {
            this.gameObject.transform.Translate(-1 * distanceX, 0, 0);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
