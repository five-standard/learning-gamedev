using System.Collections;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

public class E_Boss : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject healItem;
    [SerializeField] private GameObject bullet;
    private int itemSummon = 0;
    private int bombTime = 0;
    public static bool bossMove = false;
    public static bool bossDie = false;
    public static float bossHP = 100f;
    public static E_Boss E_boss;
    public static int Pattern = 0;
    public static int cnt = 0;
    public static int Rotation = -75;
    
    private void Awake()
    {
        bombTime = 0;
        bossHP = 100f;
        //bossBar.value = 100f;
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
                transform.position = Vector2.MoveTowards(transform.position, (new Vector2(transform.position.x, 3.4f)), 0.01f);
            }
            else
            {
                StartCoroutine(bossPattern());
                bossMove = false;
            }
        }
        else if (bossDie == true)
        {
            if (!transform.position.Equals(new Vector2(transform.position.x, 7.5f)))
            {
                transform.position = Vector2.MoveTowards(transform.position, (new Vector2(transform.position.x, 7.5f)), 0.01f);
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
        StopCoroutine(bossPattern());
        bossDie = true;
        StartCoroutine(bossExplosion());
        E_BossSpawn.E_Boss2.bossBar.SetActive(false);
        E_BossSpawn.E_Boss2.bossBt.SetActive(false);
        bossHP += 10;
        G_Score.level++;
        G_Score.score=0;
        G_Spawn.enemy_Spawn -= 0.05f;
        itemSummon = Random.Range(1, 101);
        if (itemSummon > 50)
        {
            Instantiate(healItem, transform.position, Quaternion.identity);
        }
        if (G_Score.level %5 == 0)
        {
            G_Spawn.spNum++; 
        }

        if (G_Score.level % 3 == 0)
        {
            G_Score.scoreToAdd += 5;
        }
        Invoke(nameof(BossEnd), 0.05f);
    }
    
    private IEnumerator bossExplosion() {
        Instantiate(explosion, (new Vector2(Random.Range(2.5f, -2.5f), transform.position.y+2)), Quaternion.identity);
        yield return new WaitForSeconds(1);
        if (bombTime < 4)
        {
            bombTime++;
            StartCoroutine(bossExplosion());
        } 
    }

    private void BossEnd()
    {
        G_Score.instance.Scoretext.text = "Score 0";
        G_Score.instance.Leveltext.text = "Level " + G_Score.level; 
        E_BossSpawn.BossSpawned = false;
    }

    //보스 패턴 부분
    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator bossPattern()
    {
        {
            cnt = 0;
            Pattern = Random.Range(1, 2);
            switch (Pattern)
            {
                case 0:
                    StartCoroutine(fireShoot());
                    StopCoroutine(bossPattern());
                    break;
            
                case 1:
                    StartCoroutine(fireRotate());
                    StopCoroutine(bossPattern());
                    break;
            
                case 2:
                    
                    StopCoroutine(bossPattern());
                    break;
            
                case 3:
                    
                    StopCoroutine(bossPattern());
                    break;
            
                case 4:
                    
                    StopCoroutine(bossPattern());
                    break;
            
                case 5:
                    
                    StopCoroutine(bossPattern());
                    break;
            }
            yield return new WaitForSeconds(1.5f);
        }
    }

    private IEnumerator fireShoot()
    {
        GameObject Bullet = Instantiate(bullet, transform.position, quaternion.identity);
        Rigidbody2D rigid = Bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.down*5, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        if (cnt < 5)
        {
            cnt++;
            StartCoroutine(fireShoot());
        }
        else
        {
            StartCoroutine(bossPattern());
        }
    }

    private IEnumerator fireRotate()
    { 
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, Rotation));
        Rotation -= 5;
        yield return new WaitForSeconds(0.15f);
        if (cnt < 100)
        {
            cnt++;
            StartCoroutine(fireRotate());
        }
        else
        {
            Rotation = -75;
            StartCoroutine(bossPattern());
        }
    }
}
