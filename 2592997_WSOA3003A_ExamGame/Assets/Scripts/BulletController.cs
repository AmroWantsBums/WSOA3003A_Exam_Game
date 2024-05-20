using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletController : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject Player;
    public GameObject Player2;
    public Player2Health Player2Health;
    public GameObject DamageCanvas;
    public GameObject HeadshotDamageCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Player2 = GameObject.Find("Player2");
        playerHealth = Player.GetComponent<PlayerHealth>();
        Player2Health = GameObject.Find("Player2").GetComponent<Player2Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject);
            playerHealth.HealthPoints = playerHealth.HealthPoints - 33.4f;            
        }

        if (col.gameObject.name == "Player2Headshot")
        {
            Destroy(gameObject);
            Player2Health.HealthPoints = 0f;
            Debug.Log("Headshot");
            HeadshotCanvas();
        }

        if (col.gameObject.name == "Player2Bodyshot")
        {
            Destroy(gameObject);
            Player2Health.HealthPoints = 0f;
            Debug.Log("BodyShot");
            BodyShotCanvas();
        }

        if (col.gameObject.CompareTag("Crates"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

    public void BodyShotCanvas()
    {
        Vector3 direction = Player2.transform.position - Player.transform.position;
        direction = Vector3.Normalize(direction);
        Quaternion rotation = Quaternion.LookRotation(direction);
        Vector3 SpawnPosition = new Vector3(Player2.transform.position.x, Player2.transform.position.y + 2, Player2.transform.position.z);
        Instantiate(DamageCanvas, SpawnPosition, rotation);
    }

    public void HeadshotCanvas()
    {
        Vector3 direction = Player2.transform.position - Player.transform.position;
        direction = Vector3.Normalize(direction);
        Quaternion rotation = Quaternion.LookRotation(direction);
        Vector3 SpawnPosition = new Vector3(Player2.transform.position.x, Player2.transform.position.y + 2, Player2.transform.position.z);
        Instantiate(HeadshotDamageCanvas, SpawnPosition, rotation);
    }
}
