using GatewayServer.Packet;
using MessagePack;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameSceenManager : MonoBehaviour
{
    public const float OmokPanPointDistance = 0.53333f;
    public const int OmokPanPointNumber = 19;

    public const float MinLocation = -4.8f;
    public const float MaxLocation = 4.8f;

    public const float StoneMinX = (int)(OmokPanPointNumber / -2) * OmokPanPointDistance;
    public const float StoneMaxX = (int)(OmokPanPointNumber / 2) * OmokPanPointDistance;

    public const float StoneMinY = (int)(OmokPanPointNumber / -2) * OmokPanPointDistance;
    public const float StoneMaxY = (int)(OmokPanPointNumber / 2) * OmokPanPointDistance;

    Color OpponentTextColor = new Color(255f / 255f, 50f / 255f, 50f / 255f);
    Color MyTextColor = new Color(50f / 255f, 50f / 255f, 255f / 255f);

    public float CameraMovePower = 5f;

    public Camera MainCamera;

    public GameObject MenuPanel;

    public GameObject ResultPanel;
    public Text ResultText;

    public GameObject BlackStone;
    public GameObject WhiteStone;

    OmokPanPoint[,] OmokPanPoints;

    bool IsBlack = true;
    bool IsMyTurn = false;

    public GameObject LoadingPanel;
    public RectTransform LoadingProgress;
    const float RotateSpeed = 200f;

    public GameObject InfoPanel;
    public Text InfoText;

    string OpponentID;

    public Text OpponentIDText;
    public Text MyIDText;

    public Text MyGameRecordText;
    public Text OpponentGameRecordText;

    public Text TurnText;

    public GameObject AppearEffectObject;

    // Start is called before the first frame update
    void Start()
    {
        OmokPanPoints = new OmokPanPoint[OmokPanPointNumber, OmokPanPointNumber];

        int x = 0, y = 0;
        for(int yL = (int)(OmokPanPointNumber / -2); yL <= (int)(OmokPanPointNumber / 2); ++yL)
        {
            for(int xL = (int)(OmokPanPointNumber / -2); xL <= (int)(OmokPanPointNumber / 2); ++xL)
            {
                OmokPanPoints[y, x] = new OmokPanPoint(new Vector2(yL * OmokPanPointDistance, xL * OmokPanPointDistance));
                ++x;
            }
            x = 0;
            ++y;
        }

        GameManager.RecvGameInfo += RecvGameInfo;
        GameManager.RecvGamePut += RecvGamePut;
        GameManager.RecvGameResult += RecvGameResult;

        GameManager.IsGameSceneInit = true;
    }

    // Update is called once per frame
    void Update()
    {
        #region LoadingProgress
        if (LoadingPanel.activeSelf == true)
        {
            LoadingProgress.Rotate(0f, 0f, RotateSpeed * Time.deltaTime);
        }
        #endregion

        #region ThrowStone

        CheckThrowStone();

        //For_Debug
        CheckDeleteStone();

        #endregion

        #region Camera


        // up
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    ++CameraMoveY;
        //}
        //else if (Input.GetKeyUp(KeyCode.W))
        //{
        //    --CameraMoveY;
        //}
        //// down
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    --CameraMoveY;
        //}
        //else if (Input.GetKeyUp(KeyCode.S))
        //{
        //    ++CameraMoveY;
        //}
        //    // left
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    --CameraMoveX;
        //}
        //else if (Input.GetKeyUp(KeyCode.A))
        //{
        //    ++CameraMoveX;
        //}
        //// right
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    ++CameraMoveX;
        //}
        //else if (Input.GetKeyUp(KeyCode.D))
        //{
        //    --CameraMoveX;
        //}

        //var moveVector = new Vector2(CameraMoveX, CameraMoveY);

        //MainCamera.transform.Translate(moveVector * CameraMovePower * Time.deltaTime);
        //var cameraX = MainCamera.transform.position.x;
        //var cameraY = MainCamera.transform.position.y;

        //moveVector = Vector2.zero;
        //if(cameraX < MinLocation)
        //{
        //    moveVector.x = (cameraX - MinLocation) * -1f;
        //}
        //else if(cameraX > MaxLocation)
        //{
        //    moveVector.x = (cameraX - MaxLocation) * -1f;
        //}
        //if(cameraY < MinLocation)
        //{
        //    moveVector.y = (cameraY - MinLocation) * -1f;
        //}
        //else if(cameraY > MaxLocation)
        //{
        //    moveVector.y = (cameraY - MaxLocation) * -1f;
        //}

        //MainCamera.transform.Translate(moveVector);

        #endregion
    }

    private void OnDestroy()
    {
        GameManager.IsGameSceneInit = false;
    }

    void CheckThrowStone()
    {
        if(MenuPanel.activeSelf == true)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (pos.x < MinLocation || pos.x > MaxLocation
                || pos.y < MinLocation || pos.y > MaxLocation)
            {
                return;
            }

            int xIdx = Mathf.RoundToInt((pos.x + StoneMaxX) / OmokPanPointDistance);
            int yIdx = Mathf.RoundToInt((pos.y + StoneMaxY) / OmokPanPointDistance);

            SendGamePut(xIdx, yIdx);
        }
    }

    void CheckDeleteStone()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //if (pos.x < MinLocation || pos.x > MaxLocation
            //    || pos.y < MinLocation || pos.y > MaxLocation)
            //{
            //    return;
            //}
            //Debug.Log("Click ; " + pos);
            //int xIdx = Mathf.RoundToInt((pos.x + StoneMaxX) / OmokPanPointDistance);
            //int yIdx = Mathf.RoundToInt((pos.y + StoneMaxY) / OmokPanPointDistance);
            //Debug.Log("XIdx : " + xIdx + ", YIdx : " + yIdx);

            //var point = OmokPanPoints[yIdx, xIdx];
            //if (point.OmokStone == null)
            //{
            //    return;
            //}
            //Destroy(point.OmokStone);
            //point.OmokStone = null;
            //point.Type = OmokPanPoint.PointType.None;
            //isBlack = !isBlack;
        }
    }

    void Put((int, int)putPos, byte type)
    {
        var xIdx = putPos.Item1;
        var yIdx = putPos.Item2;

        var point = OmokPanPoints[yIdx, xIdx];

        GameObject putObject = null;

        AppearEffectObject.SetActive(true);

        switch (type)
        {
            case 1:
                {
                    IsMyTurn = IsBlack == true ? false : true;
                    putObject = BlackStone;
                } break;
            case 2:
                {
                    IsMyTurn = IsBlack == true ? true : false;
                    putObject = WhiteStone;
                } break;
        }

        Vector3 stonePos = new Vector3((float)((xIdx - (OmokPanPointNumber / 2)) * OmokPanPointDistance), (float)((yIdx - (OmokPanPointNumber / 2)) * OmokPanPointDistance), -1);
        AppearEffectObject.transform.position = stonePos - new Vector3(0f, 0f, 2f);
        point.OmokStone = Instantiate(putObject, stonePos, Quaternion.identity);

        TurnOut(IsMyTurn);
    }

    public void ClickMenuButton()
    {
        MenuPanel.SetActive(true);
    }

    public void ClickMenuDisposeButton()
    {
        // TODO : 서버에 알림
        SceneManager.LoadScene(Common.LobbySceneName);
    }

    public void ClickMenuContinueButton()
    {
        MenuPanel.SetActive(false);
    }

    public void ClickToLobbyButton()
    {
        SceneManager.LoadScene(Common.LobbySceneName);
    }

    public void ClickInfoOkButton()
    {
        InfoPanel.SetActive(false);
    }

    public void NewInfo(string info)
    {
        InfoText.text = info;

        InfoPanel.SetActive(true);
    }

    public void NotifyResult(string resultText)
    {
        ResultText.text = resultText;

        ResultPanel.SetActive(true);
    }

    void TurnOut(bool isMyTurn)
    {
        if(isMyTurn == true)
        {
            TurnText.text = "내 턴";
            TurnText.color = MyTextColor;
        }
        else
        {
            TurnText.text = "상대 턴";
            TurnText.color = OpponentTextColor;
        }
    }

    void SendGamePut(int xIdx, int yIdx)
    {
        Debug.Log($"SendGamePut x : {xIdx} y : {yIdx}");

        var packetData = new PKTReqGamePut() { ClickPos = (xIdx, yIdx) };
        var packet = MessagePackSerializer.Serialize(packetData);
        var sendPacket = PacketDef.PKTHandleHelper.MakePacket((UInt16)PacketDef.ClientGatePacketID.ReqGamePut, packet);

        GameManager.ClientNetworkManager.Send(sendPacket);
    }

    void RecvGameInfo(object data)
    {
        var packetData = (PKTNTFGameInfo)data;
        var result = packetData.Result;
        Console.WriteLine($"GameInfo Result : [{result}]");

        if(result != 0)
        {
            NotifyResult($"입장실패 ErrorCode : {result}");
            return;
        }

        OpponentID = packetData.OpponentID;
        IsBlack = packetData.IsBlack;
        IsMyTurn = IsBlack == true ? true : false;

        TurnOut(IsMyTurn);

        OpponentIDText.text = OpponentID;
        MyIDText.text = GameManager.UserInfo.UserID;

        MyGameRecordText.text = $"{GameManager.UserInfo.UserVictoryCount}승 {GameManager.UserInfo.UserDefeatCount}패";
        OpponentGameRecordText.text = $"{packetData.OpponentGameRecord.Item1}승 {packetData.OpponentGameRecord.Item2}패";

        LoadingPanel.SetActive(false);
    }

    void RecvGamePut(object data)
    {
        var packetData = (PKTNTFGamePut)data;

        var result = packetData.Result;

        switch (result)
        {
            case 3030:
                {
                    NewInfo("돌이 있는 곳엔 둘 수 없습니다.");
                } break;
            case 3031:
                {
                    NewInfo("상대의 차례입니다.");
                } break;
            case 3032:
                {
                    NewInfo("삼삼은 금지입니다 ^_^");
                }
                break;
        }

        if(result != 0)
        {
            Debug.Log($"Put Fail Result : [{result.ToString()}]");

            return;
        }

        var putPos = packetData.PutPos;
        var type = packetData.Type;

        Put(putPos, type);
    }

    void RecvGameResult(object data)
    {
        var result = (UInt16)data;

        switch (result)
        {
            case 3035:  // Black Win
                {
                    NotifyResult("흑돌이 승리하였습니다!");
                    if (IsBlack) GameManager.UserInfo.UserVictoryCount++;
                    else GameManager.UserInfo.UserDefeatCount++;

                } break;
            case 3036:  // White Win
                {
                    NotifyResult("백돌이 승리하였습니다!");
                    if (IsBlack) GameManager.UserInfo.UserDefeatCount++;
                    else GameManager.UserInfo.UserVictoryCount++;
                } break;
        }
    }
}
