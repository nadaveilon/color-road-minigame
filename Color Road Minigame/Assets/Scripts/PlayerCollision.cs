using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    private void Reset()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void OnColorChanged(int index, Color color)
    {
        meshRenderer.material.color = color;
    }
}
