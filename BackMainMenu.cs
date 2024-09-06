using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMainMenu : MonoBehaviour
{
    public void Back()
    {
        //FindObjectOfType<AudioManager>().Play("buttonClick");
        SceneManager.LoadScene("Menu");
    }
}
