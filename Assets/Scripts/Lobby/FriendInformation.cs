using APIServer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendInformation : MonoBehaviour
{

    public Text FriendNickname;

    public void Init(FriendNicknameInfo friendNicknameInfo)
    {
        FriendNickname.text = friendNicknameInfo.FriendNickname;

    }

}
