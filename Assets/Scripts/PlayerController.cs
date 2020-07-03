using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public TextMeshProUGUI score;
    public TextMeshProUGUI gameOverTxt;
    public GameObject[] hearts;
    public bool gameOver = false;

    private const int pointsForHittingGoodApple = 15;

    private int points = 0;
    private int health;

    void Start()
    {
        Screen.SetResolution(576, 768, false);
        health = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
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
        else if (!gameOverTxt.gameObject.activeSelf)
        {
            gameOverTxt.gameObject.SetActive(true);
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

    public void hitGoodApple()
    {
        points += pointsForHittingGoodApple;
        score.text = points.ToString();
    }

    public void hitBadApple()
    {
        if (health > 0)
        {
            health -= 1;
            Destroy(hearts[health].gameObject);
            if (health == 0)
            {
                gameOver = true;
            }
        }
    }
}
