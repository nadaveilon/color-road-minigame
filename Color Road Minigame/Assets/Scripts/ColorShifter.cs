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

    public int SetRandomColorIndex(int excludedIndex)
    {
        do
        {
            colorIndex = Random.Range(0, GameManager.Instance.availableColors.Count);
        }
        while (colorIndex == excludedIndex);

        return colorIndex;
    }
}
