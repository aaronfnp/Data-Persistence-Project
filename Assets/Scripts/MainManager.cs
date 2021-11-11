using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverTextShort;
    public GameObject GameOverTextLong;
    public GameObject highScoreText;
    
    private bool m_Started = false;
    private int m_Points;
    
    public bool m_GameOver = false;

    public GameManager gameManager;

    public TMP_InputField inputText;
    public Button submitButton;


    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver && m_Points < gameManager.highScore)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                SceneManager.LoadScene(2);
            }
        }
        
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        
        if (m_Points > gameManager.highScore)
        {
            highScoreText.SetActive(true);
            submitButton.gameObject.SetActive(true);
            inputText.gameObject.SetActive(true);
            GameOverTextShort.SetActive(true);

            Button btn = submitButton.GetComponent<Button>();
            btn.onClick.AddListener(SubmitButton);
            gameManager.SaveGameData(inputText.text, m_Points);
        }
        else
        {
            GameOverTextLong.SetActive(true);
        }
    }
    private void SubmitButton()
    {
        Debug.Log("Name Saved as: " + inputText.text);
        gameManager.SaveGameData(inputText.text, m_Points);
        SceneManager.LoadScene(2);
    }
}
