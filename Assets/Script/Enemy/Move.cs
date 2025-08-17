using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    private void Update()
    {
        Movement(); 
    }

    public void Movement()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
