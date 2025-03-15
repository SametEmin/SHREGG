using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    public float speed = 3f; // Speed of the character
    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        // Get input from the horizontal and vertical axes
        float moveHorizontal = 0f;
        float moveVertical = 0f;
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveVertical = 1f;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveHorizontal = -1f;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveVertical = -1f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveHorizontal = 1f;
        }
    
        // Create a Vector2 based on the input
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Normalize the movement vector to ensure consistent speed
        if (movement.sqrMagnitude > 0)
        {
            player.animator.SetBool("isMoving", true);
            Debug.Log("Player is moving");
        }
        else
        {
            player.animator.SetBool("isMoving", false);
            Debug.Log("Player is not moving");
        }

        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }
        
        // Move the character
        transform.Translate(movement * speed * Time.deltaTime);

        // Pozisyonu sınırla
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -19f, 19f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -11f, 11f);
        transform.position = clampedPosition;
    }
}