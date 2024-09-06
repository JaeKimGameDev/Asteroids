using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDefaults : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Get required information that always saves data (DON'T DESTROY ON LOAD)
        GameDataTracker getData = Object.FindObjectOfType<GameDataTracker>();

        getData.numberOfBalls = 4;
        getData.GameScore = 0;
        getData.PlayerLives = 3;
        getData.gameLevel = 1;
        getData.timer = 55.0f;
    }
}
