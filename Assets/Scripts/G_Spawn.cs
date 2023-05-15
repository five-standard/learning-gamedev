using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class G_Spawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public static float enemy_Spawn = 1.0f; //여기부터 시간
    public static int spNum = 1;
    public static G_Spawn G_Spawn2;

    //적, 특수적, 스폰 코루틴 시작
    void Awake()
    {
        if (!G_Spawn2)
        {
            G_Spawn2 = this;
        }
    }

    private void Start()
    {
        spNum = 1;
        StartCoroutine(SpawnEnemy());
    }

    //적 코루틴
    IEnumerator SpawnEnemy()
    {
        if (E_BossSpawn.BossSpawned == false)
        {
            for (int i = 0; i < spNum; i++)
            {
                Instantiate(enemy, new Vector2(Random.Range(-8.41f, 8.41f), 5.55f), Quaternion.identity);
            }
        }
        yield return new WaitForSeconds(enemy_Spawn);
        StartCoroutine(SpawnEnemy());
    }
}
