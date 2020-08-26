using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedEnemy : MonoBehaviour
{
    private bool fire;
    public float speed;
    private float bulletCooldown;
    private Rigidbody2D rigid;
    private Animator anin;
    public Transform firePoint;
    public GameObject bullet;
    private GameObject boss;
    
    void Start()
    {
        fire = false;
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
        bulletCooldown += Time.deltaTime;
        if(fire && bulletCooldown > 2f)
        {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            bulletCooldown = 0f;
        } 
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Bullet")
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
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
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "Player" && GetComponent<CapsuleCollider2D>().enabled == false)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = true;
            fire = true;
        }        
    }
}
