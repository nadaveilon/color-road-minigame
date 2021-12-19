using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(ConstantForce))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 30f;

    [Range(1, 100)]
    [SerializeField] private float sidewaysSpeed = 20f;

    [Range(0.1f, 5)]
    [SerializeField] private float sidewaysRangeAbsolute = 2f;

    [SerializeField] private ConstantForce force;

    private float mouseXPosition;
    private bool isGameActive = false;

    private void Reset()
    {
        forwardSpeed = 30f;
        sidewaysSpeed = 20f;
        sidewaysRangeAbsolute = 2f;
        force = GetComponent<ConstantForce>();
    }

    private void Update()
    {
        if (!isGameActive)
        {
            return;
        }

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

    public void GameStarted()
    {
        // Set constent forward motion on player
        isGameActive = true;
        force.force = Vector3.forward * forwardSpeed;
    }

    public void GameEnded()
    {
        // Freeze player interaction and movement
        isGameActive = false;
        force.force = Vector3.zero;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    private float GetCurrentMouseX()
    {
        var currPosition = Input.mousePosition;
        var currentPoint = Camera.main.ScreenToWorldPoint(
            new Vector3(currPosition.x, currPosition.y, Camera.main.transform.position.z));
        return currentPoint.x;
    }
}
