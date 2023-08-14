using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player Player;
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _gameOver;
    private int _score;

    private void Awake() 
    {
       Application.targetFrameRate = 60;

       Pause();
    }

    public void Play()
    {
        _score = 0;
        _scoreText.text = _score.ToString();

        _playButton.SetActive(false);
        _gameOver.SetActive(false);

        Time.timeScale = 1f;
        Player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

    }

    public void Pause()
    {
        Time.timeScale = 0f;
        Player.enabled =false;
    }

    public void GameOver()
    {
        _gameOver.SetActive(true);
        _playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }

}
