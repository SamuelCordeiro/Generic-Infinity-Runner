using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    private Transform backPoint;
    private Rigidbody2D rigid;
    private Animator anin;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        backPoint = GameObject.Find("Back Point").GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        anin = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(- speed, rigid.velocity.y);
        if(transform.position.x < backPoint.position.x)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "Bullet")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            anin.SetTrigger("destroy");
            Destroy(gameObject, 0.6f);
        }
        if(collider.gameObject.layer == 8)
        {
            rigid.velocity = new Vector2(- speed, rigid.velocity.y + 1f);
        }        
    }
}
