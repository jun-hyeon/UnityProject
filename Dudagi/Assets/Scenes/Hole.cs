using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    Animator ani;
    bool touchPossible = false;
    bool is_bomb = false;
    AudioSource audioSource;

    public AudioClip openSound;
    public AudioClip hitSound;
    public AudioClip bombSound;
    public GameManager m_gameManager;
    void Start()
    {
        ani = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Open()
    {
        touchPossible = true;
        audioSource.clip = openSound;
        audioSource.Play();

        if(m_gameManager.gState == GameState.Ready)
        {
            m_gameManager.Go();
        }
    }
    public void Close()
    {
        touchPossible = false;
    }

    public void OnMouseDown()
    {
        if(touchPossible)
        {
            touchPossible = false;
            ani.SetTrigger("isTouch");
            if(is_bomb)
            {
                audioSource.clip = bombSound;
                audioSource.Play();
                m_gameManager.gameScore -= 3;
            }
            else
            {
                audioSource.clip = hitSound;
                audioSource.Play();
                m_gameManager.gameScore += 1;
            }       
        }
    }

    public IEnumerator End()
    {
        float randomTime = Random.Range(1.0f, 3.0f);
        float randomD = Random.Range(0f, 10.0f);

        yield return new WaitForSeconds(randomTime);

        if (m_gameManager.gState != GameState.End)
        {
            if (randomD > 5.0f)
            {
                ani.SetTrigger("DuDaGi");
                is_bomb = false;
            }
            else
            {
                ani.SetTrigger("Bomb");
                is_bomb = true;
            }
        }
    }
    void Update()
    {
        
    }
}
