using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantTrade : MonoBehaviour
{
    [SerializeField]
    private GameObject TradeUI;

    [SerializeField]
    private GameObject Interactionprompt;

    [SerializeField]
    private RandomMovement randomMovement;

    [SerializeField]
    private FirstPersonCamera firstPersonCamera;


    private void OnTriggerEnter(Collider other)
    {
        //Interactionprompt.SetActive(true);
        //randomMovement.setInteractingStatus(true);
        //if (Input.GetKey(KeyCode.E))
        //{
        //    Interactionprompt.SetActive(false);
        //    TradeUI.SetActive(true);
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        Interactionprompt.SetActive(true);
        randomMovement.setInteractingStatus(true);
        firstPersonCamera.enabled = false;
        if (Input.GetKey(KeyCode.E))
        {
            Cursor.visible = true;
            
            Interactionprompt.SetActive(false);
            TradeUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Cursor.visible = false;
        Interactionprompt.SetActive(false);
        TradeUI.SetActive(false);
        randomMovement.setInteractingStatus(false);
        firstPersonCamera.enabled = true;
    }

}
