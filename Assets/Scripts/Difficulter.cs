using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulter : MonoBehaviour
{
    public float currentSpawnOffset;
    public float spawnOffset = 1.3f;
    int numToSpawn = 0;
    int numSpawned = 0;


    public void GetEasy ()
    {
        print("easy");

        if (numSpawned >= 3)
        {
            numToSpawn = 0;
        }
        else if (numSpawned == 0)
        {
            numToSpawn = 2;
        }

        for (int i = 0; i < numToSpawn; i++)
        {
            currentSpawnOffset += spawnOffset;
            GameObject clone = Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y + currentSpawnOffset, 0), Quaternion.identity);
            numSpawned++;
        }
    }

    public void GetDifficult()
    {

        print("difficult");

        if (numSpawned == 2)
        {
            numToSpawn = 2;
        }
        else if (numSpawned == 4)
        {
            numToSpawn = 0;
        }
        else if (numSpawned ==0)
        {
            numToSpawn = 4;
        }

        print(numToSpawn);

        for (int i = 0; i < numToSpawn; i++)
        {
            currentSpawnOffset += spawnOffset;
            GameObject clone = Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y + currentSpawnOffset, 0), Quaternion.identity);
            numSpawned++;
        }

    }
}
