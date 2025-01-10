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

    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
        gameOverUI.SetActive(false);
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

    public void RestartGame()
    {
        isGameOver = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1; //cho phep player thao tac lai
        SceneManager.LoadScene("SampleScene"); //khoi tao lai Scene Game
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
