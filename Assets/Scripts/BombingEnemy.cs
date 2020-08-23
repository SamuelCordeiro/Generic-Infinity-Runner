using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombingEnemy : MonoBehaviour
{
    //private Transform backPoint;
    private Rigidbody2D rigid;
    private Animator anin;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //backPoint = GameObject.Find("Back Point").GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        anin = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(- speed, rigid.velocity.y);
        /*if(transform.position.x < backPoint.position.x)
        {
            Destroy(gameObject);
        }*/
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
