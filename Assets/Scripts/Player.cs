using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private float launchSpeed = 10.0f;
    [SerializeField] private Slider HPSl;
    public static float hp = 100f;
    [SerializeField] TextMeshProUGUI HPtext;
    [SerializeField] private float durability = 100f;
    [SerializeField] private Slider DRSl;
    [SerializeField] private TextMeshProUGUI DRtext;
    private void Start()
    {
        HPtext.text = "HP (100%)";
        DRtext.text = "Fuel (100%)";
        StartCoroutine(DurabilityCor());
        //while (durability > 0)
        //{
        //Thread.Sleep(1000);
        //durability--;
        //DRtext.text = "Durability (" + durability + "%)";
        //DRSl.value = durability;
        //}
    }

    IEnumerator DurabilityCor()
    {
        durability--;
        if (durability == 0)
        {
            SceneManager.LoadScene("End");
        }
        DRtext.text = "Fuel (" + durability + "%)";
        DRSl.value = durability;
        yield return new WaitForSeconds((float)0.65);
        StartCoroutine(DurabilityCor());
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
            GameObject missile = Instantiate(missilePrefab, transform.position, transform.rotation);
            Rigidbody2D rb = missile.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * launchSpeed, ForceMode2D.Impulse);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Enemy") || col.tag.Equals("EnemyBullet"))
        {
            Destroy(col.gameObject);
            if (hp > 0)
            {
                hp -= 5;
                if (hp == 0)
                {
                    SceneManager.LoadScene("End");
                }
                HPtext.text = "HP (" + hp + "%)";
                HPSl.value = hp;
            }
        }

    }
    
}
        
