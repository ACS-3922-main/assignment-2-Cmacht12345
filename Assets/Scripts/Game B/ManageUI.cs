using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageUI : MonoBehaviour
{
    private int _playerScore;
    private int _lives = 3;
    [SerializeField] private Text _pScore;
    [SerializeField] private Text _pLives;
    private GameObject _ball;
    private int _gameWinScore = 160;
    [SerializeField] private Text _gameOverText;
    private bool _gameIsDone = false;
    [SerializeField] private KeyCode _mainMenu = KeyCode.Escape;
    // Start is called before the first frame update
    void Start()
    {
        _ball = GameObject.Find("Ball");
        _pScore.text = "Score: " + _playerScore;
        _pLives.text = "Lives: " + _lives;
    }

    public void Hit()
    {
        _playerScore += 10;
        _pScore.text ="Score: " + _playerScore;
        if(_playerScore == _gameWinScore) 
        { 
            GameOver();
        }
    }

    public void Life() 
    {
        _lives--;
        _pLives.text = "Lives: " + _lives;
        if (_lives >= 0)
        {
            _ball.GetComponent<ControlBall>().Restart();
        }
        else 
        {
            GameOver();
        }
    }

    public void GameOver()
    {

        _gameIsDone = true;
        if (_playerScore == _gameWinScore)
        {
            _gameOverText.text = "WIN!";
        }
        else if (_playerScore != _gameWinScore)
        {
            _gameOverText.text = "LOSE!";
        }
        _gameOverText.gameObject.SetActive(true);
        _ball.GetComponent<ControlBall>().ResetBall();
    }
    void Update() 
    { 
        if(_gameIsDone == true) 
        {
            if (Input.GetKey(_mainMenu)) 
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
    public bool GameIsDone() 
    {
        return _gameIsDone;
    }

}
