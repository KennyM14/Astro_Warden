using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float speed = 0.1f;
    [SerializeField] private MeshRenderer mesh;

    void Update()
    {
        Vector2 offset = new Vector2(0, Time.deltaTime * speed);
        mesh.material.mainTextureOffset = offset; 
    }
}
