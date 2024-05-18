using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform SpawnPosition;
    public float BulletSpeed = 10f;
    public bool CanShoot = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanShoot)
            {
                GameObject bullet = Instantiate(BulletPrefab, SpawnPosition.position, Quaternion.identity);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                if (bulletRigidbody != null)
                {
                    bulletRigidbody.velocity = transform.forward * BulletSpeed;
                }
                CanShoot = false;
                StartCoroutine(GunCooldown());
            }            
        }
    }

    IEnumerator GunCooldown()
    {
        yield return new WaitForSeconds(1.5f);
        CanShoot = true;
    }

}
