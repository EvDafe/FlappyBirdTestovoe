using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = 5f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _tilt = 5f;

    private Vector3 _direction;

    public event Action TouchObstacle;
    public event Action ScoreZoneReach;
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        _direction = Vector3.zero;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            _direction = Vector3.up * _jumpHeight;
        }

        _direction.y += _gravity * Time.deltaTime;
        transform.position += _direction * Time.deltaTime;

        Vector3 rotation = transform.eulerAngles;
        rotation.z = _direction.y * _tilt;
        transform.eulerAngles = rotation;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ObstacleTrigger obstacle))
            TouchObstacle?.Invoke();
        if (other.TryGetComponent(out ScoreZoneTrigger _scoreZone))
            ScoreZoneReach?.Invoke();
    }
}
