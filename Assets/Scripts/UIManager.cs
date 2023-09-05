using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_InputField nameInput;

    public void StartNew() 
    {
        DataManager.instance.currentPlayerName = nameInput.text;
        SceneManager.LoadScene(1); 
    }
}
