using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform EnemyGun;
    public GameObject Player;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    public GameObject AttackPosition;
    public bool Attacked = false;
    public GameObject[] CoverPoints;
    public float Distance;
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
        //Vector3 Direction = Player.transform.position - gameObject.transform.position;
        //gameObject.transform.forward = Direction;
        GameObject bullet = Instantiate(BulletPrefab, EnemyGun.position, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            Vector3 Direction = Player.transform.position - gameObject.transform.position;
            Direction = Direction.normalized;
            bulletRigidbody.velocity = Direction * BulletSpeed;
            Attacked = true;
            GoToCover();
        }
    }

    public void GoToCover()
    {
        foreach (GameObject f in CoverPoints)
        {
            if ((f.transform.position - Player.transform.position).magnitude < Distance)
            {
                Distance = (f.transform.position - Player.transform.position).magnitude;
                navMeshAgent.destination = f.transform.position;
            }
            else
            {
                Debug.Log("The safe point is further");
            }
        }
    }
}
