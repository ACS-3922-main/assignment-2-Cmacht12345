using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private KeyCode _pong = KeyCode.A;
    [SerializeField] private KeyCode _brick = KeyCode.B;
    [SerializeField] private KeyCode _quit = KeyCode.Q;

    public void PlayPong() 
    {
        SceneManager.LoadScene("PartA");
    }
    public void PlayBrick()
    {
        SceneManager.LoadScene("PartB");
    }
    public void QuitProgram() 
    {
        Application.Quit();
    }
    public void Update() 
    {
        if (Input.GetKey(_pong)) 
        {
            PlayPong();
        }
        if (Input.GetKey(_brick))
        {
            PlayBrick();
        }
        if (Input.GetKey(_quit))
        {
            QuitProgram();
        }
    }
}
