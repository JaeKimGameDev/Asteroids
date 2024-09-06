using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public GameObject Panel;

    public void QuitToMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void SelectGameMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void PanelControl()
    {
        // if panel is open then pause the game
        if (Panel != null)
        {
            Time.timeScale = 0;
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }

       // if panel is closed resume the game
        else if (Panel == null)
        {
            
            bool isActive = Panel.activeSelf;
            Panel.SetActive(isActive);
            //Time.timeScale = 1;
            
        }

        //Time.timeScale = 1;
  
    }

    public void Unpause()
    {
       Time.timeScale = 1;
    }
}
