using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    //public variables
    public float fadeDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;
    public float displayImageDuration = 1f;
    public PlayerMovement playerMovement;
    public EnemyHealth enemyHealth;
    public GameObject goldImageObject;
    public GameObject goldTextObject;
    public GameObject silverImageObject;
    public GameObject silverTextObject;


    //member variables
    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;
    bool m_PlayerWasFast;

    float timeCurrent = 0f;

    private void Start()
    {
        goldImageObject.SetActive(false);
        goldTextObject.SetActive(false);
        silverImageObject.SetActive(false);
        silverTextObject.SetActive(false);

        m_PlayerWasFast = false;
    }

    //detect player hit win box
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    //public method that called to indicate the player has been caught
    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    //is called every frame; checks for status changes
    //ends level and sets appropriate parameters
    private void Update()
    {
        if(playerMovement.enemyCount <= 0)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if(playerMovement.isPlayerCaught == true)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }

        timeCurrent += Time.deltaTime;
       
    }

    //restarts or ends the game by playing an appropriate UI image
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if(!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;

        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(doRestart)
            {
            if (m_Timer > fadeDuration + displayImageDuration)
            {
                SceneManager.LoadScene(0);
            }
            }
            else if(m_Timer > fadeDuration + displayImageDuration)
            {
                if (timeCurrent <= 65)
                {
                    goldImageObject.SetActive(true);
                    goldTextObject.SetActive(true);
                    m_PlayerWasFast = true;
                    Application.Quit();
                }
                else
                {
                    if (m_PlayerWasFast == false)
                    {
                        silverImageObject.SetActive(true);
                        silverTextObject.SetActive(true);
                        Application.Quit();
                    }
                    
                }
            }
    }
}
