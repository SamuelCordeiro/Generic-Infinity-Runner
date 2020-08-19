using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncontrolledEnemy : MonoBehaviour
{
    private Transform backPoint;
    private Rigidbody2D rigid;
    private Animator anin;
    public float speedX;
    public float speedY;
    // Start is called before the first frame update
    void Start()
    {
        backPoint = GameObject.Find("Back Point").GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        anin = GetComponent<Animator>();        
    }
    private bool rideUp;
    // Update is called once per frame
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
            rideUp = true;
        }       
    }
}
