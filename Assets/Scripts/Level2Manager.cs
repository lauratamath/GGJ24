using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Manager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject player;
    
    private bool isPaused;

    private void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                pauseMenu.SetActive(true);
                player.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
                player.GetComponent<ScaleWithInput>().enabled = false;
            } else
            {
                UnpauseMenu();
            }
        }
    }

    public void UnpauseMenu()
    {
        pauseMenu.SetActive(false);
        player.GetComponent<ScaleWithInput>().enabled = true;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
