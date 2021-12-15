using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    
    [Range(1, 100)]
    [SerializeField] private float forwardSpeed = 10;

    [Range(1, 100)]
    [SerializeField] private float sidewaysSpeed = 60;

    [Range(0.1f, 100)]
    [SerializeField] private float sidewaysRangeAbsolute = 2;
    

    private float mouseXPosition;

    private void Reset()
    {
        forwardSpeed = 10;
        sidewaysSpeed = 60;
        sidewaysRangeAbsolute = 2;
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
            targetPosition.x = Mathf.Clamp(targetPosition.x, -sidewaysRangeAbsolute, sidewaysRangeAbsolute);
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
