using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform xObject;
    public bool isBig;

    void Start()
    {
        if(!isBig)
        {
            transform.position += new Vector3(0f, -0.8f, 0f);
        } 
    }
}
