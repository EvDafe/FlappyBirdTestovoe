using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PipesSpawner _pipesSpawner;
    [SerializeField] private PlayButton _playButton;
    [SerializeField] private ScoreText _scoreText;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _difficultyButtonsHolder;

    private int _score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        _player.ScoreZoneReach += IncreaseScore;
        _player.TouchObstacle += GameOver;
        Pause();
    }

    public void Play()
    {
        _score = 0;
        _scoreText.SetText(_score);

        SetActiveGameOverElements(false);

        Time.timeScale = 1f;
        _player.enabled = true;

        _pipesSpawner.DestroyPipes();
    }

    private void GameOver()
    {
        SetActiveGameOverElements(true);

        Pause();
    }

    private void SetActiveGameOverElements(bool active)
    {
        _playButton.gameObject.SetActive(active);
        _gameOver.SetActive(active);
        _difficultyButtonsHolder.SetActive(active);
    }
    private void Pause()
    {
        Time.timeScale = 0f;
        _player.enabled = false;
    }

    private void IncreaseScore()
    {
        _score++;
        _scoreText.SetText(_score);
    }
}
