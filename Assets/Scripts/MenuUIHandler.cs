using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public string PlayerNameInput;
    public Button savePlayerName;
    public GameManager gameManager;
    public InputField inputText;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SaveNameButton()
    {
        //GameManager.Instance.SaveName()
    }
}
