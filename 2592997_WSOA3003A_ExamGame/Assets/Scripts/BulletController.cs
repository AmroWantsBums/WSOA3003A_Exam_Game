using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject Player;
    public Player2Health Player2Health;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        playerHealth = Player.GetComponent<PlayerHealth>();
        Player2Health = GameObject.Find("Player2").GetComponent<Player2Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject);
            playerHealth.HealthPoints = playerHealth.HealthPoints - 33.4f;            
        }

        if (col.gameObject.name == "Player2Headshot")
        {
            Player2Health.HealthPoints = 0f;
            Debug.Log("Headshot");
        }

        if (col.gameObject.name == "Player2Bodyshot")
        {
            Player2Health.HealthPoints = 0f;
            Debug.Log("BodyShot");
        }
    }
}
