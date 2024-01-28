using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneWin : MonoBehaviour
{
    public GameObject winDisplay;

    private void Start()
    {
        if (winDisplay) winDisplay.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winDisplay.SetActive(true);
        } 
    }
}
