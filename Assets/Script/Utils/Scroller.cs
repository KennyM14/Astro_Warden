using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float speed = 0.1f;
    [SerializeField] private MeshRenderer mesh;
    private Vector2 currentOffset = Vector2.zero;

    void Update()
    {
        currentOffset.y += Time.deltaTime * speed; // Acumula el desplazamiento
        mesh.material.mainTextureOffset = currentOffset;
    }
}
