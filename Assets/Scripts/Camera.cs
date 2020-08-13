using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 newPosition = new Vector3(player.transform.position.x + 8.5f, transform.position.y, transform.position.z);
       transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime); 
    }
}
