using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Health : MonoBehaviour
{
    public float HealthPoints = 200f;
    public Animator animator;
    public Slider HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthPoints <= 0)
        {
            animator.SetBool("IsDying", true);
        }
        HealthBar.value = HealthPoints;
    }
}
