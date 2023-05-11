using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class E_Bullet : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject FuelUp;
    [SerializeField] private int ItemSpawn;

    private void Awake() {
        ItemSpawn = Random.Range(1, 100); }

    //화면 밖으로 나가면 삭제
    private void OnBecameInvisible() {
        Destroy(gameObject); }

    //적하고 닿으면 적과 자기 자신 제거
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag.Equals("Enemy")) {
            Instantiate(explosion, col.transform.position, Quaternion.identity);
            if(ItemSpawn >= 70) {
                Instantiate(FuelUp, col.transform.position, Quaternion.identity); }
            Destroy(col.gameObject);
            Destroy(gameObject);
            G_Score.instance.addscore(G_Score.scoreToAdd); } }
}
