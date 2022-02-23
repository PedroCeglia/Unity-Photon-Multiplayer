using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuEntrada : MonoBehaviour
{
    [SerializeField] private Text _nickNameText;
    [SerializeField] private Text _roomText;

    // Create a new Room In The Server
    public void CreateRoom()
    {
        GestorDeRede.Instance.CreateRoom(_roomText.text);
        GestorDeRede.Instance.SetNickName(_nickNameText.text);
    }

    // Load a Room In The Server
    public void JoinRoom()
    {
        GestorDeRede.Instance.JoinRoom(_roomText.text);
        GestorDeRede.Instance.SetNickName(_nickNameText.text);
    }

}
