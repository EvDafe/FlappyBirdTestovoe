using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
    private const string PipesIndex = nameof(PipesIndex);

    [SerializeField] private Pipes[] _pipesPrefabs;
    [SerializeField] private float _spawnRate = 1f;
    [SerializeField] private float _minHeight = -1f;
    [SerializeField] private float _maxHeight = 2f;

    private int _pipesIndex;
    private List<Pipes> _pipes = new List<Pipes>();

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), _spawnRate, _spawnRate);
    }
    private void Awake()
    {
        Load();
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    public void SetPipesDifficulty(Difficulties difficulty)
    {
        _pipesIndex = (int)difficulty;
        Save();
    }
    public void DestroyPipes()
    {
        var pipes = _pipes.Where(pipe => pipe != null).ToList();
        pipes.ForEach(pipe => Destroy(pipe.gameObject));
    }
    private void Spawn()
    {
        var pipesSpawnPosition = transform.position + Vector3.up * UnityEngine.Random.Range(_minHeight, _maxHeight);
        Pipes pipes = Instantiate(_pipesPrefabs[_pipesIndex], pipesSpawnPosition, Quaternion.identity);
        _pipes.Add(pipes);
    }
    private void Save()
    {
        PlayerPrefs.SetInt(PipesIndex, _pipesIndex);
    }
    private void Load()
    {
        _pipesIndex = PlayerPrefs.GetInt(PipesIndex);
    }
}
