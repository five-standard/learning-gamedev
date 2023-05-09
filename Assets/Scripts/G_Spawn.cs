using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class G_Spawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject senemy;
    [SerializeField] public float enemy_Spawn = 1.5f; //여기부터 시간
    [SerializeField] public float senemy_Spawn = 5f;
    public static G_Spawn G_Spawn2;

    //적, 특수적, 스폰 코루틴 시작
    void Awake() {
        if (!G_Spawn2) {
            G_Spawn2 = this; }
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnSenemy()); }
    
    //적 코루틴
    public IEnumerator SpawnEnemy() {
        if (E_Boss.BossSpawned == false) {
            Instantiate(enemy, new Vector2(Random.Range(-8.41f, 8.41f), 5.55f), Quaternion.identity);
            yield return new WaitForSeconds(enemy_Spawn);
            StartCoroutine(SpawnEnemy()); } }

        //특수적 코루틴
    public IEnumerator SpawnSenemy() {
        yield return new WaitForSeconds(senemy_Spawn); }
}
