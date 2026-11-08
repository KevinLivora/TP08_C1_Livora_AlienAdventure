using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.15f;
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;
    [SerializeField] private float minY;
    [SerializeField] private float maxY = 6f;
    [SerializeField] private float yOffset = 1.5f;

    private Vector3 velocity;
    private float fixedZ;

    private void Awake()
    {
        fixedZ = transform.position.z;
    }

    private void Start()
    {
        transform.position = GetDesiredPosition();
    }

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, GetDesiredPosition(), ref velocity, smoothTime);
    }

    private Vector3 GetDesiredPosition()
    {
        return new Vector3(
            Mathf.Clamp(target.position.x, minX, maxX),
            Mathf.Clamp(target.position.y + yOffset, minY, maxY),
            fixedZ);
    }
}
