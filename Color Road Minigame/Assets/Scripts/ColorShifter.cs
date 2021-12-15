using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorShifter : MonoBehaviour
{
    [SerializeField] private List<Color> availableColors;

    public Color color;

    private void Start()
    {
        if (availableColors != null)
        {
            color = availableColors[Random.Range(0, availableColors.Count)];

            var renderer = GetComponent<MeshRenderer>();

            if (renderer != null)
            {
                renderer.material.color = color;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
