using UnityEngine;

public class GameTest : MonoBehaviour
{
    public SF_CharacterMovement characterTransform;
    GT_CameraControlTPA PlayerCam;

    float speedMovement = 10.0f;
    float rotationSpeed = 1050.0f;

    void Start()
    {
        PlayerCam = FindAnyObjectByType<GT_CameraControlTPA>();
        characterTransform = GetComponent<SF_CharacterMovement>();
        characterTransform.SetPosition(new Vector3(0, 1, 0));
        characterTransform.setScale(Vector3.one);
    }

    void Update()
    {
        // 1?? Camera rotation
        PlayerCam.lateralRotate(Input.GetAxis("Mouse X"));
        PlayerCam.verticalRotate(Input.GetAxis("Mouse Y"));

        // 2?? Get WASD input
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.W)) verticalInput += 1f;
        if (Input.GetKey(KeyCode.S)) verticalInput -= 1f;
        if (Input.GetKey(KeyCode.D)) horizontalInput += 1f;
        if (Input.GetKey(KeyCode.A)) horizontalInput -= 1f;

        // 3?? Only move if input exists
        if (!Mathf.Approximately(horizontalInput, 0f) || !Mathf.Approximately(verticalInput, 0f))
        {
            // Flatten camera forward/right vectors
            Vector3 camForward = PlayerCam.transform.forward;
            Vector3 camRight = PlayerCam.transform.right;
            camForward.y = 0;
            camRight.y = 0;
            camForward.Normalize();
            camRight.Normalize();

            // Camera-relative movement vector
            Vector3 moveDir = camForward * verticalInput + camRight * horizontalInput;

            // Move player using JustMove
            characterTransform.JustMove(moveDir.x, moveDir.z, speedMovement);

            // Rotate player toward movement
            characterTransform.keyboardRotation(moveDir.x, moveDir.z, rotationSpeed);
        }
    }
}
