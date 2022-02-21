using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour { 
    private int _playerScore1;
    private int _playerScore2;
    [SerializeField] private Text _p1Score;
    [SerializeField] private Text _p2Score;
    private int _gameWinScore = 1;
    [SerializeField] private Text _gameOverText;
    private GameObject _ball;
    [SerializeField] private KeyCode _mainMenu = KeyCode.Escape;
    private bool _gameIsDone = false;

    void Start() {
        _ball = GameObject.Find("Ball");
    }

    public void Score(string wallID) {
        AudioSource a = GetComponent<AudioSource>();
        a.Play();
        if (wallID == "RightWall") {
            _playerScore1++;
            _p1Score.text = "" + _playerScore1;
        }
        else {
            _playerScore2++;
            _p2Score.text = "" + _playerScore2;
        }
        if (_playerScore1 < _gameWinScore && _playerScore2 < _gameWinScore) {
            _ball.GetComponent<BallControl>().Restart();
        }
        else
            GameOver();
    }

    public void GameOver() {
        _gameIsDone = true;
        if (_playerScore1 == _gameWinScore) {
            _gameOverText.text = "PLAYER 1 WINS";
        }
        else if (_playerScore2 == _gameWinScore) {
            _gameOverText.text = "COMPUTER WINS!";
        }
        _gameOverText.gameObject.SetActive(true);
        _ball.GetComponent<BallControl>().ResetBall();
    }

    void Update()
    {
        if (_gameIsDone == true)
        {
            if (Input.GetKey(_mainMenu))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

}
