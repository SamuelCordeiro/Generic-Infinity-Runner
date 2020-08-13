using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public GameObject platform;
    public Transform point;
    public float minDistance;
    public float maxDistance;
    private float platformWidth;

    // Start is called before the first frame update
    void Start()
    {
        if(platform.GetComponent<BoxCollider2D>())
        {
            platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
        }
        else
        {
            platformWidth = platform.GetComponent<PolygonCollider2D>().bounds.size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < point.position.x)
        {
            float distance = Random.Range(minDistance, maxDistance);
            transform.position = new Vector3(transform.position.x + platformWidth + distance, transform.position.y, transform.position.z);
            Instantiate(platform, transform.position, transform.rotation);
        }
    }
}
