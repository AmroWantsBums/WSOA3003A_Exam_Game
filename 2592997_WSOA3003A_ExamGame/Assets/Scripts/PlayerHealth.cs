using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float HealthPoints = 200;
    public Slider HealthBar;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = HealthPoints;
        if (HealthPoints <= 0)
        {
            animator.SetBool("IsDying", true);
        }
    }
}
