using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Diagnostics;
using System.Security.Cryptography;

public class RoomManager : MonoBehaviourPunCallbacks
{

    public GameObject player;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("Connecting...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        UnityEngine.Debug.Log("Connected to Server");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        PhotonNetwork.JoinOrCreateRoom("test", null, null);

        UnityEngine.Debug.Log("We are in the lobby now!");

    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        UnityEngine.Debug.Log("We are connected and in a room!");

        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
    }
}
