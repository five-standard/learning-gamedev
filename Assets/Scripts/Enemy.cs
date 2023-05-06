using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float launchSpeed = 10.0f;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update () {
        moveControl();
        //프레임이 변화할때 마다 움직임을 관리해주는 함수를 호출해줍시다.
    }
    void moveControl()
    {
        float distanceY = moveSpeed * Time.deltaTime;
        this.gameObject.transform.Translate(0, -1 * distanceY, 0);
    }

    private IEnumerator Shoot()
    {
        GameObject missile = Instantiate(bullet, transform.position, transform.rotation);
        float distanceY = launchSpeed * Time.deltaTime;
        missile.gameObject.transform.Translate(0, -1 * distanceY, 0);
        yield return new WaitForSeconds((float)1.5);
        StartCoroutine(Shoot());
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
