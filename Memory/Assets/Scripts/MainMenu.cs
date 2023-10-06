using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //rules.enabled = true;
        //if (Input.GetKeyDown(keycode))
        //{

            
        //    //rules.enabled = false;
        //}
    }
    
    public void ExitGame()
    {
        Debug.Log("Closed game");
        Application.Quit();
    }
}