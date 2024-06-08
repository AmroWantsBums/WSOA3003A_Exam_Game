using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Slider FireCooldown;
    public float Seconds = 1.5f;
    public Animator Player1Animator;
    public GameObject Model;

    // Start is called before the first frame update
    void Start()
    {
        ADSView.enabled = false;
        playerMovement = GameObject.Find("Player").GetComponent<playerMovement>();
        Model = GameObject.Find("Player1Model");
        Player1Animator = Model.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanShoot)
            {
                Vector3 aimDirection = NormalView.transform.up;
                Quaternion bulletRotation = Quaternion.LookRotation(aimDirection);
                GameObject bullet = Instantiate(BulletPrefab, SpawnPosition.position, bulletRotation);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                if (bulletRigidbody != null)
                {
                    bulletRigidbody.velocity = transform.forward * BulletSpeed;
                }
                CanShoot = false;
                Seconds = 1.5f;
            }            
        }

        if (Input.GetMouseButtonDown(1))
        {
            NormalView.enabled = false;
            ADSView.enabled = true;
            Crosshair.SetActive(false);
            playerMovement.lookSpeed = 1f;
            Player1Animator.SetBool("IsAiming", true);
        }

        if (Input.GetMouseButtonUp(1))
        {
            NormalView.enabled = true;
            ADSView.enabled = false;
            Crosshair.SetActive(true);
            playerMovement.lookSpeed = 2;
            Player1Animator.SetBool("IsAiming", false);
        }
        
        if (!CanShoot)
        {            
            if (Seconds > 0)
            {
                Seconds = Seconds - Time.deltaTime;
                FireCooldown.value = Seconds/1.5f;
                Crosshair.SetActive(false);
            }
            else
            {
                CanShoot = true;
                Crosshair.SetActive(true);
            }
        }
    }
}
