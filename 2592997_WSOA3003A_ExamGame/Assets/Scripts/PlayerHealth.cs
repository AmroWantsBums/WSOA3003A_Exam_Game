using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int HealthPoints;
    public GameObject[] HealthSprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthPoints == 2)
        {
            HealthSprites[2].SetActive(false);
        }
        if (HealthPoints == 1)
        {
            HealthSprites[1].SetActive(false);
        }
        if (HealthPoints == 0)
        {
            HealthSprites[0].SetActive(false);
        }
    }
}
