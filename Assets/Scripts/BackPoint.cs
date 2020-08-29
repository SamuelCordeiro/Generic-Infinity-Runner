using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPoint : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject, 5f);
        }
        if(collision.gameObject.tag == "GroundEnemy" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "SkyEnemy" || collider.gameObject.tag == "Coin" || collider.gameObject.tag == "BonusBullets")
        {
            Destroy(collider.gameObject);
        }
    }
}
