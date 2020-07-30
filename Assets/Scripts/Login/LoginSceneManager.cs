using MessagePack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LoginSceneManager : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject SignupPanel;

    public Text InfoText;

    public InputField IDInputField;
    public InputField PWInputField;

    public InputField SignupIDInputField;
    public InputField SignupPWInputField;

    string LastInfoString;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickLogin()
    {
        GameManager.ClientNetworkManager.Connect("127.0.0.1", 32452);

        var userID = IDInputField.text;
        var userPW = PWInputField.text;
        if(userID.Length < 1 ||
            userPW.Length < 1)
        {
            NewInfo("아이디와 비밀번호를 입력해야 합니다.");
            return;
        }

        SendLogin(userID, userPW);
        //SceneManager.LoadScene(Common.LobbySceneName);
    }

    public void ClickSignup()
    {
        SignupPanel.SetActive(true);
    }

    public void ClickSignupOk()
    {
        GameManager.ClientNetworkManager.Connect("127.0.0.1", 32452);

        var userID = SignupIDInputField.text;
        var userPW = SignupPWInputField.text;
        if (userID.Length < 1 ||
            userPW.Length < 1)
        {
            NewInfo("아이디와 비밀번호를 입력해야 합니다.");
            return;
        }

        SignupIDInputField.text = "";
        SignupPWInputField.text = "";

        SignupPanel.SetActive(false);
    }

    public void ClickSignupCancle()
    {
        SignupIDInputField.text = "";
        SignupPWInputField.text = "";

        SignupPanel.SetActive(false);
    }

    public void ClickExit()
    {
        Application.Quit();
    }

    public void ClickInfoOk()
    {
        InfoPanel.SetActive(false);
    }

    public void NewInfo(string infoString)
    {
        LastInfoString = infoString;
        InfoText.text = LastInfoString;

        InfoPanel.SetActive(true);
    }

    public void SendLogin(string userID, string userPW)
    {
        var request = new GatewayServer.PKTReqLogin() { UserID = userID, AuthToken = userPW };

        var body = MessagePackSerializer.Serialize(request);
        var sendPacket = PacketDef.PKTHandleHelper.MakePacket((UInt16)GatewayServer.ClientGatePacketID.ReqLogin, body);

        GameManager.ClientNetworkManager.Send(sendPacket);
    }

    public void RecvLoginResult(UInt16 result)
    {
        Debug.Log("loginresult : " + result);

        if(result != 0)
        {
            NewInfo("로그인 실패!");
            return;
        }

        SceneManager.LoadScene(Common.LobbySceneName);
    }
}
