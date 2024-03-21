using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int NoOfFeathers = 0;
    private int NoOfDrinks = 0;
    private int NoOfFakes = 0;
    [SerializeField]
    private TextMeshProUGUI feathersTUI;
    [SerializeField]
    private TextMeshProUGUI drinksTUI;
    [SerializeField]
    private TextMeshProUGUI fakesTUI;
    [SerializeField]
    private TextMeshProUGUI VictoryText;
    [SerializeField]
    private TextMeshProUGUI PlayerText;

    [SerializeField]
    private GameObject KeyLight;
    private Light FinalLight;

    private int maxNoOfFeathers = 4;
    private int maxNoOfDrinks = 4;
    private int maxNoOfFakes = 1;

    [SerializeField]
    private PDC playerDialogue;

    

    // Start is called before the first frame update
    void Start()
    {
        FinalLight = KeyLight.GetComponent<Light>();
        FinalLight.gameObject.SetActive(false);

        feathersTUI.text = "No Of Feathers: " + NoOfFeathers.ToString() + " / " + maxNoOfFeathers.ToString();
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
        feathersTUI.text = "No Of Feathers: " + NoOfFeathers.ToString() + " / " + maxNoOfFeathers.ToString();
        PlayerText.gameObject.SetActive(true);
        PlayerText.text = playerDialogue.GetFeatherText().ToString();
        StartCoroutine(TextExpire());
    }

    public void IncrementDrinksCount()
    {
        NoOfDrinks++;
        drinksTUI.text = "No Of Feathers: " + maxNoOfDrinks.ToString() + " / " + maxNoOfDrinks.ToString();
        PlayerText.gameObject.SetActive(true);
        PlayerText.text = playerDialogue.GetDrinkText().ToString();
        StartCoroutine(TextExpire());
    }

    public void IncrementFakesCount()
    {
        NoOfFakes++;
        fakesTUI.text = "No Of Fakes: " + maxNoOfFakes.ToString() + " / " + maxNoOfFakes.ToString();
        PlayerText.gameObject.SetActive(true);
        PlayerText.text = playerDialogue.GetFakesText().ToString();
        StartCoroutine(TextExpire());
    }

    private IEnumerator TextExpire()
    {
        yield return new WaitForSeconds(1.25f);   
        PlayerText.gameObject.SetActive(false);
        StopCoroutine(TextExpire());
    }
}