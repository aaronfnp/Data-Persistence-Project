using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreScreenUI : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text highScore1;
    public Button resetButton;
    public Button returnButton;
    //public GameObject scoreScreenCanvas;
    //public GameObject mainScreenCanvas;

    // Start is called before the first frame update
    void Awake()
    {
        Load();
    }


    public void Load()
    {
        //scoreScreenCanvas.SetActive(true);
        //mainScreenCanvas.SetActive(false);

    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        gameManager.LoadFunction();

        highScore1.text = gameManager.PlayerName + ": " + gameManager.highScore; 

        Button resetbtn = resetButton.GetComponent<Button>();
        resetbtn.onClick.AddListener(gameManager.ResetHighScore);
        resetbtn.onClick.AddListener(ResetComplete);

        Button returnbtn = returnButton.GetComponent<Button>();
        returnbtn.onClick.AddListener(ReturnButton);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void ResetComplete()
    {
        highScore1.text = "High Score Reset!";
        Debug.Log("High Score Reset");
    }
    void ReturnButton()
    {
        SceneManager.LoadScene(0);
    }
}
