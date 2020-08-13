﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System;
using GatewayServer.Packet;
using APIServer;
using MessagePack;

public class LobbySceneManager : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject MenuPanel;
    public GameObject AttendancePanel;
    public GameObject InfoPanel;
    public GameObject MailPanel;
    static public GameObject GameInfoPanel;

    public GameObject attendanceButton;
    public GameObject closeButton;
    public GameObject attendanceConfirmButton;
    public GameObject mailButton;

    public GameObject LoadingPanel;
    public RectTransform LoadingProgress;
    const float RotateSpeed = 200f;

    public Text InfoText;
    public ScrollView MailScrollView;

    public GameObject GameMailInfo;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.RecvMatchingResult += RecvMatchingResult;

       // GameInfoPanel = GameObject.Find("MailUnfoPanel").gameObject;
       // GameInfoPanel.SetActive(false);
       // GameManager.ClientNetworkManager.GetMail(3);
    }
     
    // Update is called once per frame
    void Update()
    {
        if(LoadingPanel.activeSelf == true)
        {
            LoadingProgress.Rotate(0f, 0f, RotateSpeed * Time.deltaTime);
        }
    }

    public void ClickMatchingStart()
    {
        SendMatching();

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
            Debug.Log("출석 반환 값 :" +attendanceResult);
            if (attendanceResult == 101) NewInfo("7일차 출석 완료");
            else if (attendanceResult == 0) NewInfo("출석 완료");
            else NewInfo("이미 출석 했습니다.");
        }
    }

    public void ClickMailButton()
    {
        MailPanel.SetActive(true);
      
        var mails = GameManager.ClientNetworkManager.GetMails(GameManager.ClientNetworkManager.connectedIdx);

        foreach(var mail in mails)
        {
            InsertMailButton(mail);
        }
    }
   

    public static void ClickMailInfoButton()
    {
        GameInfoPanel.SetActive(true);

    }

    public void InsertMailButton(MailInfo mailInfo)
    {
        var mail = Instantiate(GameMailInfo);
        var mailInformation = mail.GetComponent<MailInformation>();
        mailInformation.Init(mailInfo);


        mail.transform.SetParent(GameObject.Find("Content").transform);
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

    void SendMatching()
    {
        var packetData = new PKTReqMatching();
        packetData.MatchingType = 0;

        var packet = MessagePackSerializer.Serialize(packetData);
        var sendPacket = PacketDef.PKTHandleHelper.MakePacket((UInt16)PacketDef.ClientGatePacketID.ReqMatching, packet);

        GameManager.ClientNetworkManager.Send(sendPacket);
    }

    void SendEnterRoom()
    {
        var packetData = new PKTReqRoomEnter();

        var packet = MessagePackSerializer.Serialize(packetData);
        var sendPacket = PacketDef.PKTHandleHelper.MakePacket((UInt16)PacketDef.ClientGatePacketID.ReqRoomEnter, packet);

        GameManager.ClientNetworkManager.Send(sendPacket);
    }

    void RecvMatchingResult(object data)
    {
        var result = (UInt16)data;

        Debug.Log($"RecvMatchingResult : [{result}]");

        if(result == 0)
        {
            SendEnterRoom();

            LoadingPanel.SetActive(true);
        }
    }
}
