using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int traps = 2;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI trapText;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject winUI;

    private bool isGameOver = false;
    private bool isGameWin = false;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
        gameOverUI.SetActive(false);
        winUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void HitTrap(int trapPoints)
    {
        traps -= trapPoints;
        if (traps <= 0)
        {
            traps = 0;
            GameOver();
        }
        UpdateTrap();
  
    }

    public void HitEnd()
    {
        Win();
    }

    public void UpdateTrap()
    {
        trapText.text = traps.ToString();
    }

    public void GameOver()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0; //k cho player lam dc gi nua trong luc nay
        gameOverUI.SetActive(true); //hien panel GameOver len
    }

    public void Win()
    {
        isGameWin = true;
        Time.timeScale = 0;
        winUI.SetActive(true);
    }

    public void RestartGame()
    {
        isGameOver = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1; //cho phep player thao tac lai
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //khoi tao lai Scene Game
    }

    public void Continue()
    {
        int sceneHienTai = SceneManager.GetActiveScene().buildIndex;

        // Check if there is a next scene
        if (sceneHienTai < SceneManager.sceneCountInBuildSettings - 1)
        {
            // Load the next scene
            SceneManager.LoadScene(sceneHienTai + 1);
        }
        else
        {
            Debug.Log("Chưa có màn mới, cảm ơn đã chơi hết!");
        }

        Time.timeScale = 1; // Unfreeze the game
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }

    public bool IsGameWin()
    {
        return isGameWin;
    }
    
}
