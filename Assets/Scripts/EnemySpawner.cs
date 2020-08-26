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
    private GameObject groundEnemy;
    private GameObject boss;

    void Update()
    {
        groundEnemy = GameObject.FindGameObjectWithTag("GroundEnemy");
        boss = GameObject.FindGameObjectWithTag("Boss");
        if(GameController.current.isPlayerAlive)
        {
            timeControl += Time.deltaTime;
            if(timeControl >= initialTime)
            {
                Instantiate(enemyList[Random.Range(0, enemyList.Count)], 
                transform.position + new Vector3(0f , Random.Range(-1, 4), 0f) , transform.rotation);
                initialTime = Random.Range(minTime, maxTime);
                timeControl = 0;
            }
        }
        if(groundEnemy != null || boss != null)
        {
            timeControl = 0;
        }
    }
}
