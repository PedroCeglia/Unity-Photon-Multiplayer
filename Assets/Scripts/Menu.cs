using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Menu : MonoBehaviourPunCallbacks
{
    [SerializeField] private MenuEntrada _menuEntrada;
    [SerializeField] private MenuLobby _menuLobby;

    // Start is called before the first frame update
    void Start()
    {
        // When you Start the Game, the menus will desappear
        _menuEntrada.gameObject.SetActive(false);
        _menuLobby.gameObject.SetActive(false);
    }

    // CallBack call when the user Connect with the server
    public override void OnConnectedToMaster()
    {
        // When the user connect with the Server, the _menuEntrada will appear
        _menuEntrada.gameObject.SetActive(true);
    }

    // Callback call when the user Join in a Room
    public override void OnJoinedRoom()
    {
        SetMenuActive(_menuLobby.gameObject);
        _menuLobby.photonView.RPC("SetPlayerListName", RpcTarget.All);
    }
     
    // Change The Menu
    public void SetMenuActive(GameObject _menu) 
    {
        // Disappear All Menus
        _menuEntrada.gameObject.SetActive(false);
        _menuLobby.gameObject.SetActive(false);

        // And only desired the Menu appear
        _menu.gameObject.SetActive(true);
    }

}
