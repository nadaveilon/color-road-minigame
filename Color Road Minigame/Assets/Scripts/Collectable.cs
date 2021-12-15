using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Collider objectCollider;
    
    public int colorIndex;

    private void Reset()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        objectCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        if (meshRenderer != null)
        {
            meshRenderer.material.color = GameManager.Instance.availableColors[colorIndex];
        }

        if (objectCollider != null)
        {
            objectCollider.isTrigger = colorIndex == GameManager.Instance.ActiveColorIndex;
        }

        GameManager.Instance.OnActiveColorChanged.AddListener(ActiveColorChanged);
    }

    public void ActiveColorChanged(int index, Color color)
    {
        objectCollider.isTrigger = colorIndex == index;
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
