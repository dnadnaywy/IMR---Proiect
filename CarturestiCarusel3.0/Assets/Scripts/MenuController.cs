using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject nicknameInput;
    public GameObject errorMessage;
    private UnityEngine.UI.InputField actualNickname;

    void Start()
    {
        actualNickname = nicknameInput.GetComponent<UnityEngine.UI.InputField>();
    }

    public void StartBtn()
    {
        string nickname = actualNickname.text; 

        if (!string.IsNullOrEmpty(nickname))
        {
            PlayerPrefs.SetString("PlayerNickname", nickname);
            UnityEngine.Debug.Log("Your nickname is: " + nickname);
            // Proceed to the next scene
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            // Show an error message or prompt the player to enter a nickname
            errorMessage.SetActive(true);
            UnityEngine.Debug.Log("Sorry, no nickname!");
        }
    }
}
