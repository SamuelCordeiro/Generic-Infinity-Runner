using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
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
}
