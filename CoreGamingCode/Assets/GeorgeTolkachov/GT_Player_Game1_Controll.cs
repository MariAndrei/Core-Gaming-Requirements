using UnityEngine;

public class GT_Player_Game1_Controll : MonoBehaviour
{
    private float moveSpeed;

    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        // WASD controls
        if (Input.GetKey(KeyCode.W)) vertical = 1f;
        if (Input.GetKey(KeyCode.S)) vertical = -1f;
        if (Input.GetKey(KeyCode.A)) horizontal = -1f;
        if (Input.GetKey(KeyCode.D)) horizontal = 1f;

        // Movement direction relative to player
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        // Move the player
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            moveSpeed = 8f;
        }
        else
        {
            moveSpeed = 5f;
        }
    }
}
