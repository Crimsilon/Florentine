using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject enemySpawnOne;
    public GameObject enemySpawnTwo;

    public float spawnSpeed;

    // Start is called before the first frame update


    void Start()
    {
        StartCoroutine(spawns());
    }

    IEnumerator spawns()
    {
        while (true)
        {
            int temp = Random.Range(0, 2);

            yield return new WaitForSeconds(spawnSpeed);
            if (temp == 0)
                GameObject.Instantiate(enemySpawnOne, transform);
            else
                GameObject.Instantiate(enemySpawnTwo, transform);
        }
    }


    // Update is called once per frame
    void Update()
    {


        //GameObject.Instantiate(enemySpawn, transform);
    }
}
