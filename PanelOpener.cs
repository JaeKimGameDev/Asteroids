﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;

    public void OpenPanel()
    {
        
        if (Panel != null)
        {
            Time.timeScale = 0;
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
        Time.timeScale = 1;
    }
    
}
