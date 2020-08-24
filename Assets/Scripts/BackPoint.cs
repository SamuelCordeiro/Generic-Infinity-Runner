using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPoint : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject, 5f);
        }
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "Coin" || collider.gameObject.tag == "BonusBullets")
        {
            Destroy(collider.gameObject);
        }
    }
}
