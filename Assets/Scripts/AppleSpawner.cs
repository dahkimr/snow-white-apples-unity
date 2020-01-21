using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour {

    public GameObject goodApple;
    public GameObject badApple;
    public GameObject tRPos;
    public GameObject bRPos;
    public GameObject tLPos;
    public GameObject bLPos;

    private const int numOfSpawnPos = 4;
    private const float chanceSpawnBadApple = 0.3f;
    private const float spawnInterval = 2.0f;

    private SpawnInfo[] appleSpawnInfo = new SpawnInfo[numOfSpawnPos];
    private float appleSpeed = 5;


    // Start is called before the first frame update
    void Start()
    {
        // top right position
        Vector3 position = tRPos.transform.position;
        Vector2 direction = new Vector2(-1f, 0f);
        SpawnInfo si = new SpawnInfo(position, direction);
        appleSpawnInfo[0] = si;

        // bottom right position
        position = bRPos.transform.position;
        si = new SpawnInfo(position, direction);
        appleSpawnInfo[1] = si;

        // bottom left position
        position = bLPos.transform.position;
        direction = new Vector2(1f, 0f);
        si = new SpawnInfo(position, direction);
        appleSpawnInfo[2] = si;

        // top left position
        position = tLPos.transform.position;
        si = new SpawnInfo(position, direction);
        appleSpawnInfo[3] = si;

        // spawn apple
        InvokeRepeating("SpawnApple", 0.0f, spawnInterval);
    }

    // spawn the apple and set it moving
    private void SpawnApple() {
        GameObject prefab;
        int index = Random.Range(0, numOfSpawnPos);

        // which prefab chosen should be random, but have probability
        if (Random.Range(0f, 1f) > chanceSpawnBadApple) {
            prefab = goodApple;
        }
        else {
            prefab = goodApple;
            prefab = badApple;
        }

        // create prefab at certain spot
        GameObject apple = Instantiate(prefab, appleSpawnInfo[index].GetPosition(), Quaternion.identity);

        // get prefab moving
        // or put script on prefab on start to keep moving
        apple.GetComponent<Rigidbody2D>().AddForce(appleSpawnInfo[index].GetDirection() * appleSpeed, ForceMode2D.Impulse);
    }
}

class SpawnInfo {
    Vector3 position;
    Vector2 direction;

    public SpawnInfo(Vector3 position, Vector2 direction) {
        this.position = position;
        this.direction = direction;
    }

    public Vector3 GetPosition() {
        return this.position;
    }

    public Vector2 GetDirection() {
        return this.direction;
    }
}
