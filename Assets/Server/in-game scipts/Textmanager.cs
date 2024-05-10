using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Message
{
    public string text;
    public TextMeshProUGUI textObject;
}

public class Textmanager : MonoBehaviour
{
    [SerializeField]
    private int maxMessages = 25;

    [SerializeField]
    private GameObject chatPanel, textObject;

    [SerializeField]
    private TMP_InputField chatBox;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    private void Start()
    {

    }

    
    private void Update()
    {
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(chatBox.text);
                chatBox.text = "";
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            { 
                chatBox.ActivateInputField();
            }
        }
         
        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                SendMessageToChat("You press h ");
            }
        }
    }

    public void SendMessageToChat(string text)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }  

        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newtext = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newtext.GetComponent<TextMeshProUGUI>();

        newMessage.textObject.text = newMessage.text;

        messageList.Add(newMessage);
    }
}
