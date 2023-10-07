using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Pause : MonoBehaviour
{
    public bool paused = false;
    [SerializeField] private GameObject menu;
    [SerializeField] private KeyCode pause;
    void Update()
    {
        if (Input.GetKeyDown(pause))
        {
            if (paused)
                paused = false;
            else
                paused = true;
            if (paused)
            {
                Time.timeScale = 0;
                menu.SetActive(true);
            }
            else if (!paused)
            {

                Time.timeScale = 1;
                menu.SetActive(false);
            }
        }
        
    }
    public void SetPause()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
        }
        else
        {
            paused = true;
            Time.timeScale = 0;
        }
    }
    public bool GetPause()
    {
        return paused;
    }
    public GameObject GetMenu() { return menu; }
}
