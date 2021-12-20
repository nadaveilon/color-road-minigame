using System.Collections.Generic;
using UnityEngine;

public class Finishline : MonoBehaviour
{
    [SerializeField] private List<GameObject> coloredElements;

    public void SetColor(Color color)
    {
        // Apply new color to all applicable elements
        foreach (var obj in coloredElements)
        {
            obj.GetComponent<MeshRenderer>().material.color = color;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.Instance.EndGame();
    }
}
