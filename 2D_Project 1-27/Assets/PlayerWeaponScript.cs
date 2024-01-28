using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponScript : MonoBehaviour
{
    public Animator animator;
    public CircleCollider2D circleCollider;
    bool activated;

    float timer = 0f;
    float timerMax = 1f;

    // Start is called before the first frame update
    void Start()
    {
        circleCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.ResetTrigger("AnimDone");
            Debug.Log("Love");
            activated = true;
            circleCollider.enabled = true;

            timer = timerMax;

        }

        

        if (activated)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                activated = false;
            }
            animator.SetTrigger("ButtonPressed");
        }
        else
        {
            circleCollider.enabled = false;
            animator.ResetTrigger("ButtonPressed");
            animator.SetTrigger("AnimDone");
        }

    }
}
