using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform SpawnPosition;
    public float BulletSpeed = 10f;
    public bool CanShoot = true;
    public Vector3 BulletRotation;
    public GameObject Camera;
    public Camera NormalView;
    public Camera ADSView;
    public GameObject Crosshair;
    public playerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        ADSView.enabled = false;
        playerMovement = GameObject.Find("Player").GetComponent<playerMovement>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanShoot)
            {
                Quaternion rotation = Quaternion.Euler(BulletRotation);
                GameObject bullet = Instantiate(BulletPrefab, SpawnPosition.position, rotation);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                if (bulletRigidbody != null)
                {
                    bulletRigidbody.velocity = transform.forward * BulletSpeed;
                }
                CanShoot = false;
                StartCoroutine(GunCooldown());
            }            
        }

        if (Input.GetMouseButtonDown(1))
        {
            NormalView.enabled = false;
            ADSView.enabled = true;
            Crosshair.SetActive(false);
            playerMovement.lookSpeed = 1f;
        }

        if (Input.GetMouseButtonUp(1))
        {
            NormalView.enabled = true;
            ADSView.enabled = false;
            Crosshair.SetActive(true);
            playerMovement.lookSpeed = 2;
        }
    }

    IEnumerator GunCooldown()
    {
        yield return new WaitForSeconds(1.5f);
        CanShoot = true;
    }

}
