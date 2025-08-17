using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    public void OnDestroy()
    {
        Destroy(gameObject); 
    }
}
