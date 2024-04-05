using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PDC : MonoBehaviour
{
    [SerializeField]
    private string Feather_String;
    [SerializeField]
    private string Drink_String;
    [SerializeField]
    private string Fakes_String;

    [SerializeField]
    private string[] Gach_string;

    public string GetGachaText(int colorcode)
    {
        if (colorcode == 0)
        {
            return Gach_string[0];
        }
        else if (colorcode == 1)
        {
            return Gach_string[1];
        }
        else if (colorcode == 2)
        {
            return Gach_string[2];
        }
        else
        { 
            return Gach_string[3];
        }
        
    }

    public string GetFeatherText()
    {
        return Feather_String;
    }

    public string GetDrinkText()
    {
        return Drink_String;
    }

    public string GetFakesText()
    {
        return Fakes_String;
    }

}
