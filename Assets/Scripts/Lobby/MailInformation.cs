using APIServer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailInformation : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject GetItemPanel;

    // public Text SenderNameText;
    //public Text InSenderNameText;

    public Text ContentText;
    public Text MailReceiveDateText;
    public Text InMailReceiveDateText;
    public Text SenderNameText;
    public Text GetItemText;
    public Button CloseButton;
    public Button ReceiveButton;
    public Button GetItemCloseButton;

    string SendDateTime;

    string SenderName;
    string Content;

    int ItemKind;
    int ItemCount;
    int mailIndex;
    string MailReceiveDate;

    public void Init(MailInfo mailInfo)
    {
        // SenderName = mailInfo.SenderNo;

        Content = mailInfo.Content;
        ItemKind = mailInfo.Kind;
        ItemCount = mailInfo.ItemCount;
        MailReceiveDate = mailInfo.MailReceiveDate;
        mailIndex = mailInfo.MailIdx;
        if (mailInfo.SenderNo == 0) SenderName = "관리자";
        /*
        else
        {
            //레디스
        }
        */
        SenderNameText.text = SenderName;
        MailReceiveDateText.text = MailReceiveDate;
        InMailReceiveDateText.text = MailReceiveDate;
        //SenderNameText.text = Content;

        //InSenderNameText.text = SenderName;
        ContentText.text = Content;
    }

    public void OnClick()
    {
        InfoPanel.SetActive(true);

        var contentsPanel = GameObject.Find("MailPanel");
        InfoPanel.transform.SetParent(contentsPanel.transform);
        InfoPanel.transform.localPosition = Vector3.zero; 
    }

    public void OnClickClose()
    {
       //InfoPanel.transform.SetParent(transform);
        InfoPanel.SetActive(false);
    }
    
    //여기서 프리팹도 없어져야 함 ㅠ ㅠ
    public void OnClickGetItemCloseButton()
    {
        InfoPanel.SetActive(false);
        GetItemPanel.SetActive(false);
    }

    public void OnClickReceiveButton()
    {
        var reply = GameManager.ClientNetworkManager.GetItemConfirm(GameManager.ClientNetworkManager.connectedIdx, ItemKind, ItemCount, mailIndex);
        Debug.Log(reply);
        if (reply == 0) NewInfo("아이템을 수령하였습니다. ");
        else NewInfo("다시 시도해주세요");
    }

    public void NewInfo(string infoString)
    {
        GetItemText.text = infoString;

        var contentsPanel = GameObject.Find("MailPanel");
        GetItemPanel.transform.SetParent(contentsPanel.transform);
        GetItemPanel.transform.localPosition = Vector3.zero;
        GetItemPanel.SetActive(true);
    }
}
