using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    /// <summary>
    /// Keeps track of score and other high level information
    /// </summary>
    /// 

    public int playerScore;
    public Text scoreText;

    public EnemySpawner enemySpawner;

    //public EnemySpawnerNew enemySpawnerNew;

    // Start is called before the first frame update
    void Start()
    {
        //enemySpawner.spawner();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime);
    }

    [ContextMenu("Increase Score")]
    public void addScore(int a)
    {
        playerScore += a;
        scoreText.text = playerScore.ToString();

        /*
        int rand = Random.Range(1, 3);

        for (int i = 0; i < rand; i++)
        {
            enemySpawner.spawner();
        }
        */

        
    }
}
