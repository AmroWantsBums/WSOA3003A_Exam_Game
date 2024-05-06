using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
    public GameObject Grenade;
    public Transform SpawnPosition;
    public float GrenadeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        GameObject Frag = Instantiate(Grenade, SpawnPosition.position, Quaternion.identity);
        Rigidbody GrenadeRigidbody = Frag.GetComponent<Rigidbody>();
        if (GrenadeRigidbody != null)
        {
            Vector3 throwDirection = gameObject.transform.forward; 
            throwDirection.y += 0.4f; 
            GrenadeRigidbody.velocity = throwDirection.normalized * GrenadeSpeed;
        }
    }
}
