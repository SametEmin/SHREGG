using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Basic player movement for testing (optional)
    public float moveSpeed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}
