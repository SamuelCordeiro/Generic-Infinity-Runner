using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject bonus;
    public float initialTime;
    public float minTime;
    public float maxTime;
    private float timeControl;

    void Update()
    {
        if(GameController.current.isPlayerAlive)
        {
            timeControl += Time.deltaTime;
            if(timeControl >= initialTime)
            {
                Instantiate(bonus, transform.position + new Vector3(0f , Random.Range(1, 4), 0f) , transform.rotation);
                initialTime = Random.Range(minTime, maxTime);
                timeControl = 0;
            }
        }
    }
}
