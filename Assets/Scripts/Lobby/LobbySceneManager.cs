using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System;
using GatewayServer.Packet;
using APIServer;

public class LobbySceneManager : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject MenuPanel;
    public GameObject AttendancePanel;
    public GameObject InfoPanel;
    public GameObject MailPanel;

    public GameObject attendanceButton;
    public GameObject closeButton;
    public GameObject attendanceConfirmButton;
    public GameObject mailButton;
    public Text InfoText;
    public Text mailuser;
    public Text mailsender;

    public ScrollView MailScrollView;

    public GameObject GameMailInfo;

    // Start is called before the first frame update
    void Start()
    {
       // GameManager.ClientNetworkManager.GetMail(3);
    }
     
    // Update is called once per frame
    void Update()
    {

    }

    public void ClickMatchingStart()
    {
        var packet = new PKTReqLobbyEnter() { };

        //SceneManager.LoadScene(Common.InGameSceneName);
    }

    public void ClickTmp()
    {

    }

    public void ClickTmp2()
    {

    }

    public void ClickMenuButton()
    {
        // TODO : MainPanel UI못건들게 설정
        

        MenuPanel.SetActive(true);
        
    }

    public void Test()
    {
        //var mailInfo = new MailInfo();
        //var mailInfo = new MailInfo();

        var game = Instantiate(GameMailInfo);
        //MailScrollView.Add()
        game.transform.SetParent(GameObject.Find("Content").transform);
    }

    public void ClickMenuDisconnectButton()
    {
        // TODO : 서버에 접속종료 요청
        SceneManager.LoadScene(Common.LoginSceneName);
    }

    public void ClickMenuOptionButton()
    {
        
    }

    public void ClickMenuContinueButton()
    {
        // TODO : MainPanel UI 다시 건들게 설정

        MenuPanel.SetActive(false);
    }
    public void ClickAttendanceButton()
    {
        AttendancePanel.SetActive(true);
    }
    public void ClickattendanceConfirmButton()
    {
        var userNo = GameManager.ClientNetworkManager.connectedIdx;
        if (userNo == 0) NewInfo("먼저 로그인 해주세요");
        else
        {
            int attendanceResult = GameManager.ClientNetworkManager.AttendanceConfirm((int)userNo);
            if (attendanceResult == 101) NewInfo("7일차 출석 완료");
            else if (attendanceResult == 0) NewInfo("출석 완료");
            else NewInfo("이미 출석 했습니다.");
        }
    }

    public void ClickMailButton()
    {
        MailPanel.SetActive(true);
        Debug.Log("사용자 : " + GameManager.ClientNetworkManager.connectedIdx);
        //GameManager.ClientNetworkManager.GetMail(7);
       GameManager.ClientNetworkManager.GetMail(GameManager.ClientNetworkManager.connectedIdx);
      //GameManager.ClientNetworkManager.GetMail(3);
        mailsender.text  = (GameManager.ClientNetworkManager.mailinfolist[0].SenderNo).ToString();
        Debug.Log("어째저째 끝남");
    }

    public void ClickCloseButton()
    {
        AttendancePanel.SetActive(false);
    }

    public void NewInfo(string infoString) { 
        InfoText.text = infoString;
        InfoPanel.SetActive(true);
    }

    public void ClickInfoOk()
    {
        InfoPanel.SetActive(false);
    }

    
}
