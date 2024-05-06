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
    public float aimSpeed = 4.0f;
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
            AimAtPlayer();

        }

    }

    void AimAtPlayer()
    {
        Vector3 playerDirection = Player.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(playerDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, aimSpeed * Time.deltaTime);
        if (Vector3.Dot(transform.forward, playerDirection.normalized) > 0.98f)
        {
            StartCoroutine(ShootPlayer());
            Attacked = true;
        }
    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(1f);
        GameObject bullet = Instantiate(BulletPrefab, EnemyGun.position, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            Vector3 Direction = Player.transform.position - gameObject.transform.position;
            Direction = Direction.normalized;
            bulletRigidbody.velocity = Direction * BulletSpeed;
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
