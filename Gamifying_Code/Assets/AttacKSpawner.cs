using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacKSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject objectToSpawn2;
    public GameObject objectToSpawn3;

    public float spawnSpeed = 5f; // Initial speed of the spawned object
    public float spawnSpeed2 = 5f; // Initial speed of the spawned object
    public float spawnSpeed3 = 5f; // Initial speed of the spawned object
    public float speedIncrement = 1f; // Amount to increase speed each frame
    public Vector3 spawnOffset = new Vector3(0, 0, 0); // Offset from the spawner's position
    public GameObject HeavySpawnLocation;

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnAndMoveObject()
    {
        // Spawn the object
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position + spawnOffset, Quaternion.identity);

        // Move the spawned object forward
        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.right * spawnSpeed*3; // Move along the object's local forward direction
        }
        else
        {
            Debug.LogError("Spawned object doesn't have a Rigidbody2D component!");
        }

        // Increase spawn speed for the next frame
        spawnSpeed += speedIncrement * Time.deltaTime;
    }
    public void SpawnAndMoveObject2()
    {
        // Spawn the object
        GameObject spawnedObject = Instantiate(objectToSpawn2, transform.position + spawnOffset, Quaternion.identity);

        // Move the spawned object forward
        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.right * spawnSpeed2 * 3; // Move along the object's local forward direction
        }
        else
        {
            Debug.LogError("Spawned object doesn't have a Rigidbody2D component!");
        }

        // Increase spawn speed for the next frame
        spawnSpeed2 += speedIncrement * Time.deltaTime;
    }
    public void SpawnAndMoveObject3()
    {
        // Spawn the object
        GameObject spawnedObject = Instantiate(objectToSpawn3, HeavySpawnLocation.transform.position + spawnOffset, Quaternion.identity);

        // Move the spawned object forward
        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.right * spawnSpeed3 * 3; // Move along the object's local forward direction
        }
        else
        {
            Debug.LogError("Spawned object doesn't have a Rigidbody2D component!");
        }

        // Increase spawn speed for the next frame
        spawnSpeed3 += speedIncrement * Time.deltaTime;
    }
}
