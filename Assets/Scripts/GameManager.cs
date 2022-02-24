using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    // GameController Singleton
    public static GameManager Instance { get; private set; }
    
    // Initialize Player Atributes
    [SerializeField] private string _localizacaoPrefab;
    [SerializeField] private Transform[] _spawnList;
    
    // Players List
    private int _playersNumber = 0;
    public List<PlayerPhysics> _jogadores;
    public List<PlayerPhysics> Jogadores { get => _jogadores; private set => _jogadores = value; }
   
    // Create a Singleton
    private void Awake()
    {
        // Verify if Instance exist
        if (Instance != null && Instance != this)
        {
            // A Instancia Atual Do Game Object é Desabilitada
            // Usamos a Instancia Anterior
            gameObject.SetActive(false);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //Add a Player
    private void Start()
    {
        photonView.RPC("AddPlayer", RpcTarget.AllBuffered);
        _jogadores = new List<PlayerPhysics>();
    }

    // Add Player
    [PunRPC]
    private void AddPlayer()
    {
        _playersNumber++;
        if(_playersNumber == PhotonNetwork.PlayerList.Length)
        {
            CreatePlayer();
        }
    }

    // Create Player
    private void CreatePlayer()
    {
        // Create a Player Instance using Photon
        var playerObj = PhotonNetwork.Instantiate(_localizacaoPrefab, _spawnList[Random.Range(0, _spawnList.Length)].position, Quaternion.identity);
        var player = playerObj.GetComponent<PlayerPhysics>();
        // Initialize Player And Pass A Local Player as Parameter
        player.photonView.RPC("Initialize", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }
}
