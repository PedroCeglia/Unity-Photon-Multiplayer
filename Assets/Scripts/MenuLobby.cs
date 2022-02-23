using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class MenuLobby : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text _playerNickName;
    [SerializeField] private Button _btnStart;
    [SerializeField] private Button _btnLeave;

    [PunRPC]
    public void SetPlayerListName() 
    {
        var _playerList = GestorDeRede.Instance.GetPlayersList();
        _playerNickName.text = _playerList;
        _btnStart.interactable = GestorDeRede.Instance.VerifyOwnerRoom();
    }
}
