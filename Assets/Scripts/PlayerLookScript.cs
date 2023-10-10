using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerLookScript : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = 0;
        float mouseY = 0;
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                int id = touch.fingerId;
                if (EventSystem.current.IsPointerOverGameObject(id))
                {
                    continue;
                }
                else
                {
                    mouseX = Input.GetTouch(id).deltaPosition.x;
                    mouseY = Input.GetTouch(id).deltaPosition.y;
                }


            }
            mouseX *= mouseSensitivity;
            mouseY *= mouseSensitivity;
            //float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
            //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY * Time.deltaTime;
            xRotation = Mathf.Clamp(xRotation, -60, 60);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX * Time.deltaTime);
        }


    }
}
