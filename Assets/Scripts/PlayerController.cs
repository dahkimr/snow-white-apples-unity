using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject rightArmPivot;
    public GameObject leftArmPivot;

    private const float upperRot = 120;
    private const float lowerRot = 60;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.D)) {
            rightArmPivot.transform.rotation = Quaternion.Euler(0f, 0f, upperRot);
            StartCoroutine(rotateArmBack(rightArmPivot));
        }
        else if (Input.GetKeyDown(KeyCode.C)) {
            rightArmPivot.transform.rotation = Quaternion.Euler(0f, 0f, lowerRot);
            StartCoroutine(rotateArmBack(rightArmPivot));
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            leftArmPivot.transform.rotation = Quaternion.Euler(0f, 0f, -upperRot);
            StartCoroutine(rotateArmBack(leftArmPivot));
        }
        else if (Input.GetKeyDown(KeyCode.X)) {
            leftArmPivot.transform.rotation = Quaternion.Euler(0f, 0f, -lowerRot);
            StartCoroutine(rotateArmBack(leftArmPivot));
        }
    }

    private IEnumerator rotateArmBack(GameObject armPivot) {
        yield return new WaitForSeconds(0.09f);
        armPivot.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
