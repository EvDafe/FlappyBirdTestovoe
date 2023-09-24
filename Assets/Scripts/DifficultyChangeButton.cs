using UnityEngine;
using UnityEngine.UI;

public class DifficultyChangeButton : MonoBehaviour
{
    [SerializeField] private Button _toggle;
    [SerializeField] private Difficulties _difficulty;
    [SerializeField] private PipesSpawner _spawner;

    public Difficulties Difficulty => _difficulty;
    private void Start()
    {
        _toggle.onClick.AddListener(SetDifficulty);
    }
    private void SetDifficulty()
    {
        _spawner.SetPipesDifficulty(_difficulty);
    }
}
