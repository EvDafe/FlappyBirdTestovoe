using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private Transform _top;
    [SerializeField] private Transform _bottom;
    [SerializeField] private float _speed = 5f;

    private float _leftScreenEdge;

    private void Start()
    {
        _leftScreenEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;

        if (transform.position.x < _leftScreenEdge) {
            Destroy(gameObject);
        }
    }

}
