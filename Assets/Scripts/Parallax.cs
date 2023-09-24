using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float animationSpeed = 1f;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }

}
