using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public static int timer = 120;
    

    bool gameEnd = false;
    public float restartDelay = 1f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
    

    public void GameOver()
    {
        // display game over option menu
        //SceneManager.LoadScene("");

        if (gameEnd == false)
        {
            gameEnd = true;
            Invoke("Restart", 2f);
        }

    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
   
}
