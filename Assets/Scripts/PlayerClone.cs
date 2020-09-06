using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClone : MonoBehaviour
{
    private bool rideUp;
    private bool fire;
    private Rigidbody2D rigid;
    private Animator anin;
    private int life;
    public float speedX;
    public float speedY;
    private float playerDistance;
    private float bulletCooldown;
    public Transform firePoint;
    public GameObject smoke;
    public GameObject bullet;
    private GameObject player;
    void Start()
    {
        life = 2;
        fire = false;
        speedX = 0f;
        rigid = GetComponent<Rigidbody2D>();
        anin = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");        
    }

    void Update()
    {
        StartMovement();
        Movement();
        Fire();     
    }

    private void StartMovement()
    {
        if(player != null)
        {
            playerDistance = player.transform.position.x;
            if(transform.position.x - playerDistance <= 15.5f)
            {
                speedX = 6.2f;
            }
        }
    }
    private void Movement()
    {
        if(transform.position.y >= 2f)
        {
            rideUp = false;
        }
        else if(transform.position.y <= -2f)
        {
            rideUp = true;
        } 
        if(rideUp)
        {
            rigid.velocity = new Vector2(speedX, speedY);
        }
        else
        {
            rigid.velocity = new Vector2(speedX, - speedY);
        }
    }
    private void Fire()
    {
        bulletCooldown += Time.deltaTime;
        if(fire && bulletCooldown > 2f)
        {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            bulletCooldown = 0f;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "Bullet")
        {
            if(life > 0)
            {
                life--;
            }
            else
            {
                GetComponent<CapsuleCollider2D>().enabled = false;
                smoke.SetActive(false);
                anin.SetTrigger("destroy");
                Destroy(collider.gameObject);
                Destroy(gameObject, 0.6f);
            }
        }     
    }
    private void OnTriggerStay2D(Collider2D collider) 
    {
        if(collider.gameObject.layer == 8)
        {
            rideUp = true;
            rigid.velocity = new Vector2(rigid.velocity.x , rigid.velocity.y + 50f);
            smoke.SetActive(false);
        }
        if(collider.gameObject.tag == "Player")
        {
            fire = true;
        }        
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if(collider.gameObject.layer == 8)
        {
            smoke.SetActive(false);
        }
        if(collider.gameObject.tag == "Player")
        {
            fire = false;
        }
    }
}