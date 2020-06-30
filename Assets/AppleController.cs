using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        UnityEngine.Debug.Log("trigger entered");

        // stop movement
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;

        // turn collider off
        Collider2D collider = this.gameObject.GetComponent<Collider2D>();
        collider.enabled = false;

        if (other.gameObject.tag == "Fist")
        {
            animator.SetBool("hitApple", true);

            if (this.gameObject.tag == "GoodApple")
            {
                playerController.hitGoodApple();
            }
            else if (this.gameObject.tag == "BadApple")
            {
                playerController.hitBadApple();
            }
        }
        else if (other.gameObject.tag == "DestroyAppleBox")
        {
            animator.SetBool("destroyApple", true);
        }
    }

    public void explosionAnimationEnded()
    {
        Destroy(this.gameObject);
    }
}
