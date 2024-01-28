using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerNew : MonoBehaviour
{
    public GameObject left;
    public GameObject right;

    public GameObject enemy;
    public float leftSpawnRate = 1f;
    public float leftTimer = 0;
    public float rightSpawnRate = .7f;
    public float rightTimer = 0;

    public float grandTimer = 0;
    public float grandCountDown = 12;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leftTimer < leftSpawnRate)
        {
            leftTimer += Time.deltaTime;
        }
        else
        {
            leftTimer = 0f;
            spawn(false);
        }

        if (rightTimer < rightSpawnRate)
        {
            rightTimer += Time.deltaTime;
        }
        else
        {
            rightTimer = 0f;
            spawn(true);
        }
    }


    public void spawn(bool dir)
    {
        //bool dir; 0 - left, 1 - right
        
        if (dir)
        {
            GameObject guy2;
            guy2 = Instantiate(enemy, left.transform.position, left.transform.rotation);
            //enemy.GetComponent<EnemyScript>().changeTargetDir(1);
            guy2.GetComponent<EnemyScript>().changeTargetDir(1);
        }
        else
        {
            GameObject guy;
            guy = Instantiate(enemy, right.transform.position, right.transform.rotation);
            //enemy.GetComponent<EnemyScript>().changeTargetDir(-1);
            guy.GetComponent<EnemyScript>().changeTargetDir(-1);
        }

    }
}
