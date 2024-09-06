using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameNum : MonoBehaviour
{
    public Text num;
    private char[] alpha = "0123456789".ToCharArray();
    int i = 0;


    public void ChoseChar()
    {
        for (int j = 0; j < 2; j++)
        {
            num.text = ("" + alpha[i]);
        }
        i++;
        if (i == alpha.Length)
        {
            i = 0;
        }
    }

}
