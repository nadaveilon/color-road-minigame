using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 10;
    [SerializeField] private float sidewaysSpeed = 50;
    [SerializeField] private Rigidbody playerRigidbody;

    private float mouseXPosition;

    private void Reset()
    {
        forwardSpeed = 10;
        sidewaysSpeed = 50;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // Add constant forward velocity
        playerRigidbody.AddForce(Vector3.forward * forwardSpeed, ForceMode.VelocityChange);
    }

    private void Update()
    {
        // Check if fire button was pressed
        if (Input.GetButtonDown("Fire1"))
        {
            mouseXPosition = GetCurrentMouseX();
        }
        // Check if fire button is held down
        else if (Input.GetButton("Fire1"))
        {
            // Get the delta of the mouse x axis movement
            var currMouseX = GetCurrentMouseX();
            var dx = currMouseX - mouseXPosition;
            mouseXPosition = currMouseX;

            // move the player according to delta
            var targetPosition = transform.position;
            targetPosition.x += dx * sidewaysSpeed * Time.deltaTime;
            transform.position = targetPosition;
        }
    }

    private float GetCurrentMouseX()
    {
        var currPosition = Input.mousePosition;
        var currentPoint = Camera.main.ScreenToWorldPoint(
            new Vector3(currPosition.x, currPosition.y, Camera.main.transform.position.z));
        return currentPoint.x;
    }
}
