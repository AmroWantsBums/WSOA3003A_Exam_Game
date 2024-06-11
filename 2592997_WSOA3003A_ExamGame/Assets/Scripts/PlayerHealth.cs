using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float HealthPoints = 200;
    public Slider HealthBar;
    public Animator animator;
    public GunController gunController;
    public Player2GunController Player2gunController;
    public Camera WinnerCamera;
    public Camera LoserCamera;
    public GameObject Canvas1;
    public GameObject Canvas2;
    public Animator EndOfGameAnimator;
    public TextMeshProUGUI PlayerNumberText;
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
            gunController.enabled = false;
            Player2gunController.enabled = false;
            WinnerCamera.rect = new Rect(0f, 0f, 1f, 1f);
            LoserCamera.enabled = false;
            Canvas1.SetActive(false);
            Canvas2.SetActive(false);
            PlayerNumberText.text = "Two";
            EndOfGameAnimator.SetBool("GameOver", true);
        }
    }
}
