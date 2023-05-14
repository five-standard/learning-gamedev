using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class E_Boss : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    private int bombTime = 0;
    public Slider bossBar;
    public static bool bossMove = false;
    public static bool bossDie = false;
    public static float bossHP = 100f;
    public static E_Boss E_boss;

    private void Awake()
    {
        bombTime = 0;
        if (!E_boss)
        {
            E_boss = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bossMove == true)
        {
            if (!transform.position.Equals(new Vector2(transform.position.x, 3.4f)))
            {
                transform.position = Vector2.MoveTowards(transform.position, (new Vector2(transform.position.x, 3.4f)), 0.05f);
            }
            else
            {
                bossMove = false;
            }
        }
        else if (bossDie == true)
        {
            if (!transform.position.Equals(new Vector2(transform.position.x, 7.5f)))
            {
                transform.position = Vector2.MoveTowards(transform.position, (new Vector2(transform.position.x, 7.5f)), 0.004f);
            }
            else
            {
                bossDie = false;
                Destroy(gameObject);
            }
        }
    }

    public void bossDead()
    {
        bossDie = true;
        StartCoroutine(bossExplosion());
        E_BossSpawn.E_Boss2.bossBar.SetActive(false);
        E_BossSpawn.E_Boss2.bossBt.SetActive(false);
        G_Score.level++;
        G_Score.score=0;
        G_Spawn.enemy_Spawn -= 0.15f;
        if (G_Score.level %3 == 0)
        {
            G_Spawn.spNum++; 
        }
        Invoke("BossEnd", 5);
    }
    
    private IEnumerator bossExplosion() {
        Instantiate(explosion, (new Vector2(Random.Range(2.5f, -2.5f), transform.position.y+2)), Quaternion.identity);
        yield return new WaitForSeconds(1);
        if (bombTime < 5)
        {
            bombTime++;
            StartCoroutine(bossExplosion());
        } 
    }

    private void BossEnd()
    {
        E_BossSpawn.BossSpawned = false;
    }
}
