using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeLeft : MonoBehaviour
{
    public float timer;
    public TextMeshProUGUI countDown1, countDown2;

    // Start is called before the first frame update
    void Start()
    {
        GameDataTracker getData = Object.FindObjectOfType<GameDataTracker>();
        if (timer != 30.0f)
        {
            getData.GameScore = getData.GameScore + (int)(getData.timer * 1.33);
        }
        getData.timer = 30.0f;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        GameDataTracker getData = Object.FindObjectOfType<GameDataTracker>();
        getData.timer -= Time.deltaTime;
        
        countDown1.text = ("" + getData.timer.ToString("F2"));
        countDown2.text = ("" + getData.timer.ToString("F2"));

        if (getData.timer <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
