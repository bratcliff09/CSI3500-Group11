using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 2;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //spawner();
    }

    public void spawner()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
