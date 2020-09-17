using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupedEnemy : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigid;
    private Animator anin;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anin = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        rigid.velocity = new Vector2(-speed, rigid.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "Bullet")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            anin.SetTrigger("destroy");
            Destroy(collider.gameObject);
            Destroy(gameObject, 0.6f);
        }
        if(collider.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(collider.gameObject);
            Destroy(gameObject, 0.6f);
            GameController.current.GameOver();
        }
        if(collider.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
}
