using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShootController : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform EnemyGun;
    public GameObject Player;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    public GameObject AttackPosition;
    public bool Attacked = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        navMeshAgent.destination = AttackPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance == 0 && !Attacked)
        {
            Debug.Log("Attack Player");
            ShootPlayer();
        }

    }

    public void ShootPlayer()
    {
        GameObject bullet = Instantiate(BulletPrefab, EnemyGun.position, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            Vector3 Direction = Player.transform.position - gameObject.transform.position;
            Direction = Direction.normalized;
            bulletRigidbody.velocity = Direction * BulletSpeed;
            Attacked = true;
        }
    }
}
