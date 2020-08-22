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
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0,18);
        Move();
        jumpKey();
        ShootKey();
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
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(GameController.current.totalBullet > 0)
            {
                Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                GameController.current.SubBullets();
            }
        }
    }

    public void ShootButton()
    {
        if(GameController.current.totalBullet > 0)
        {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            GameController.current.SubBullets();
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

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "BonusBullets")
        {
            GameController.current.AddBullets(10);
            Destroy(collider.gameObject);
        }

        if(collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "GameOver")
        {
            Destroy(gameObject);
            GameController.current.GameOver();
        }
    }
}
