using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    LogicScript logicYe;

    public Rigidbody2D myRigidBody;

    public float moveSpd = 10f;
    public float jumpHeight = 10f;

    public Vector3 velocity;
    public bool isGrounded = true;

    public BoxCollider2D hurtBox;

    int destroyPositionY = -25;

    public bool indecisive = false; //if true, then the enemy will switch b/w idle and run
    public bool moveState = false; //true - running, false - idle
    int targetDir = 0; //1 - right, -1 - left
    float timer = 0f;
    float timerMax = 5f;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public int test = 0;

    // Start is called before the first frame update
    void Start()
    {
        //targetDir = RandomBool() ? -1 : 1;
        logicYe = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < destroyPositionY)
        {
            Destroy(gameObject);
        }

        running();
    }

    private void idle()
    {
        int yop = 9;
        transform.Rotate(0, 0, yop * Time.deltaTime);
    }

    private void running()
    {
        animator.SetFloat("spd", Mathf.Abs(velocity.x));
        spriteRenderer.flipX = (targetDir == -1) ? true : false;
        
        myRigidBody.velocity = new Vector2(targetDir * moveSpd, myRigidBody.velocity.y);
    }

    private bool RandomBool()
    {
        //Random.Range(0, 2) chooses either 0 or 1
        if (Random.Range(0, 2) == 0)
        {
            return true;
        }
        return false;
    }

    public void changeTargetDir(int a)
    {
        targetDir = a;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9) //Layer 9 is the player hitbox
        {
            logicYe.addScore(1);
            Destroy(gameObject); //Destroys the game object holding this specific script
        }
    }


    void nonWorkingStart()
    {
        //indecisive = RandomBool();

        float n = Random.value;
        //30 percent chance of being indecisive

        /*
        if (n >= .7)
        {
            indecisive = false;
            if (targetDir == 0)
            {
                targetDir = RandomBool() ? 1 : -1;
            }
        }
        else
        {
            indecisive = true;
        }
        */

        if (!indecisive)
        {
            animator.SetBool("runnerBoi", true);
            moveState = true;
        }
        timer = timerMax;



        logicYe = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void nonWorkingUpdate()
    {
        //Debug.Log(Random.value.ToString());

        if (transform.position.y < destroyPositionY)
        {
            Destroy(gameObject);
        }

        /*
        int x = Random.Range(0, 2);
        Debug.Log(x.ToString());
        */

        if (indecisive)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Goal");
                timer = timerMax;

                targetDir = RandomBool() ? 1 : -1;
                moveState = RandomBool();

            }
        }

        if (moveState)
        {
            running();
        }
        else
        {
            idle();
        }


    }
}
