using UnityEngine;
using UnityEngine.InputSystem; // <- Required for the new Input System

public class PlayerHorizontalMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float direction = 0f;

#if UNITY_EDITOR || UNITY_STANDALONE
        var keyboard = Keyboard.current;
        if (keyboard.leftArrowKey.isPressed)
        {
            direction = -1f;
        }
        else if (keyboard.rightArrowKey.isPressed)
        {
            direction = 1f;
        }

#elif UNITY_ANDROID || UNITY_IOS
        if (Touchscreen.current != null && Touchscreen.current.touches.Count > 0)
        {
            foreach (var touch in Touchscreen.current.touches)
            {
                if (touch.press.isPressed)
                {
                    if (touch.position.ReadValue().x < Screen.width / 2)
                    {
                        direction = -1f;
                    }
                    else
                    {
                        direction = 1f;
                    }
                }
            }
        }
#endif

        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocityY);
        //Debug.Log("Direction: " + direction);
    }
}
