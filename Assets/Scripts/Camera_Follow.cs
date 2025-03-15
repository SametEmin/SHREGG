using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera will follow (e.g., the player)
    public float smoothSpeed = 0.125f; // How smoothly the camera follows the target
    public Vector2 offset; // Offset from the target position

    public SpriteRenderer backgroundSprite; // Reference to the background sprite renderer

    private Vector2 minBounds;
    private Vector2 maxBounds;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;

        if (backgroundSprite != null)
        {
            CalculateBounds();
        }
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position with the offset
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);

            // Smoothly interpolate between the current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Clamp the camera's position within the bounds
            float clampedX = Mathf.Clamp(smoothedPosition.x, minBounds.x, maxBounds.x);
            float clampedY = Mathf.Clamp(smoothedPosition.y, minBounds.y, maxBounds.y);

            // Update the camera's position
            transform.position = new Vector3(clampedX, clampedY, smoothedPosition.z);
        }
    }

    private void CalculateBounds()
    {
        // Get the size of the background in world units
        float backgroundWidth = backgroundSprite.bounds.size.x;
        float backgroundHeight = backgroundSprite.bounds.size.y;

        // Get the size of the camera view in world units
        float cameraHeight = cam.orthographicSize * 2;
        float cameraWidth = cameraHeight * cam.aspect;

        // Calculate the bounds
        minBounds.x = backgroundSprite.transform.position.x - (backgroundWidth / 2) + (cameraWidth / 2);
        maxBounds.x = backgroundSprite.transform.position.x + (backgroundWidth / 2) - (cameraWidth / 2);
        minBounds.y = backgroundSprite.transform.position.y - (backgroundHeight / 2) + (cameraHeight / 2);
        maxBounds.y = backgroundSprite.transform.position.y + (backgroundHeight / 2) - (cameraHeight / 2);
    }
}