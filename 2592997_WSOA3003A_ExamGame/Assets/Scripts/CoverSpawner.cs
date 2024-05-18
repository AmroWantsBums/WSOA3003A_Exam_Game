using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverSpawner : MonoBehaviour
{
    public GameObject[] CoverPrefabs;
    public Vector3 instantiateRotation;
    public Vector3 CoachInstantiateRotation;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCover();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCover()
    {
        int RandomNumber = Random.Range(1,2);
        if (RandomNumber == 0)
        {
            Quaternion rotation = Quaternion.Euler(instantiateRotation);
            float SpawnZPos = Random.Range(-20f, 20f);
            Vector3 SpawnPosition = new Vector3(-16f, 0f, SpawnZPos);
            GameObject SpawnedObject = Instantiate(CoverPrefabs[RandomNumber], SpawnPosition, rotation);
            Rigidbody ObjectRB = SpawnedObject.GetComponent<Rigidbody>();
            ObjectRB.velocity = new Vector3(5f, 0f, 0f);
        }
        else if (RandomNumber == 1)
        {
            Quaternion rotation = Quaternion.Euler(CoachInstantiateRotation);
            float SpawnZPos = Random.Range(-20f, 20f);
            Vector3 SpawnPosition = new Vector3(-16f, 0f, SpawnZPos);
            GameObject SpawnedObject = Instantiate(CoverPrefabs[RandomNumber], SpawnPosition, rotation);
            Rigidbody ObjectRB = SpawnedObject.GetComponent<Rigidbody>();
            ObjectRB.velocity = new Vector3(5f, 0f, 0f);
        }
        else 
        {
            float SpawnZPos = Random.Range(-20f, 20f);
            Vector3 SpawnPosition = new Vector3(-10f, 0f, SpawnZPos);
            GameObject SpawnedObject = Instantiate(CoverPrefabs[RandomNumber], SpawnPosition, Quaternion.identity);
            Rigidbody ObjectRB = SpawnedObject.GetComponent<Rigidbody>();
            ObjectRB.velocity = new Vector3(5f, 0f, 0f);

        }
        
    }
}
