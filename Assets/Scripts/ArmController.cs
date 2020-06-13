using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("collision with " + collision.gameObject.tag);

        if (collision.gameObject.tag.Equals("BadApple")) {
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.tag.Equals("GoodApple")) {
            Destroy(collision.gameObject);
        }
    }
}
