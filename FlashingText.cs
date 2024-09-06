using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlashingText : MonoBehaviour
{
    public float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.5)
        {
            GetComponent<TextMeshProUGUI>().enabled = true;
        }
        if (timer >= 1)
        {
            GetComponent<TextMeshProUGUI>().enabled = false;
            timer = 0;
        }
        
    }
}
