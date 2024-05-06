using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.Find("Enemy");
        enemyHealth = Enemy.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Enemy")
        {
            enemyHealth.HealthPoints = enemyHealth.HealthPoints - 33.4f;
            Destroy(gameObject);
        }
    }
}