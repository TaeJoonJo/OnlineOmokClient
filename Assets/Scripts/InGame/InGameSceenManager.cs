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

    public float CameraMovePower = 5f;

    public Camera MainCamera;

    public GameObject MenuPanel;

    public GameObject ResultPanel;
    public Text ResultText;

    //float CameraMoveX = 0;
    //float CameraMoveY = 0;

    public GameObject BlackStone;
    public GameObject WhiteStone;

    //KeyValuePair<float, float>[,] OmokPanLocation;
    OmokPanPoint[,] OmokPanPoints;

    bool isBlack = true;

    // Start is called before the first frame update
    void Start()
    {
        //OmokPanLocation = new KeyValuePair<float, float>[OmokPanDotNumber, OmokPanDotNumber];
        OmokPanPoints = new OmokPanPoint[OmokPanPointNumber, OmokPanPointNumber];

        int x = 0, y = 0;
        for(int yL = (int)(OmokPanPointNumber / -2); yL <= (int)(OmokPanPointNumber / 2); ++yL)
        {
            for(int xL = (int)(OmokPanPointNumber / -2); xL <= (int)(OmokPanPointNumber / 2); ++xL)
            {
                //Debug.Log(yL * OmokPanPointDistance + ", " + xL * OmokPanPointDistance);
                //OmokPanLocation[y, x] = new KeyValuePair<float, float>(yL * OmokPanDotDistance, xL * OmokPanDotDistance);
                OmokPanPoints[y, x] = new OmokPanPoint(new Vector2(yL * OmokPanPointDistance, xL * OmokPanPointDistance));
                ++x;
            }
            x = 0;
            ++y;
        }
    }

    // Update is called once per frame
    void Update()
    {
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

            var point = OmokPanPoints[yIdx, xIdx];
            if (point.OmokStone != null)
            {
                return;
            }

            GameObject stone;
            OmokPanPoint.PointType pointType;
            if (isBlack)
            {
                stone = BlackStone;
                pointType = OmokPanPoint.PointType.Black;
            }
            else
            {
                stone = WhiteStone;
                pointType = OmokPanPoint.PointType.White;
            }

            if(OmokRule.ConfirmThreeThree(OmokPanPoints, xIdx, yIdx, pointType) == true)
            {
                Debug.Log("거긴 3 3입니다!");
                return;
            }

            Vector3 stonePos = new Vector3((float)((xIdx - (OmokPanPointNumber / 2)) * OmokPanPointDistance), (float)((yIdx - (OmokPanPointNumber / 2)) * OmokPanPointDistance), -1);
            point.OmokStone = Instantiate(stone, stonePos, Quaternion.identity);
            point.Type = pointType;

            if (OmokRule.ConfirmOmok(OmokPanPoints, xIdx, yIdx, pointType) == true)
            {
                Debug.Log("오목! 승리~!");
                if(pointType == OmokPanPoint.PointType.Black)
                {
                    NotifyResult("흑돌 승리!");
                }
                else
                {
                    NotifyResult("백돌 승리!");
                }
            }

            isBlack = !isBlack;
        }
    }

    void CheckDeleteStone()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (pos.x < MinLocation || pos.x > MaxLocation
                || pos.y < MinLocation || pos.y > MaxLocation)
            {
                return;
            }
            Debug.Log("Click ; " + pos);
            int xIdx = Mathf.RoundToInt((pos.x + StoneMaxX) / OmokPanPointDistance);
            int yIdx = Mathf.RoundToInt((pos.y + StoneMaxY) / OmokPanPointDistance);
            Debug.Log("XIdx : " + xIdx + ", YIdx : " + yIdx);

            var point = OmokPanPoints[yIdx, xIdx];
            if (point.OmokStone == null)
            {
                return;
            }
            Destroy(point.OmokStone);
            point.OmokStone = null;
            point.Type = OmokPanPoint.PointType.None;
            isBlack = !isBlack;
        }
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
        // TODO : 서버에게 알리기

        SceneManager.LoadScene(Common.LobbySceneName);
    }

    public void NotifyResult(string resultText)
    {
        ResultText.text = resultText;

        ResultPanel.SetActive(true);
    }
}
