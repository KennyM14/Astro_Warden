using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Transform Instance;

    [Header("Movement Settings")]
    public float moveSpeed = 15f;
    public Vector2 screenBoundsPadding = new Vector2(0.5f, 0.5f);
    public bool smoothFollow = false;

    private Vector3 touchOffset;
    private Camera mainCamera;
    private bool isDragging = false;


    void Awake()
    {
        Instance = transform;
    }
    
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        HandleTouchInput();
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchWorldPos = mainCamera.ScreenToWorldPoint(touch.position);
            touchWorldPos.z = 0;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Detect if touch is on the player
                    Collider2D hit = Physics2D.OverlapPoint(touchWorldPos);
                    if (hit != null && hit.transform == transform)
                    {
                        touchOffset = transform.position - touchWorldPos;
                        isDragging = true;
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        Vector3 newPos = touchWorldPos + touchOffset;
                        newPos = ClampToScreenBounds(newPos);
                        if (smoothFollow)
                        {
                            // Smooth Movement
                            transform.position = Vector3.Lerp(transform.position, newPos, 0.8f);
                        }
                        else
                        {
                            // Movimiento rápido y directo
                            transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * Time.deltaTime);
                        }
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isDragging = false;
                    break;
            }
        }
    }
    
    Vector3 ClampToScreenBounds(Vector3 position)
    {
        Vector3 min = mainCamera.ViewportToWorldPoint(Vector3.zero);
        Vector3 max = mainCamera.ViewportToWorldPoint(Vector3.one);

        position.x = Mathf.Clamp(position.x, min.x + screenBoundsPadding.x, max.x - screenBoundsPadding.x);
        position.y = Mathf.Clamp(position.y, min.y + screenBoundsPadding.y, max.y - screenBoundsPadding.y);

        return position;
    }

}
