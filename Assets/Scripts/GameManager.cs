using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int NoOfFeathers = 0;
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;
    [SerializeField]
    private TextMeshProUGUI VictoryText;

    [SerializeField]
    private GameObject KeyLight;
    private Light FinalLight;

    private int maxNoOfFeathers = 4;



    // Start is called before the first frame update
    void Start()
    {
        FinalLight = KeyLight.GetComponent<Light>();
        FinalLight.gameObject.SetActive(false);

        textMeshProUGUI.text = "No Of Feathers: " + NoOfFeathers.ToString() + " / " + maxNoOfFeathers.ToString();
        VictoryText.gameObject.SetActive(false);
        //foreach (Transform t in Spawnlocation)
        //{
        //    Instantiate(Feather, t);
        //}

    }

    private void Update()
    {
        if (NoOfFeathers >= 3)
        {
            FinalLight.gameObject.SetActive(true);
        }

        if (NoOfFeathers == maxNoOfFeathers)
        {
            //SceneManager.LoadScene("End");
            VictoryText.gameObject.SetActive(true);
            
        }
       
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //public void OnStageCompleted()
    //{
    //    Debug.Log("SpawnFeather");
    //    Instantiate(Feather, SpawnlocationBase);
    //}

    public void IncrementFeatherCount()
    {
        NoOfFeathers++;
        textMeshProUGUI.text = "No Of Feathers: " + NoOfFeathers.ToString() + " / " + maxNoOfFeathers.ToString();
    }
}