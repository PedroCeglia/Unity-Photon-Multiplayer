using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GestorDeRede : MonoBehaviourPunCallbacks
{
    public static GestorDeRede Instance  { get; private set;}

    // Inicializado quando a Instancia do Objceto é carregada
    private void Awake()
    {
        // Verify if Instance exist
        if(Instance != null && Instance != this)
        {
            // A Instancia Atual Do Game Object é Desabilitada
            // Usamos a Instancia Anterior
            gameObject.SetActive(false);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Connect in Servidor
        PhotonNetwork.ConnectUsingSettings();
    }

    // Create A New Room In The Server
    public void CreateRoom(string IdRoom)
    {
        PhotonNetwork.CreateRoom(IdRoom);
    }

    // Join A Room In The Server
    public void JoinRoom(string IdRoom)
    {
        PhotonNetwork.JoinRoom(IdRoom);
    }

    // Set Nickname In Server
    public void SetNickName(string nickName) 
    {
        PhotonNetwork.NickName = nickName;
    }

    // Get Player In A Room
    public string GetPlayersList()
    {
        string lista = "";
        foreach(var player in PhotonNetwork.PlayerList) 
        {
            lista += player.NickName + "/n";
        }
        return lista;
    }
    
    // Verify if You are Owner Room
    public bool VerifyOwnerRoom()
    {
        return PhotonNetwork.IsMasterClient;
    }
     
    // Player Leave the Room
    public void LeaveTheRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    // Return when Connect
    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectou");
    }
}
