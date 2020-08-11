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
        if (userID.Length < 1 ||
            userPW.Length < 1)
        {
            NewInfo("아이디와 비밀번호를 입력해야 합니다.");
            return;
        }

        string tokenValue = GameManager.ClientNetworkManager.LoginConfirm(userID, userPW);
        Debug.Log(tokenValue);
        if (tokenValue != "102")
        {
            GameManager.ClientNetworkManager.Connect("127.0.0.1", 32452);
            SendLogin(GameManager.ClientNetworkManager.connectedTempIdx, userID, tokenValue);
        }
        else
        {
            NewInfo("아이디와 비밀번호를 확인해주세요.");
        }

        
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

        if (userID.Length < 1 || userPW.Length < 1 || userNickName.Length < 1)
        {
            NewInfo("모든 정보를 입력해야 합니다.");
            return;
        }

        int userGender = 0;
        int userAge = 0;
        string inputAge = SignupAgeDropdown.options[SignupAgeDropdown.value].text.Substring(0, 2);
        string inputGender = SignupGenderDropdown.options[SignupGenderDropdown.value].text;

        if (inputGender == "남자") userGender = 1;
        else userGender = 2;

        if (inputAge == "10") userAge = 1;
        else if(inputAge == "20") userAge = 2;
        else if(inputAge == "30") userAge = 3;
        else if(inputAge == "40") userAge = 4;
      
        int resultCreateAccount = GameManager.ClientNetworkManager.CreateAccountConfirm(userID, userPW, userNickName, userGender, userAge);
        Debug.Log(resultCreateAccount);
        if (resultCreateAccount == 0) NewInfo("회원가입이 완료되었습니다.");
        else NewInfo("아이디와 닉네임을 확인해주세요");

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

    // TODO :
    public void SendLogin(int userIdx, string userID, string tokenValue)
    {

        var request = new GatewayServer.PKTReqLogin() { UserID = userID, AuthToken = tokenValue };

        var body = MessagePackSerializer.Serialize(request);
        var sendPacket = PacketDef.PKTHandleHelper.MakePacket((UInt16)PacketDef.ClientGatePacketID.ReqLogin, body);

        GameManager.ClientNetworkManager.Send(sendPacket);
    }

    public void RecvLoginResult(object data)
    {
        var result = (UInt16)data;

        if(result != 0)
        {
            NewInfo("로그인 실패!");
            return;
        }

        GameManager.ClientNetworkManager.connectedId = IDInputField.text;
        GameManager.ClientNetworkManager.connectedIdx = GameManager.ClientNetworkManager.connectedTempIdx;
   //   GameManager.ClientNetworkManager.GetMail(GameManager.ClientNetworkManager.connectedIdx);
        SceneManager.LoadScene(Common.LobbySceneName);
    }

    public void RecvSignupResult(UInt16 result)
    {

    }
}
