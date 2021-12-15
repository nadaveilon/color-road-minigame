using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Collider objectCollider;
    
    private int colorIndex;
    public int ColorIndex
    {
        get { return colorIndex; }
        set
        {
            colorIndex = value;

            if (meshRenderer != null)
            {
                meshRenderer.material.color = GameManager.Instance.availableColors[value];
            }

            if (objectCollider != null)
            {
                objectCollider.isTrigger = colorIndex == GameManager.Instance.ActiveColorIndex;
            }
        }
    }

    private void Reset()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        objectCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        ColorIndex = ColorIndex;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.ItemCollected();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.Instance.EndGame();
    }
}
