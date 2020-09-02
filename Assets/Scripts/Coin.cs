using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject shine;
    private SpriteRenderer sr;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            shine.SetActive(true);
            GameController.current.AddCoinScore(1);
            Destroy(gameObject, 6f);
        }
    }
}
