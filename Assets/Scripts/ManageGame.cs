using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour
{

    public int P1NumberBricks;
    public int P2NumberBricks;

    public GameObject p1Win;
    public GameObject p2Win;

    public GameObject[] P1Brick;
    public GameObject[] P2Brick;

    public AudioSource WinSound;
    public AudioSource BGSound;

    UnityEvent winEvent = new UnityEvent();
    bool hasWinner = false;
    bool flag = false;

    void Start()
    {
        winEvent.AddListener(PlaySound);
        HoldSound.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }

    void Update()
    {
        if (P2NumberBricks <= 0)
        {
            p1Win.SetActive(true);
            hasWinner = true;
        }
        else if (P1NumberBricks <= 0)
        {
            p2Win.SetActive(true);
            hasWinner = true;
        }

        if (Input.GetKeyUp(KeyCode.R))
            RestartGame();

        if (Input.GetKey(KeyCode.Escape)) 
        {
            HoldSound.Instance.gameObject.GetComponent<AudioSource>().Play();
            SceneManager.LoadScene(0);
        }
            

        if (hasWinner && winEvent != null)
        {
            winEvent.Invoke();
        }

        if (!hasWinner && flag)
        {
            winEvent.RemoveListener(PlaySound);
        }
    }

    public void P1LoseBrick()
    {
        Debug.Log("P1 Lose brick");
        P1NumberBricks--;
    }

    public void P2LoseBrick()
    {
        Debug.Log("P2 Lose brick");
        P2NumberBricks--;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void PlaySound()
    {
        flag = true;
        WinSound.Play();
        hasWinner = false;
        BGSound.volume = 0.1f;
    }
}
