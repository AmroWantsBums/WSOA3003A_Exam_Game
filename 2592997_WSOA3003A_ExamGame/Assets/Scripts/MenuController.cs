using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject VideoObject;
    public VideoPlayer TutorialVideo;
    public GameObject ControlsPanel;
    // Start is called before the first frame update
    void Start()
    {
        TutorialVideo.loopPointReached += OnVideoFinished;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVideo()
    {
        VideoObject.SetActive(true);
        TutorialVideo.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        VideoObject.SetActive(false);
        ControlsPanel.SetActive(true);
    }

    void OnDestroy()
    {
        TutorialVideo.loopPointReached -= OnVideoFinished;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
