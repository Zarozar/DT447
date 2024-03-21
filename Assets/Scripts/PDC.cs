using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDC : MonoBehaviour
{
    [SerializeField]
    private string Feather_String;
    [SerializeField]
    private string Drink_String;
    [SerializeField]
    private string Fakes_String;

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
