﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombingEnemy : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigid;
    private Animator anin;
    private GameObject boss;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anin = GetComponent<Animator>();
        boss = GameObject.FindGameObjectWithTag("Boss");
        if(boss != null)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, 10f);        
    }

    void Update()
    {
        rigid.velocity = new Vector2(- speed, rigid.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Bullet")
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            anin.SetTrigger("destroy");
            Destroy(collision.gameObject);
            Destroy(gameObject, 0.6f);
        }
        if(collision.gameObject.tag == "Player")
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            anin.SetTrigger("destroy");
            Destroy(collision.gameObject);
            Destroy(gameObject, 0.6f);
            GameController.current.GameOver();
        }
    }
}
