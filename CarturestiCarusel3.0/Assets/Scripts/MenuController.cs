using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames; 
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject nicknameInput;
    public GameObject errorMessage;
    //private UnityEngine.UI.InputField actualNickname;
    public GameObject keyboard;
    public GameObject message;

    /*void Start()
    {
        actualNickname = nicknameInput.GetComponent<UnityEngine.UI.InputField>();
    }*/

    public void StartBtn()
    {
        string nickname = keyboard.GetComponent<Keyboard>().getInputFieldNickname();

        //TextMeshProUGUI nicknameText = message.transform.Find("Nickname").GetComponent<TextMeshProUGUI>();
        //nicknameText.text = "WE ARE HERE";
        TextMeshPro nicknameText = message.GetComponentInChildren<TextMeshPro>();
        //nicknameText.text = "WE ARE HERE";
        //message.SetActive(true);
        //Thread.Sleep(2000);
        //message.SetActive(false);

        if (!string.IsNullOrEmpty(nickname))
        {
            //message.GetComponentInChildren<TMP_Text>().text = nickname;

            nicknameText = message.transform.Find("Nickname").GetComponent<TextMeshPro>();
            nicknameText.text = nickname;
            message.SetActive(true);


            PlayerPrefs.SetString("PlayerNickname", nickname);
            UnityEngine.Debug.Log("Your nickname is: " + nickname);
            // Proceed to the next scene
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            nicknameText = message.transform.Find("Nickname").GetComponent<TextMeshPro>();
            nicknameText.text = "No nickname provided!";
            message.SetActive(true);
            // Show an error message or prompt the player to enter a nickname
            errorMessage.SetActive(true);
            UnityEngine.Debug.Log("Sorry, no nickname!");
        }
    }
}
