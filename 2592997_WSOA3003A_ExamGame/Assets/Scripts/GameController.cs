using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI CountdownText;
    private float interval;
    private int Seconds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interval < 1)
        {
            interval = interval + Time.deltaTime;
        }
        else
        {
            Seconds--;
            CountdownText.text = $"{Seconds} seconds remaining";
        }
    }
}
