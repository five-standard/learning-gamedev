using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class E_Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HPtext;
    [SerializeField] private TextMeshProUGUI DRtext;
    [SerializeField] private Slider HPSl;
    [SerializeField] private Slider DRSl;
    [SerializeField] private GameObject Missile;

    //체력바, 연료바 초기화
    private void Awake() {
        HPtext.text = "HP (100%)";
        DRtext.text = "Fuel (100%)";
        G_VMng.durability = 100f;
        DRSl.value = 100f;
        StartCoroutine(DurabilityCor()); }

    //1초마다 내구도 차감
    private IEnumerator DurabilityCor() {
        G_VMng.durability--;
        if (G_VMng.durability == 0) {
            SceneManager.LoadScene("End");
            StopCoroutine(DurabilityCor()); }
        DRtext.text = "Fuel (" + G_VMng.durability + "%)";
        DRSl.value = G_VMng.durability;
        yield return new WaitForSeconds((float)0.65);
        StartCoroutine(DurabilityCor()); } 

    //플레이어 이동
    void Update() {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        
        //화면 벽 추가 (플레이어가 화면 밖으로 못 나가게)
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        transform.Translate(new Vector2(X, Y) * (Time.deltaTime * G_VMng.playerSpeed));
        
        //미사일 발사
        if (Input.GetButtonDown("Jump")) {
            GameObject missile = Instantiate(Missile, transform.position, transform.rotation);
            Rigidbody2D rb = missile.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * G_VMng.missileSpeed, ForceMode2D.Impulse); } }
    
    //적 오브젝트, 적 총알 감지
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag.Equals("Enemy") || col.tag.Equals("EnemyBullet")) {
            Destroy(col.gameObject);
            if (G_VMng.hp > 0) {
                G_VMng.hp -= 5;
                if (G_VMng.hp == 0) {
                    SceneManager.LoadScene("End"); 
                    StopCoroutine(DurabilityCor()); }
                HPtext.text = "HP (" + G_VMng.hp + "%)";
                HPSl.value = G_VMng.hp; } } }
}
        
