using APIServer;
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

    public InputField       SignupIDInputField;
    public InputField       SignupPWInputField;
    public InputField       SignupNNInputField;
    public Dropdown         SignupGenderDropdown;
    public Dropdown         SignupAgeDropdown;

    string LastInfoString;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.RecvLoginResult += RecvLoginResult;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ClickLogin()
    {
        var userID = IDInputField.text;
        var userPW = PWInputField.text;
        if(userID.Length < 1 ||
            userPW.Length < 1)
        {
            NewInfo("아이디와 비밀번호를 입력해야 합니다.");
            return;
        }

        GameManager.ClientNetworkManager.Connect("127.0.0.1", 32452);
        SendLogin(userID, userPW);
        return;

        string tokenValue = GameManager.ClientNetworkManager.LoginConfirm(userID, userPW);
        if (tokenValue != "101")
        {
            GameManager.ClientNetworkManager.Connect("127.0.0.1", 32452);
            SendLogin(userID, tokenValue);
        }
        else
        {
            NewInfo("아이디와 비밀번호를 확인해주세요.");
        }

        //SceneManager.LoadScene(Common.LobbySceneName);
    }

    public void ClickSignup()
    {
        SignupPanel.SetActive(true);
        

    }

    public void ClickSignupOk()
    {
        var userID = SignupIDInputField.text;
        var userPW = SignupPWInputField.text;
        var userNickName = SignupNNInputField.text;

        if (userID.Length < 1 ||
            userPW.Length < 1 ||
            userNickName.Length < 1)
        {
            NewInfo("모든 정보를 입력해야 합니다.");
            return;
        }

        var userGender = SignupGenderDropdown.itemText.text;
        var userAge = SignupAgeDropdown.itemText.text;

        SignupIDInputField.text = "";
        SignupPWInputField.text = "";
        SignupNNInputField.text = "";

        SignupPanel.SetActive(false);

        /// TODO : API서버 회원가입요청

        GameManager.ClientNetworkManager.Connect("127.0.0.1", 32452);
    }

    public void ClickSignupCancle()
    {
        SignupIDInputField.text = "";
        SignupPWInputField.text = "";
        SignupNNInputField.text = "";

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

    public void SendLogin(string userID, string tokenValue)
    {
        var request = new GatewayServer.PKTReqLogin() { UserID = userID, AuthToken = tokenValue };

        var body = MessagePackSerializer.Serialize(request);
        var sendPacket = PacketDef.PKTHandleHelper.MakePacket((UInt16)PacketDef.ClientGatePacketID.ReqLogin, body);

        GameManager.ClientNetworkManager.Send(sendPacket);
    }

    public void RecvLoginResult(object data)
    {
        var result = (UInt16)data;
        Debug.Log("loginresult : " + result);

        if(result != 0)
        {
            NewInfo("로그인 실패!");
            return;
        }

        SceneManager.LoadScene(Common.LobbySceneName);
    }

    public void RecvSignupResult(UInt16 result)
    {

    }
}
