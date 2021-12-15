using System;
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

    private void Awake()
    {
        GameManager.Instance.OnActiveColorChanged.AddListener(OnColorChanged);
    }

    private void OnColorChanged(int index, Color color)
    {
        renderer.material.color = color;
    }
}
