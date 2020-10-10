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
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public float displayImageDuration = 1f;

    //member variables
    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;

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
    private void Update()
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if(m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    //restarts or ends the game by playing an appropriate UI image
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
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
                Application.Quit();
            }
    }
}
