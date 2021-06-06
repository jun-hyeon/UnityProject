using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum GameState
{
    Ready,
    Play,
    End
}
public class GameManager : MonoBehaviour
{
    public GameState gState;
    public AudioClip readySound;
    public AudioClip goSound;
    public int gameScore;
    public float limitTime;
    public TextMeshPro timeText;
    public TextMeshPro scoreText;
    public GameObject blackImg;
    public TextMeshPro endScoreText;
    public TextMeshPro highScoreText;
    public GameObject finalWindow;
    public GameObject btn;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = readySound;
        audioSource.Play();
        timeText.text = limitTime.ToString("N2");
        scoreText.text = gameScore.ToString();
    }

    public void Go()
    {
        gState = GameState.Play;
        audioSource.clip = goSound;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(gState == GameState.Play)
        {
            limitTime -= Time.deltaTime;
            if(limitTime <=0)
            {
                limitTime = 0;
                GameOver();
                //°ÔÀÓ ³¡!!
            }
            timeText.text = limitTime.ToString("N2");
            scoreText.text = gameScore.ToString();
        }
    }
    void GameOver()
    {
        gState = GameState.End;
        iTween.FadeTo(blackImg, iTween.Hash("alpha", 180, "delay"
            , 0.1f, "time", 0.5f));
        iTween.MoveTo(finalWindow, iTween.Hash("y", 0, "delay", 0.5f, "time", 0.5f));

        if(gameScore > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", gameScore);
        }

        endScoreText.text = gameScore.ToString();
        highScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
    public void GameReset()
    {
        SceneManager.LoadScene("MainScene");
    }
}
