using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSplashScreen : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Splash Screen");
    }
}
