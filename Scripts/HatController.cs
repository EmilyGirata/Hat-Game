using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HatController : MonoBehaviour
{
    public Camera cam;

    private float maxWidth;
    private bool canControl;

    void Start()
    {

        if (cam == null)
            cam = Camera.main;

        canControl = true;

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);

        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);

        float hatWidth = GetComponent<Renderer>().bounds.extents.x;

        maxWidth = targetWidth.x - hatWidth;

    }


    void FixedUpdate()
    {
        if (canControl)
        {
            Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);

            Vector3 targetPosition = new Vector3(rawPosition.x, -2.0f, 0.0f);

            float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);

            targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);

            GetComponent<Rigidbody2D>().MovePosition(targetPosition);
        }
    }

    public void toggleControl(bool value)
    {
        canControl = value;
    }
}
