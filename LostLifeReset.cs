using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class LostLifeReset : MonoBehaviour
{
    public TextMeshProUGUI countDown;
    public float timeleft = 5.0f;
    public string load;

    // Start is called before the first frame update
    void Start()
    {
        GameDataTracker getData = Object.FindObjectOfType<GameDataTracker>();

        getData.timer = 55.0f + (float)getData.numberOfBalls;
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        countDown.text = ("" + timeleft.ToString("F0"));
        if (timeleft <= 0)
        {
            SceneManager.LoadScene(load);
        }
    }
}
