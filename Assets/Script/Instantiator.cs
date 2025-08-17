using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject prefab;

    public void Instantiate()
    {
        Instantiate(prefab, transform.position, transform.rotation); 
    }
}
