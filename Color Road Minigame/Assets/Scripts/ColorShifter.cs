using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorShifter : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    private int colorIndex;
    
    private void Reset()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        // randomize the target color
        colorIndex = GetRandomColorIndex();

        if (meshRenderer != null)
        {
            meshRenderer.material.color = GameManager.Instance.availableColors[colorIndex];
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.ActiveColorIndex = colorIndex;
        }
    }

    private int GetRandomColorIndex()
    {
        int index;

        do
        {
            index = Random.Range(0, GameManager.Instance.availableColors.Count);
        }
        while (index == GameManager.Instance.ActiveColorIndex);

        return index;
    }
}
