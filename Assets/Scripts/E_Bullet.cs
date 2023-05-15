using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class E_Bullet : MonoBehaviour 
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject FuelUp;
    [SerializeField] private int ItemSpawn;

    private void Awake() 
    {
        ItemSpawn = Random.Range(1, 100); 
    }

    //화면 밖으로 나가면 삭제
    private void OnBecameInvisible() 
    {
        Destroy(gameObject); 
    }

    //적하고 닿으면 적과 자기 자신 제거
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.tag.Equals("Enemy")) 
        {
            Instantiate(explosion, col.transform.position, Quaternion.identity);
            if(ItemSpawn >= 70) 
            {
                Instantiate(FuelUp, col.transform.position, Quaternion.identity); 
            }
            Destroy(col.gameObject);
            Destroy(gameObject);
            G_Score.instance.addscore(G_Score.scoreToAdd); 
        } 
        else if (col.tag.Equals("Boss"))
        {
            Destroy(gameObject);
            if (E_Boss.bossDie == false)
            {
                E_Boss.bossHP -= Random.Range(1, 9);
                E_BossSpawn.E_Boss2.BossBar.value = E_Boss.bossHP;
                Instantiate(explosion, transform.position, Quaternion.identity);
                if (E_Boss.bossHP <= 0)
                {
                    E_Boss.E_boss.bossDead();
                }
            }
        }
        else if (col.tag.Equals("EnemyBullet"))
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    } 
}
