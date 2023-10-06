using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Pause : MonoBehaviour
{
    private bool paused = false;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private KeyCode pause;
    void Update()
    {
        if (Input.GetKeyDown(pause))
        {
            if (paused)
                paused = false;
            else
                paused = true;
        }
        if (paused)
        {
            Time.timeScale = 0;
            continueButton.enabled = true;
            restartButton.enabled = true;
            menuButton.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            continueButton.enabled = false;
            restartButton.enabled = false;
            menuButton.enabled = false;
        }
    }
}
