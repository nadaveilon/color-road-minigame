using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishline : MonoBehaviour
{
    [SerializeField] private List<GameObject> coloredElements;

    public void SetColor(int index, Color color)
    {
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
