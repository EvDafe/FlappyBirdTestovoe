using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ObstacleTrigger : MonoBehaviour
{
    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _collider.isTrigger = true;
    }
}
