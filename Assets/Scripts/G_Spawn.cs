using System.Collections;
using UnityEngine;

public class G_Spawn : MonoBehaviour
{
    //게임오브젝트 설정
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject senemy;
    [SerializeField] private GameObject boss;
    
    //적, 특수적, 스폰 코루틴 시작
    void Awake() {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnSenemy()); }
    
    //적 코루틴
    private IEnumerator SpawnEnemy() {
        Instantiate(enemy, new Vector2(Random.Range(-8.41f, 8.41f), 5.55f), Quaternion.identity);
        yield return new WaitForSeconds(G_VMng.enemy_Spawn);
        StartCoroutine(SpawnEnemy()); }

    //특수적 코루틴
    private IEnumerator SpawnSenemy() {
        yield return new WaitForSeconds(G_VMng.senemy_Spawn); }
}
