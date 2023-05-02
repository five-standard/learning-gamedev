using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    void Update () {
        moveControl();    
        //프레임이 변화할때 마다 움직임을 관리해주는 함수를 호출해줍시다.
    }
    void moveControl()
    {
        float distanceY = moveSpeed * Time.deltaTime;
        //움직일 거리를 계산해줍니다.
        this.gameObject.transform.Translate(0, -1 * distanceY, 0);
        //움직임을 반영합니다.
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
