using System;
using UnityEngine;

public class E_BossSpawn : MonoBehaviour 
{
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject bosstext;
    [SerializeField] public GameObject bossBar;
    [SerializeField] public GameObject bossBt;
    public static bool BossSpawned = false;
    public static E_BossSpawn E_Boss2;

    //자기 자신을 참조
    void Awake() 
    {
        bossBar.SetActive(false);
        bossBt.SetActive(false);
        if (!E_Boss2)
            E_Boss2 = this; 
    }

    //보스 경고메세지
    public void BossWarning() 
    {
        BossSpawned = true;
        StartCoroutine(G_TextB.G_TextB2.TextB());
        Invoke("BossSpawn", 4.0f);
    }

    //보스 스폰
    private void BossSpawn()
    {
        bossBar.SetActive(true);
        bossBt.SetActive(true);
        Instantiate(boss, new Vector2(0, 7.3f), Quaternion.identity);
        E_Boss.bossMove = true;
        G_Score.maxscore += 50;
        G_Score.scoreToAdd += 10;
    }
}

