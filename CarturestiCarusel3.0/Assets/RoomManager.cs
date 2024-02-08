using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Diagnostics;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

public class RoomManager : MonoBehaviourPunCallbacks
{

    public GameObject player;

    public GameObject _player;

    public Transform spawnPoint;

    public UnityEngine.UI.Text nicknameText;

    //public InputField playerNickname;

    //public GameObject nicknameInput;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerNickname"))
        {
            string nickname = PlayerPrefs.GetString("PlayerNickname");
            nicknameText.text = "Welcome, " + nickname + "!";
        }
        else
        {
            nicknameText.text = "Welcome, player!";
        }
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

        _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
    }

    public void StartTheGame()
    {
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        PhotonNetwork.NickName = nicknameText.text;
        UnityEngine.Debug.Log("Connecting...");
        PhotonNetwork.ConnectUsingSettings();
        //nicknameInput.SetActive(false);
    }
}
