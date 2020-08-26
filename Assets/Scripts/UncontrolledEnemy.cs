using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncontrolledEnemy : MonoBehaviour
{
    private bool rideUp;
    private Rigidbody2D rigid;
    private Animator anin;
    public float speedX;
    public float speedY;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anin = GetComponent<Animator>();        
    }
    void Update()
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
            rigid.velocity = new Vector2(- speedX, speedY);
        }
        else
        {
            rigid.velocity = new Vector2(- speedX, - speedY);
        }     
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
            anin.SetTrigger("destroy");
            Destroy(collider.gameObject);
            Destroy(gameObject, 0.6f);
            GameController.current.GameOver();
        }
        if(collider.gameObject.layer == 8)
        {
            rideUp = true;
        }       
    }
}
