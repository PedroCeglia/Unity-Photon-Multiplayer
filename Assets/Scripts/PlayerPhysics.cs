using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PlayerPhysics : MonoBehaviourPunCallbacks
{

    // Player Move
    private CharacterController controller;
    [SerializeField] private float speed;

    // Player Photon
    private Player _photonPlayer;
    private int _id;
    private bool isMine = false;

    [PunRPC]
    private void Initialize(Player player)
    {
        _photonPlayer = player;
        _id = _photonPlayer.ActorNumber;
        GameManager.Instance._jogadores.Add(this);
        if (photonView.IsMine)
        {
            isMine = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMine)
        {
            Move();
        }
    }
    private void Move()
    {
        // Get Moviment
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moviment = new Vector3(horizontal, 0f, vertical);
        if(moviment.magnitude != 0)
        {
            controller.Move(moviment * Time.deltaTime *speed);
        }
    }
}
