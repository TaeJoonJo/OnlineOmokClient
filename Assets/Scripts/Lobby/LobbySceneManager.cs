using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class LobbySceneManager : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject MenuPanel;
    public GameObject AttendancePanel;
    public GameObject InfoPanel;

    public GameObject attendanceButton;
    public GameObject closeButton;
    public GameObject attendanceConfirmButton;
    public Text InfoText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ClickMatchingStart()
    {
        SceneManager.LoadScene(Common.InGameSceneName);
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
        string connectedIdTemp = GameManager.ClientNetworkManager.connectedId;
        if (connectedIdTemp == "") NewInfo("먼저 로그인 해주세요");
        else
        {
            int attendanceResult = GameManager.ClientNetworkManager.AttendanceConfirm(connectedIdTemp);
            if (attendanceResult == 101) NewInfo("7일차 출석 완료");
            else if (attendanceResult == 0) NewInfo("출석 완료");
            else NewInfo("이미 출석 했습니다.");
        }
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
