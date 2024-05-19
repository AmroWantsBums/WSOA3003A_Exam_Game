using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverMover : MonoBehaviour
{
    public float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody ObjectRB = gameObject.GetComponent<Rigidbody>();
        ObjectRB.velocity = new Vector3(MoveSpeed, 0f, 0f);
    }
}
