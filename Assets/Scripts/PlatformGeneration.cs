using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    private Platform Platform;
    public List<GameObject> Platforms = new List<GameObject>();
    public float minDistance;
    public float maxDistance;
    public Platform FirstPlatform;


    void Update () 
    {
        if(GameController.current.isPlayerAlive)
        {
            if(FirstPlatform.xObject != null)
            {
                Platform = FirstPlatform;
            }
            if(transform.position.x >= Platform.xObject.transform.position.x)
            {
                Destroy(Platform.xObject.gameObject);
                
                Platform = Instantiate(Platforms[Random.Range(0, Platforms.Count)], 
                transform.position + new Vector3(Random.Range(minDistance, maxDistance) , 0f, 0f), 
                transform.rotation).GetComponent<Platform>();        
            } 
        }
    }
}
