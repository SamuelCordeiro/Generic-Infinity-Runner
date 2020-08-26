using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anin;
    public float speed;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anin = GetComponent<Animator>();
    }

    void Update()
    {
        rigid.velocity = new Vector2(- speed, 0.3f);
    }
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "Bullet")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            anin.SetTrigger("destroy");
            Destroy(collider.gameObject);
            Destroy(gameObject, 0.6f);
        }
        if(collider.gameObject.tag == "Player")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            Destroy(collider.gameObject);
            Destroy(gameObject, 0.6f);
            GameController.current.GameOver();
        }
    }
    private void OnTriggerStay2D(Collider2D collider) 
    {
        if(collider.gameObject.layer == 8)
        {
            rigid.velocity = new Vector2(rigid.velocity.x , rigid.velocity.y + 50f);
        }        
    }
}
