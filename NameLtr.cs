using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameLtr : MonoBehaviour
{
    public Text letter;
    private char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    int i = 0;
  

    public void ChoseChar()
    {
        for (int j=0; j < 2; j++)
        {
            letter.text = ("" + alpha[i]);
        }
        i++;
        if (i == alpha.Length)
        {
            i = 0;
        }
    }
    
}
