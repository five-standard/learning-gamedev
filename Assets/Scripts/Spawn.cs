using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float times;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        Instantiate(enemy, new Vector2(Random.Range(-8.41f, 8.41f), 5.55f), Quaternion.identity);
        yield return new WaitForSeconds(times);
        StartCoroutine(SpawnEnemy());
    }
}
