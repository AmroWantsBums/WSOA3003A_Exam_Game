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
    public bool IsShooting = false;
    public GameObject ADSBone;
    public bool ADSing = false;
    public bool CanADS = true;

    // Start is called before the first frame update
    void Start()
    {
        ADSView.enabled = false;
        playerMovement = GameObject.Find("Player").GetComponent<playerMovement>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanShoot)
        {
            if (CanShoot && ADSing)
            {
                Vector3 aimDirection = ADSBone.transform.forward;
                Quaternion bulletRotation = Quaternion.LookRotation(aimDirection);
                GameObject bullet = Instantiate(BulletPrefab, ADSBone.transform.position, bulletRotation);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                IsShooting = true;
                if (bulletRigidbody != null)
                {
                    bulletRigidbody.velocity = ADSBone.transform.forward * BulletSpeed;
                }
                CanShoot = false;
                Seconds = 1f;
                CanADS = false;
                Player1Animator.SetBool("IsShooting", true);
                NormalView.enabled = true;
                ADSView.enabled = false;
            }
            else
            {
                Player1Animator.SetBool("IsShooting", true);
                Vector3 aimDirection = NormalView.transform.up;
                Quaternion bulletRotation = Quaternion.LookRotation(aimDirection);
                GameObject bullet = Instantiate(BulletPrefab, SpawnPosition.position, bulletRotation);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                IsShooting = true;
                if (bulletRigidbody != null)
                {
                    bulletRigidbody.velocity = transform.forward * BulletSpeed;
                }
                CanShoot = false;
                Seconds = 1f;
                CanADS = false;
                NormalView.enabled = true;
                ADSView.enabled = false;
            }            
        }

        if (Input.GetMouseButtonDown(1))
        {
            NormalView.enabled = false;
            ADSView.enabled = true;
            Crosshair.SetActive(false);
            playerMovement.lookSpeed = 1f;
            Player1Animator.SetBool("IsAiming", true);
            SpawnPosition = ADSBone.transform;
            ADSing = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            DisableADS();
        }

        if (playerMovement.IsRunning)
        {
            DisableADS();
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
                Player1Animator.SetBool("IsShooting", false);
                IsShooting = false;
                CanADS = true;
            }
        }
    }

    public void DisableADS()
    {
        NormalView.enabled = true;
        ADSView.enabled = false;
        Crosshair.SetActive(true);
        playerMovement.lookSpeed = 2;
        Player1Animator.SetBool("IsAiming", false);
        SpawnPosition = NormalView.transform;
        ADSing = false;
    }
}
