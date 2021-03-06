﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float bulletCooldown;
    private bool isJumping;
    private Rigidbody2D rigid;
    public GameObject smoke;
    public GameObject bullet;
    public Transform firePoint;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        bulletCooldown += Time.deltaTime;
        Move();
        jumpKey();
        ShootKey();
        if(isJumping)
        {
            transform.rotation = Quaternion.Euler(0,0,-100 * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }

    private void Move()
    {
        rigid.velocity = new Vector2(speed * Time.deltaTime, rigid.velocity.y);
    }

    private void jumpKey()
    {
        if(Input.GetKey(KeyCode.Space) && !isJumping)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            isJumping = true;
            smoke.SetActive(true);
        }
    }

    public void JumpButton()
    {
        if(!isJumping)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            isJumping = true;
            smoke.SetActive(true);
        }
    }

    private void ShootKey()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            if(GameController.current.totalBullet > 0 && bulletCooldown > 0.3f)
            {
                Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                GameController.current.SubBullets();
                bulletCooldown = 0f;
            }
        }
    }

    public void ShootButton()
    {
        if(GameController.current.totalBullet > 0 && bulletCooldown > 0.3f)
        {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            GameController.current.SubBullets();
            bulletCooldown = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            smoke.SetActive(false);
        }
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "BossBullet")
        {
            Destroy(gameObject);
            GameController.current.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "BonusBullets")
        {
            GameController.current.AddBullets(5);
            Destroy(collider.gameObject);
        }
        if(collider.gameObject.tag == "GameOver")
        {
            Destroy(gameObject);
            GameController.current.GameOver();
        }
    }
}
