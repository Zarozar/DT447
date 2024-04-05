using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int NoOfFeathers = 0;
    [SerializeField]
    private int NoOfDrinks = 0;
    private int NoOfFakes = 0;
    private int NoOfGCount = 0;

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
    private GameObject TradeUI_GM;

    [SerializeField]
    private GameObject KeyLight;
    private Light FinalLight;

    [SerializeField]
    private int maxNoOfFeathers = 4;
    [SerializeField]
    private int maxNoOfDrinks = 4;
    [SerializeField]
    private int maxNoOfFakes = 1;


    [SerializeField]
    private TextMeshProUGUI gCountTUI;

    [SerializeField]
    private PDC playerDialogue;

    [SerializeField]
    private MerchantTrade merchantTrade;

    [SerializeField]
    private TextMeshProUGUI merchantText;

    [SerializeField]
    private Collectables collectManager;

    [SerializeField]
    private string[] merchantSpeeches1 = {"Greetings", "Hi", "Hello"};
    [SerializeField]
    private string[] merchantSpeeches2 = { "Bye", "Good Deal", "Thanks" };


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        FinalLight = KeyLight.GetComponent<Light>();
        FinalLight.gameObject.SetActive(false);

        
        VictoryText.gameObject.SetActive(false);
        //foreach (Transform t in Spawnlocation)
        //{
        //    Instantiate(Feather, t);
        //}

    }

    private void Update()
    {
        feathersTUI.text = "No Of Feathers: " + NoOfFeathers.ToString() + " / " + maxNoOfFeathers.ToString();
        drinksTUI.text = "No Of Drinks: " + NoOfDrinks.ToString() + " / " + maxNoOfDrinks.ToString();
        fakesTUI.text = "No Of Fakes: " + NoOfFakes.ToString() + " / " + maxNoOfFakes.ToString();
        gCountTUI.text = "No Of Gacha rolls: " + NoOfGCount.ToString();

        if (NoOfFeathers >= maxNoOfFeathers - 1)
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
        Debug.Log("increment, f");
        NoOfFeathers++;
        feathersTUI.text = "No Of Feathers: " + NoOfFeathers.ToString() + " / " + maxNoOfFeathers.ToString();
        gCountTUI.text = "No Of Gacha rolls: " + NoOfGCount.ToString();
        PlayerText.gameObject.SetActive(true);
        PlayerText.text = playerDialogue.GetFeatherText().ToString();
        StartCoroutine(TextExpire());
        NoOfGCount++;
    }

    public void IncrementDrinksCount()
    {
        NoOfDrinks++;
        drinksTUI.text = "No Of Drinks: " + NoOfDrinks.ToString() + " / " + maxNoOfDrinks.ToString();
        PlayerText.gameObject.SetActive(true);
        PlayerText.text = playerDialogue.GetDrinkText().ToString();
        StartCoroutine(TextExpire());
    }

    public void IncrementFakesCount()
    {
        NoOfFakes++;
        fakesTUI.text = "No Of Fakes: " + NoOfFakes.ToString() + " / " + maxNoOfFakes.ToString();
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

    private IEnumerator MerchantTextExpire()
    {
        yield return new WaitForSeconds(1.25f);
        merchantText.gameObject.SetActive(false);
        StopCoroutine(MerchantTextExpire());
    }

    public void RollItem()
    {
        if (NoOfGCount >= 0)
        {
            int r = Random.Range(0, 4);

            collectManager.AdjustColColor(r, NoOfGCount);
            PlayerText.gameObject.SetActive(true);
            NoOfGCount--;
            PlayerText.text = playerDialogue.GetGachaText(r).ToString();
            StartCoroutine(TextExpire());
        }
    }

    public void CloseTradeUI()
    { 
        TradeUI_GM.SetActive(false);
        merchantText.text = merchantSpeeches2[Random.Range(0, merchantSpeeches1.Length)];
        merchantText.gameObject.SetActive(true);
        StartCoroutine(MerchantTextExpire());
    }

    public void TradewMerchant()
    {
        merchantText.text = merchantSpeeches1[Random.Range(0, merchantSpeeches1.Length)];
        merchantText.gameObject.SetActive(true);
        StartCoroutine(MerchantTextExpire());
    }

}