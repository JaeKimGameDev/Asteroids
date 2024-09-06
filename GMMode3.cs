using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMMode3 : MonoBehaviour
{
    public void PlayGame()
    {
        //FindObjectOfType<AudioManager>().Play("buttonClick");
        SceneManager.LoadScene("GrowRandomBall");
    }
}
