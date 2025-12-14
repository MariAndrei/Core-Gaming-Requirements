/*
    
 ******** READ ME ********
 *
 *  This script executes code for the camera. To make it work anchor this script to a MainCamera.
 *  Make MainCamera separate object.
 *  
 *  Attach Capsule or any model that is considered as Player to the camera so that the script will take this model as variable [Player] and could Transform it.
 *  
 *  theta and phi are angle values.
 *  Distances between camera and the Player are assignet by distanceUp and distanceBehind.
 *  Zoom values are minScroll and maxScroll, the default position of zoom is stored in variable scrollv, the speed of the zooming in or out stored in variable scrollVel.
 *
 *************************

*/

using System;
using UnityEngine;

public class GT_CameraControlTPA : MonoBehaviour
{
    
    public Transform Player;

    float distanceBehind = 7f, distanceUp = 1.5f;
    float minScroll = 3f, maxScroll = 7.5f;
    float scrollV =0f;
    float scrollVel = 0.68f;

    float theta = 0f, phi = 0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       /*
        GT_CameraControlTPA cameraTp = transform.gameObject.AddComponent<GT_CameraControlTPA>();
        cameraTp.lateralRotate();
        cameraTp.verticalRotate();
        cameraTp.angleNotRight(); 
       */
    }

    // Update is called once per frame
    void Update()
    {
       

        Vector2 scroll = Input.mouseScrollDelta;
        if (scroll.y > 0)
        {
            scrollV = distanceBehind - scrollVel;
            
            distanceBehind = Mathf.Clamp(scrollV, minScroll, maxScroll);
        }
        else if(scroll.y < 0) { 
            scrollV = distanceBehind + scrollVel;
            
            distanceBehind = Mathf.Clamp(scrollV, minScroll, maxScroll);
        }

            transform.Rotate(Vector3.up, theta, Space.World);

        Quaternion rot = transform.rotation;
        transform.Rotate(Vector3.right,  phi);


        if (angleNotRight())
            transform.rotation = rot;   // Quaternion.Slerp(rot, transform.rotation, 0.1f);

        transform.position = Player.transform.position - distanceBehind * transform.forward + distanceUp * transform.up;
       // transform.LookAt(Player.transform.position, Vector3.up);
        Cursor.visible = false;
       // print("theta " + theta);
        //print("phi "+ phi);

    }
    public void setScroll(float minZoom, float maxZoom)
    {
        minScroll  = minZoom; maxScroll = maxZoom;
    }

    public void setScrollSpeed(float scrollSpeed)
    {
        scrollVel = scrollSpeed;
    }
    private bool angleNotRight()
    {
        Vector3 v = transform.forward;
        v.y = 0;
        v.Normalize();
        return Vector3.Dot(v, transform.forward) <= 0.9f;
    }

    public void lateralRotate(float diff) { 
        theta = diff;
    }

    public void verticalRotate(float diff) { 
        phi = diff;

        phi = Mathf.Clamp(phi,-45,45);
    }

    public void setDistance(float distance)
    {
       distanceBehind = distance;
    }
}
