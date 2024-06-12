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
        Collider hitCollider = col.collider;

        if (hitCollider.name == "Player1Headshot")
        {
            Destroy(gameObject);
            playerHealth.HealthPoints = playerHealth.HealthPoints - 70f;
            Player1HeadshotCanvas();
        }

        if (hitCollider.name == "Player1Bodyshot")
        {
            Destroy(gameObject);
            playerHealth.HealthPoints = playerHealth.HealthPoints - 33.4f;
            Player1BodyShotCanvas();
        }

        if (hitCollider.name == "Player2Headshot")
        {
            Destroy(gameObject);
            Player2Health.HealthPoints = Player2Health.HealthPoints - 70f;
            HeadshotCanvas();
        }

        if (hitCollider.name == "Player2Bodyshot")
        {
            Destroy(gameObject);
            Player2Health.HealthPoints = Player2Health.HealthPoints - 33.4f;
            BodyShotCanvas();
        }

        if (col.gameObject.CompareTag("Crates"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Props"))
        {
            Destroy(gameObject);
        }
    }

    public void BodyShotCanvas()
    {
        Vector3 direction = Player2.transform.position - Player.transform.position;
        direction = Vector3.Normalize(direction);
        Quaternion rotation = Quaternion.LookRotation(direction);
        Vector3 SpawnPosition = new Vector3(Player2.transform.position.x, Player2.transform.position.y + 3.5f, Player2.transform.position.z);
        Instantiate(DamageCanvas, SpawnPosition, rotation);
    }

    public void HeadshotCanvas()
    {
        Vector3 direction = Player2.transform.position - Player.transform.position;
        direction = Vector3.Normalize(direction);
        Quaternion rotation = Quaternion.LookRotation(direction);
        Vector3 SpawnPosition = new Vector3(Player2.transform.position.x, Player2.transform.position.y + 3.5f, Player2.transform.position.z);
        Instantiate(HeadshotDamageCanvas, SpawnPosition, rotation);
    }

    public void Player1BodyShotCanvas()
    {
        Vector3 direction = Player.transform.position - Player2.transform.position;
        direction = Vector3.Normalize(direction);
        Quaternion rotation = Quaternion.LookRotation(direction);
        Vector3 SpawnPosition = new Vector3(Player.transform.position.x, Player.transform.position.y + 3.5f, Player.transform.position.z);
        Instantiate(DamageCanvas, SpawnPosition, rotation);
    }

    public void Player1HeadshotCanvas()
    {
        Vector3 direction = Player.transform.position - Player2.transform.position;
        direction = Vector3.Normalize(direction);
        Quaternion rotation = Quaternion.LookRotation(direction);
        Vector3 SpawnPosition = new Vector3(Player.transform.position.x, Player.transform.position.y + 3.5f, Player.transform.position.z);
        Instantiate(HeadshotDamageCanvas, SpawnPosition, rotation);
    }
}
