using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Diagnostics;

public class ShowPlayerNickname : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = photonView.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
