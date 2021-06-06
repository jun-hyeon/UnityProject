using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float waitingTime = 1.5f;
    public bool end = false;
    public bool ready = true;
    public GameObject cactus;
    public GameObject bird;
    public AudioClip deathSound;
    public AudioClip goalSound;
    public int score;
    public TextMesh scoreText;
    public TextMesh finishScoreText;
    public TextMesh bestScoreText;
    public GameObject getReadyImg;
    public GameObject readyTapImg;
    public GameObject gameOverImg;
    public GameObject finishWindow;
    public GameObject newImg;

    private Rigidbody birdRb;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        birdRb = bird.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip ac)
    {
        audioSource.clip = ac;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ready == true)
        {
            ready = false;
            InvokeRepeating("MakeCactus", 1f, waitingTime);
            birdRb.useGravity = true;//반복실행
            iTween.FadeTo(getReadyImg, iTween.Hash("alpha", 0, "time", 0.5f));
            iTween.FadeTo(readyTapImg, iTween.Hash("alpha", 0, "time", 0.5f));
        }        
    }

    public void GameOver()
    {
        if (end) return;
        end = true;
        CancelInvoke("MakeCactus");
        iTween.ShakePosition(Camera.main.gameObject,
            iTween.Hash("x", 0.2, "y", 0.2, "time", 0.5f));
        iTween.FadeTo(gameOverImg, iTween.Hash("alpha", 255, "delay", 1f, "time", 0.5f));
        iTween.MoveTo(finishWindow, iTween.Hash("y", 1.5, "delay", 1.3f, "time", 0.5f));
        PlaySound(deathSound);
        if(score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
            newImg.SetActive(true);
        }else if(score <= PlayerPrefs.GetInt("BestScore"))
        {
            newImg.SetActive(false);
        }

        finishScoreText.text = score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
    }

    public void GetScore()
    {
        PlaySound(goalSound);
        score += 1;
        scoreText.text = score.ToString();
    }

    void MakeCactus()
    {
        Instantiate(cactus); // 복사
    }
}
