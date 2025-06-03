using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float yOffset = 0f; //Camera offset
    public float smoothSpeed = 8f; //Follow speed

    private float fixedX;
    private float highestY;

    void Start()
    {
        if (player != null)
        {
            highestY = player.position.y;
            fixedX = transform.position.x; // Save original X position
            transform.position = new Vector3(player.position.x, highestY, transform.position.z);
        }
    }

    void LateUpdate()
    {
        if (player == null) return;
        float targetY = player.position.y + yOffset;

        if (targetY > transform.position.y)
        {
            float newY = Mathf.Lerp(transform.position.y, targetY, smoothSpeed * Time.deltaTime);
            transform.position = new Vector3(fixedX, newY, transform.position.z);
        }

        transform.position = new Vector3(fixedX, player.position.y + yOffset, transform.position.z);

    }
}




