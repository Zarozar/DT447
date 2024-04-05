using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{
    //random num 0-3 correlates to colour.

    [SerializeField]
    private Image[] collectiblesInven;

    public void AdjustColColor(int colorCode, int NoofCollectibles)
    {
        if (colorCode == 0)
        {
            collectiblesInven[NoofCollectibles].color = Color.green;
        }
        else if (colorCode == 1)
        {
            collectiblesInven[NoofCollectibles].color = Color.yellow;
        }
        else if (colorCode == 2)
        {
            collectiblesInven[NoofCollectibles].color = Color.red;
        }
        else if (colorCode == 3)
        {
            collectiblesInven[NoofCollectibles].color = Color.blue;
        }


        collectiblesInven[NoofCollectibles].gameObject.SetActive(true);

    }
}
