using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //private Transform backPoint;
    public Transform xObject;
    public bool isBig;
    // Start is called before the first frame update
    void Start()
    {
        //backPoint = GameObject.Find("Back Point").GetComponent<Transform>();

        if(!isBig)
        {
            transform.position += new Vector3(0f, -0.8f, 0f);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        /*if(transform.position.x < backPoint.position.x)
        {
            Destroy(gameObject);
        }/*/
    }
}
