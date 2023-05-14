using System;
using UnityEngine;

public class E_Enemy : MonoBehaviour 
{
    public static float enemySpeed = 7;
    [SerializeField] private GameObject explosion;

    //화면에 움직임 반영
    void Update () 
    {
        moveControl();
        if (E_BossSpawn.BossSpawned == true)
        {
            if (this.gameObject.name == "Enemy(Clone)")
            {
                Explode();
            }
        }
    }
    
    //화면 밖으로 나가면 삭제
    private void OnBecameInvisible() 
    {
        Destroy(gameObject); 
    }
    
    //이동 제어 (아래로 향함)
    void moveControl() 
    {
        float distanceY = enemySpeed * Time.deltaTime;
        gameObject.transform.Translate(0, -1 * distanceY, 0); 
    }
    
    public void Explode() 
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject); 
    } 
}
