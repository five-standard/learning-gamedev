using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
 //ㅆ
public class Player : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private float launchSpeed = 10.0f;
    [SerializeField] private Slider HPSl;
    [SerializeField] private float hp = 100f;
    [SerializeField] TextMeshProUGUI HPtext;
    [SerializeField] private float durability = 100f;
    [SerializeField] private Slider DRSl;
    [SerializeField] private TextMeshProUGUI DRtext;
    private void Start()
    {
        HPtext.text = "HP (100%)";
        DRtext.text = "Durability (100%)";
        //while (durability > 0)
        //{
            //Thread.Sleep(1000);
            //durability--;
            //DRtext.text = "Durability (" + durability + "%)";
            //DRSl.value = durability;
        //}
    }

    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        
        transform.Translate(new Vector2(X, Y) * (Time.deltaTime * Speed));

        if (Input.GetButtonDown("Jump"))
        {
            // 프리팹으로부터 새로운 미사일 게임 오브젝트 생성
            GameObject missile = Instantiate(missilePrefab, transform.position, transform.rotation);

            // 미사일로부터 리지드바디 2D 컴포넌트 가져옴
            Rigidbody2D rb = missile.GetComponent<Rigidbody2D>();

            // 미사일을 전방으로 발사
            rb.AddForce(transform.up * launchSpeed, ForceMode2D.Impulse);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Enemy"))
        {
            Destroy(col.gameObject);
            if (hp > 0)
            {
                hp -= 5;
                if (hp == 0)
                {
                    SceneManager.LoadScene("None");
                }
                HPtext.text = "HP (" + hp + "%)";
                HPSl.value = hp;
            }
        }

    }
    
}
        
