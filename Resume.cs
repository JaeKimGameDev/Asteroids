﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    
    // Start is called before the first frame update

    public GameObject Panel;

    public void OpenPanel()
    {
        if (Panel == null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(isActive);
        }
        Time.timeScale = 1;
    }
}
