using UnityEngine;

public class TestCameraScript : MonoBehaviour
{
    private GT_CameraControlTPA cam;
    float mouseY;
    float mouseX;

    void Start()
    {
        cam = GetComponent<GT_CameraControlTPA>();
        cam.setDistance(1500f);
    }
    /// <summary>
    /// Updates the camera's orientation and zoom level based on user input.
    /// </summary>
    /// <remarks>This method processes mouse input to adjust the camera's lateral and vertical rotation.  It
    /// also sets the camera's zoom limits and scroll speed. The method assumes that the  input axes "Mouse X" and
    /// "Mouse Y" are configured in the input settings.</remarks>
    void Update()
    {

       // mouseY = -Input.GetAxis("Mouse Y") * 2f;
       // cam.verticalRotate(mouseY);

        mouseX = -Input.GetAxis("Mouse X") * 2f;
        cam.lateralRotate(mouseX);

        mouseY = -Input.GetAxis("Mouse Y") * 2f;
        cam.verticalRotate(mouseY);
        

        cam.setScroll(50, 2000);
        cam.setScrollSpeed(200);
       
    }
}
