using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("punchUpperLeft", true);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("punchUpperRight", true);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("punchLowerLeft", true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("punchLowerRight", true);
        }
    }

    public void punchUpperRightAnimationEnded()
    {
        animator.SetBool("punchUpperRight", false);
    }

    public void punchLowerRightAnimationEnded()
    {
        animator.SetBool("punchLowerRight", false);
    }

    public void punchUpperLeftAnimationEnded()
    {
        animator.SetBool("punchUpperLeft", false);
    }

    public void punchLowerLeftAnimationEnded()
    {
        animator.SetBool("punchLowerLeft", false);
    }
}
