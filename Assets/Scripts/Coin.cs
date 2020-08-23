using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject shine;
    private SpriteRenderer sr;
    //private Transform backPoint;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        //backPoint = GameObject.Find("Back Point").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(transform.position.x < backPoint.position.x)
        {
            Destroy(gameObject);
        }*/
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
