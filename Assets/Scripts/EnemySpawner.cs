using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();
    public float initialTime;
    public float minTime;
    public float maxTime;
    private float timeControl;
    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        //Spawnar enemys
        timeControl += Time.deltaTime;
        if(timeControl >= initialTime)
        {
            Instantiate(enemyList[Random.Range(0, enemyList.Count)], 
            transform.position + new Vector3(0f , Random.Range(-1, 4), 0f) , transform.rotation);
           initialTime = Random.Range(minTime, maxTime);
           timeControl = 0;
        }
    }
}
