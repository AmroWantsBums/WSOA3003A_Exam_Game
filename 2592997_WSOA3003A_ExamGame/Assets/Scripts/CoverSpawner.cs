using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverSpawner : MonoBehaviour
{
    public GameObject[] CoverPrefabs;
    public Vector3 instantiateRotation;
    public Vector3 CoachInstantiateRotation;
    public GameController GameController;
    public bool Spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("Canvas").GetComponent<GameController>();
        StartCoroutine(ResetTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.GameStarted && !Spawned)
        {
            StartCoroutine(ResetTimer());
            Spawned = true;
        }
    }

    IEnumerator ResetTimer()
    {
        yield return new WaitForSeconds(10f);
        SpawnCover();
        StartCoroutine(ResetTimer());
    }

    void SpawnCover()
    {
        int RandomNumber = Random.Range(0,5);
        if (RandomNumber == 0)
        {
            Quaternion rotation = Quaternion.Euler(instantiateRotation);
            float SpawnZPos = Random.Range(-10f, 10f);
            Vector3 SpawnPosition = new Vector3(-16f, 0f, SpawnZPos);
            GameObject SpawnedObject = Instantiate(CoverPrefabs[RandomNumber], SpawnPosition, rotation);
        }
        else if (RandomNumber == 1 || RandomNumber == 3)
        {
            Quaternion rotation = Quaternion.Euler(CoachInstantiateRotation);
            float SpawnZPos = Random.Range(-10f, 10f);
            Vector3 SpawnPosition = new Vector3(-10f, 0f, SpawnZPos);
            GameObject SpawnedObject = Instantiate(CoverPrefabs[RandomNumber], SpawnPosition, rotation);
        }
        else 
        {
            float SpawnZPos = Random.Range(-10f, 10f);
            Vector3 SpawnPosition = new Vector3(-10f, 0f, SpawnZPos);
            GameObject SpawnedObject = Instantiate(CoverPrefabs[RandomNumber], SpawnPosition, Quaternion.identity);
        }
        
    }
}
