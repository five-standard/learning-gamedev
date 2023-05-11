using UnityEngine;

public class E_Boss : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    public static bool BossSpawned = false;
    public static E_Boss E_Boss2;
    
    //자기 자신을 참조
    void Awake() {
        if (!E_Boss2)
            E_Boss2 = this; }
    
    public void SpawnBoss() {
        Instantiate(boss, new Vector2(0, 3.5f), Quaternion.identity);
        G_Score.maxscore += 100;
        G_Score.scoreToAdd += 20;
        BossSpawned = true;
    }
}
