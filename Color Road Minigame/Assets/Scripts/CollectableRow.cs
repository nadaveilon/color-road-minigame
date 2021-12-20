using Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectableRow : MonoBehaviour
{
    [SerializeField] private GameObject collectablePrefab;

    private List<Tuple<GameObject, Collectable>> collectables;

    private void Awake()
    {
        // Create the collectable items in the row
        var right = Instantiate(collectablePrefab, transform);
        var center = Instantiate(collectablePrefab, transform);
        var left = Instantiate(collectablePrefab, transform);

        // Set items X position
        right.transform.SetPositionX(-GameManager.roadLimitAbsolute);
        left.transform.SetPositionX(GameManager.roadLimitAbsolute);

        // Get the Collectable script of each item
        collectables = new List<Tuple<GameObject, Collectable>>()
        {
            new Tuple<GameObject, Collectable>(right, right.GetComponent<Collectable>()),
            new Tuple<GameObject, Collectable>(center, center.GetComponent<Collectable>()),
            new Tuple<GameObject, Collectable>(left, left.GetComponent<Collectable>())
        };
    }

    public void AssignColors(List<int> order)
    {
        // Assign color index to each collectable item
        for (int i = 0; i < collectables.Count; i++)
        {
            collectables[i].Item2.ColorIndex = order[i];
        }
    }
}
