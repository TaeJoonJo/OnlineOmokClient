using APIServer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailInformation : MonoBehaviour
{
    public GameObject InfoPanel;

    public Text SendDateTimeText;
    public Text SenderNameText;
    public Text InSenderNameText;

    public Text ContenttText;
    public Text MailReceiveDateText;

    public Button CloseButton;
    public Button ReceiveButton;

    string SendDateTime;
    
    string SenderName;
    string Content;

    int ItemKind;
    int ItemCount;

    string MailReceiveDate;
    string ItemReceiveDate;

    public void Init(MailInfo mailInfo)
    {
        //SenderName = mailInfo.Se
        Content = mailInfo.Content;
        ItemKind = mailInfo.Kind;
        //MailReceiveDate = mailInfo.MailReceiveDate;
        //ItemCount = mailInfo.

        SendDateTimeText.text = ItemKind.ToString();
        SenderNameText.text = Content;

        //InSenderNameText.text = SenderName;
        ContenttText.text = Content;
        MailReceiveDateText.text = MailReceiveDate;
    }
    
    public void OnClick()
    {
        InfoPanel.SetActive(true);
    }

    public void OnClickClose()
    {
        InfoPanel.SetActive(false);
    }

    public void OnClickReceiveButton()
    {
        GameManager.ClientNetworkManager.GetItemConfirm(GameManager.ClientNetworkManager.connectedIdx);
    }
}
