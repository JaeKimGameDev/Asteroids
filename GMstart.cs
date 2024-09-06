using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMstart : MonoBehaviour
{
    public void PlayGame()
    {
        //FindObjectOfType<AudioManager>().Play("buttonClick");
        SceneManager.LoadScene("ClassicLevel");
    }
}
