using UnityEngine;
using UnityEngine.InputSystem;

public class Game1_Script : MonoBehaviour
{
    Vector3 lastMousePos;
    SF_MouseRotation cam2;
    GT_Player_Game1_Controll walk;
    public float sensitivity = 0.2f;
    float xRotation = 0f;
    HealthBar_Script_GT sprint;
    public Camera cam;
    private float normalFOV = 80f;
    private float zoomFOV = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        lastMousePos = Input.mousePosition; // Added this because SF code I can't use Mouse Movement is Project Settings in Vertical section
        sprint = GetComponent<HealthBar_Script_GT>();
        cam2 = GetComponent<SF_MouseRotation>();
        walk = GetComponent<GT_Player_Game1_Controll>();
 
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 delta = Input.mousePosition - lastMousePos;
        lastMousePos = Input.mousePosition;

        float mouseX = delta.x * sensitivity;
        float mouseY = delta.y * sensitivity;
        
        xRotation -= mouseY; // only for vertical movement
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        GetComponent<Camera>().transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        cam2.mouseSensitivity = 1000f;
        cam2.mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; ; // only for horizontal movement

        if (Input.GetKey(KeyCode.Space))
        {
            if (cam.fieldOfView < zoomFOV)
                cam.fieldOfView += 2f;
        }
        else
        {
            if (cam.fieldOfView == zoomFOV || cam.fieldOfView > normalFOV)
                cam.fieldOfView -= 2f; // when Space is released
        }

    }

   
}
