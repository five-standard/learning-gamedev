using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class E_Player : MonoBehaviour 
{
    [SerializeField] private Slider HPSl;
    [SerializeField] private Slider DRSl;
    [SerializeField] private GameObject Missile;
    [SerializeField] public float missileSpeed = 10.0f;
    [SerializeField] public float playerSpeed = 10.0f;
    [SerializeField] public float hp = 100f;
    [SerializeField] public float durability = 100f;
    [SerializeField] private float durabadd = 10;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject explosion;

    //체력바, 연료바 초기화
    private void Awake() 
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        durability = 100f;
        DRSl.value = 100f;
        StartCoroutine(DurabilityCor()); 
    }

    //1초마다 내구도 차감
    private IEnumerator DurabilityCor() 
    {
        if (E_BossSpawn.BossSpawned == false)
        {
            durability -= 2.5f;
            if (durability == 0) 
            {
                SceneManager.LoadScene("End");
                StopCoroutine(DurabilityCor()); 
            }
            DRSl.value = durability;
            yield return new WaitForSeconds((float)0.65);
            StartCoroutine(DurabilityCor()); 
        }
    } 

    //플레이어 이동
    void Update() {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("X", X);
        
        //화면 벽 추가 (플레이어가 화면 밖으로 못 나가게)
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        transform.Translate(new Vector2(X, Y) * (Time.deltaTime * playerSpeed));
        
        //미사일 발사
        if (Input.GetButtonDown("Jump")) {
            GameObject missile = Instantiate(Missile, transform.position, transform.rotation);
            Rigidbody2D rb = missile.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * missileSpeed, ForceMode2D.Impulse); } }
    
    //적 오브젝트, 적 총알 감지
    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.tag.Equals("Enemy") || col.tag.Equals("EnemyBullet")) 
        {
            Instantiate(explosion, col.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            if (hp > 0) 
            {
                hp -= 5;
                if (hp == 0) 
                {
                    SceneManager.LoadScene("End"); 
                    StopCoroutine(DurabilityCor()); 
                }
                HPSl.value = hp; 
            } 
        }
        else if (col.tag.Equals("Fuel")) 
        {
            Destroy(col.gameObject);
            durability += durabadd;
            if (durability >= 101) 
            {
                durability = 100; 
            } 
            DRSl.value = durability;
        } 
    } 
}
        
