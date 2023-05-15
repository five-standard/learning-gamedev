using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_BBullet : MonoBehaviour
{
    private int enemySpeed = 10;
    void Update()
    {
        moveControl();
    }
    
    void moveControl() 
    { 
        float distanceY = enemySpeed * Time.deltaTime;
        gameObject.transform.Translate(0, -1 * distanceY, 0); 
    }
}
