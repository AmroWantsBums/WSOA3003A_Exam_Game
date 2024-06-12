using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player2Health : MonoBehaviour
{
    public float HealthPoints = 200f;
    public Animator animator;
    public Slider HealthBar;
    public GunController gunController;
    public Player2GunController Player2gunController;
    public Camera WinnerCamera;
    public Camera LoserCamera;
    public GameObject Canvas1;
    public GameObject Canvas2;
    public Animator EndOfGameAnimator;
    public TextMeshProUGUI PlayerNumberText;
    public Player2Movement player2Movement;
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
            gunController.enabled = false;
            Player2gunController.enabled = false;
            player2Movement.enabled = false;
            WinnerCamera.rect = new Rect(0f, 0f, 1f, 1f);
            LoserCamera.enabled = false;
            Canvas1.SetActive(false);
            Canvas2.SetActive(false);
            PlayerNumberText.text = "One";
            EndOfGameAnimator.SetBool("GameOver", true);
            StartCoroutine(RestartGame());
        }
        HealthBar.value = HealthPoints;
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("MenuScene");
    }
}
