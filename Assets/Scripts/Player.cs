using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool isJumping;
    private Rigidbody2D rigid;
    public GameObject smoke;
    public GameObject bullet;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Speed up
        speed += 000.10f;
        // moviment
        rigid.velocity = new Vector2(speed * Time.deltaTime, rigid.velocity.y);
        // jump
        if(Input.GetKey(KeyCode.Space) && !isJumping)
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
            smoke.SetActive(true);
        }
        //fire
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            smoke.SetActive(false);
        }
    }
}
