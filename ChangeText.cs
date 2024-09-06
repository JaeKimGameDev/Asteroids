using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ChangeText : MonoBehaviour
{
    public TextMeshProUGUI countDown;
    public float timeleft = 5.0f;
    public string load;
    

    // Start is called before the first frame update
    void Start()
    {
        GameDataTracker getData = Object.FindObjectOfType<GameDataTracker>();
        //Need to limit numeber of balls with if statement

        if (getData.numberOfBalls <= 8)
        {
            getData.numberOfBalls++;
        }
        // Use else to make balls move faster  
        
        getData.gameLevel++;
        getData.GameScore = getData.GameScore + (int)(getData.timer * 1.33);
        getData.timer = 55.0f + (float)getData.numberOfBalls;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeleft -= Time.deltaTime;
        countDown.text = ("" + timeleft.ToString("F0"));
        if (timeleft <= 0)
        {
            SceneManager.LoadScene(load);
        }
    }
}
