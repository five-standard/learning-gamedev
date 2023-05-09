using UnityEngine;

public class G_VMng : MonoBehaviour
{
    //점수 상수
    public static G_Score instance;
    public static float score = 0;

    //스폰
    public static float enemy_Spawn = 1.5f; //여기부터 시간
    public static float senemy_Spawn = 5f;
    
    //적
    public static float enemySpeed = 7;
    
    //플레이어
    public static float missileSpeed = 10.0f;
    public static float playerSpeed = 10.0f;
    public static float hp = 100f;
    public static float durability = 100f;
}
