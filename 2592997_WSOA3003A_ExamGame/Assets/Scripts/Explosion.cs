using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float sphereRadius = 1f;
    public float maxDistance = 10f;
    public LayerMask layerMask;
    public RaycastHit[] hits;
    public EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        enemyController = GameObject.Find("Enemy").GetComponent<EnemyController>();
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(3f);
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        hits = Physics.SphereCastAll(origin, sphereRadius, direction, maxDistance, layerMask);
        foreach (RaycastHit f in hits)
        {
            if (f.collider.gameObject.name != "Player" || f.collider.gameObject.name != "Enemy" || f.collider.gameObject.name != "Place")
            {
                if (f.collider.gameObject.CompareTag("SafeSpace"))
                {
                    enemyController.CoverPointss.Remove(f.collider.gameObject);
                }
                else
                {
                    Debug.Log(f.collider.gameObject.name);
                    Destroy(f.collider.gameObject);
                }
            }
        }
        enemyController.GoToCover();
        Debug.Log("Relocate");
    }
}
