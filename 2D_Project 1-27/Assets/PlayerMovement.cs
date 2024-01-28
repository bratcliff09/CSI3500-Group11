using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidBody;

    public float moveSpd = 10f;
    public float jumpHeight = 10f;

    public Vector3 velocity;
    public bool isGrounded = true;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //int inputDir = Input.GetKeyDown(KeyCode.A) - Input.GetKeyDown(KeyCode.D);

        float inputDirHori = Input.GetAxisRaw("Horizontal");

        int woo = 0;

        if (inputDirHori < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (inputDirHori > 0)
        {
            spriteRenderer.flipX = false;
        }        

        myRigidBody.velocity = new Vector2(inputDirHori * moveSpd, myRigidBody.velocity.y);

        animator.SetFloat("spd", Mathf.Abs(inputDirHori));

        if (Input.GetKeyDown(KeyCode.Space) ) 
        {
            myRigidBody.velocity = Vector2.up * jumpHeight;
            //woo = 1;
            //myRigidBody.AddForce(new Vector2(myRigidBody.velocity.x, jumpHeight));
            //transform.rotation.z = Quaternion(0, 0, 1);
        }
    }
}
