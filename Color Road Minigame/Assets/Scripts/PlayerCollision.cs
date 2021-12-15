using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private MeshRenderer renderer;

    private void Reset()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ColorShifter"))
        {
            var shifter = collision.gameObject.GetComponent<ColorShifter>();
            renderer.material.color = shifter.color;
        }
    }
}
