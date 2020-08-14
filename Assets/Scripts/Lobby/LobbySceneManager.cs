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
using MessagePack;

public class LobbySceneManager : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject MenuPanel;
    public GameObject AttendancePanel;
    public GameObject InfoPanel;
    public GameObject MailPanel;
    public GameObject MailResultPanel;
    public GameObject FriendApplyPanel;
    public GameObject FriendApplyConfirmPanel;
    static public GameObject GameInfoPanel;

    public GameObject LoadingPanel;
    public RectTransform LoadingProgress;
    const float RotateSpeed = 200f;

    public Text InfoText;
    public ScrollView MailScrollView;

    public GameObject GameMailInfo;

    public Text LoadingText;
    public Text MailResultText;
    public Text FriendApplyConfirmText;
    public InputField UserFindTextField;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.RecvLobbyChat += RecvLobbyChat;
        GameManager.RecvMatchingResult += RecvMatchingResult;
        
        GameManager.RecvRoomEnter += RecvRoomEnter;
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
   
    public void OnClickMailPanelCloseButton()
    {
        MailPanel.SetActive(false);
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

        mail.transform.SetParent(GameObject.Find("Contents").transform);
    }

    public void ClickCloseButton()
    {
        AttendancePanel.SetActive(false);
    }

    public void OnClickFriendApplyButton()
    {
        FriendApplyPanel.SetActive(true);
    }

    public void OnClickFriendApplyPanelCloseButton()
    {
        FriendApplyPanel.SetActive(false);
    }

    public void OnClickInFriendApplyButton()
    {
        string nickname = UserFindTextField.text;
        var result = GameManager.ClientNetworkManager.FindFriendConfirm(nickname);

        if (result == 102) NewInfo("존재하지 않는 유저입니다.");
        else 
        {
            var applyresult = GameManager.ClientNetworkManager.FriendApplyConfirm(result);

            if (applyresult==0) NewInfo("신청완료");
            else NewInfo("이미 친구입니다.");
        }

    }
    public void FriendApplyConfirmInfo(string infoString)
    {
         FriendApplyConfirmText.text = infoString;
         FriendApplyPanel.SetActive(true);
    }

    public void NewInfo(string infoString) { 
        InfoText.text = infoString;
        InfoPanel.SetActive(true);
    }


    public void ClickInfoOk()
    {
        InfoPanel.SetActive(false);
    }

    void StartLoading()
    {
        LoadingText.text = "매칭중...";
        LoadingPanel.SetActive(true);
    }

    void SendMatching()
    {
        var packetData = new PKTReqMatching();
        packetData.MatchingType = 0;

        var packet = MessagePackSerializer.Serialize(packetData);
        var sendPacket = PacketDef.PKTHandleHelper.MakePacket((UInt16)PacketDef.ClientGatePacketID.ReqMatching, packet);

        GameManager.ClientNetworkManager.Send(sendPacket);

        StartLoading();
    }

    void SendRoomEnter()
    {
        var packetData = new PKTReqRoomEnter();

        var packet = MessagePackSerializer.Serialize(packetData);
        var sendPacket = PacketDef.PKTHandleHelper.MakePacket((UInt16)PacketDef.ClientGatePacketID.ReqRoomEnter, packet);

        GameManager.ClientNetworkManager.Send(sendPacket);
    }

    void RecvLobbyChat(object data)
    {
        var chat = (string)data;

        Debug.Log(chat);
    }

    void RecvMatchingResult(object data)
    {
        var result = (UInt16)data;

        Debug.Log($"RecvMatchingResult : [{result}]");

        if(result != 0)
        {
            LoadingPanel.SetActive(false);
            NewInfo("매칭에 실패하였습니다.");

            return;
        }

        SendRoomEnter();
    }

    void RecvRoomEnter(object data)
    {
        var result = (UInt16)data;

        Debug.Log($"RecvRoomEnterResult : [{ result }]");

        if(result != 0)
        {
            NewInfo("방 입장에 실패하였습니다.");
            return;
        }

        SceneManager.LoadScene(Common.InGameSceneName);

        //LoadingText.text = "다른 플레이어 기다리는 중...";
    }
}
