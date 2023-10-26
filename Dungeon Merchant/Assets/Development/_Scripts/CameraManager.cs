using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target; // Target that will be followed
    public Vector3 offset; // Camera offset

    void LateUpdate()
    {
        Follow();
    }

    public void Follow()
    {
        if (target != null)
        {
            // Desired position
            Vector3 desiredPosition = target.position + offset;

            // Set camera position
            transform.position = desiredPosition;
        }
    }
}
