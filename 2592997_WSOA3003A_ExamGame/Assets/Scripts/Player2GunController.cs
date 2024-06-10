using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2GunController : MonoBehaviour
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
    public Player2Movement player2Movement;
    public Slider FireCooldown;
    public float Seconds = 1.5f;
    public Animator Player2Animator;
    public bool IsShooting = false;
    public GameObject ADSBone;
    public bool ADSing = false;
    public bool CanADS = true;
    // Start is called before the first frame update
    void Start()
    {
        ADSView.enabled = false;
        player2Movement = GameObject.Find("Player2").GetComponent<Player2Movement>();
    }

    void Update()
    {
        if (Input.GetAxis("R2Trigger") > -0.02f && CanShoot)
        {
            Debug.Log("Fired");
            if (CanShoot && ADSing)
            {
                Player2Animator.SetBool("IsShooting", true);
                Vector3 aimDirection = ADSBone.transform.forward;
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
            else
            {
                Player2Animator.SetBool("IsShooting", true);
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

        if (Input.GetAxis("L2Trigger") > -0.02f && CanADS)
        {
            NormalView.enabled = false;
            ADSView.enabled = true;
            ADSing = true;
            Crosshair.SetActive(false);
            player2Movement.lookSpeed = 1f;
            Player2Animator.SetBool("IsAiming", true);
        }
        else
        {
            DisableADS();
        }

        if (player2Movement.IsRunning)
        {
            DisableADS();
        }

        if (!CanShoot)
        {
            if (Seconds > 0)
            {
                Seconds = Seconds - Time.deltaTime;
                FireCooldown.value = Seconds / 1.5f;
                Crosshair.SetActive(false);
            }
            else
            {
                CanShoot = true;
                Crosshair.SetActive(true);
                Player2Animator.SetBool("IsShooting", false);
                CanADS = true;
            }
        }
    }

    public void DisableADS()
    {
        NormalView.enabled = true;
        ADSView.enabled = false;
        Crosshair.SetActive(true);
        player2Movement.lookSpeed = 2;
        Player2Animator.SetBool("IsAiming", false);
    }
}
