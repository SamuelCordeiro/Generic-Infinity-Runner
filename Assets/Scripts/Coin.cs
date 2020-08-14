using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Transform backPoint;
    // Start is called before the first frame update
    void Start()
    {
        backPoint = GameObject.Find("Back Point").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < backPoint.position.x)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "Player")
        {
            GameController.current.AddCoinScore(1);
            Destroy(gameObject);
        }
    }
}
