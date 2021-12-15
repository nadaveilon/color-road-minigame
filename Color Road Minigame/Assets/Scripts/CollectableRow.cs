using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Assets.Scripts.Utilities;

public class CollectableRow : MonoBehaviour
{
    [SerializeField] private GameObject collectable;

    private List<Tuple<GameObject, Collectable>> collectables;
    public List<int> colorOrder;

    private void Awake()
    {
        var right = Instantiate(collectable, transform);
        var center = Instantiate(collectable, transform);
        var left = Instantiate(collectable, transform);

        collectables = new List<Tuple<GameObject, Collectable>>()
        {
            new Tuple<GameObject, Collectable>(right, right.GetComponent<Collectable>()),
            new Tuple<GameObject, Collectable>(center, center.GetComponent<Collectable>()),
            new Tuple<GameObject, Collectable>(left, left.GetComponent<Collectable>())
        };
    }

    private void Start()
    {
        collectables[0].Item1.transform.SetPositionX(-GameManager.Instance.roadLimitAbsolute);
        collectables[2].Item1.transform.SetPositionX(GameManager.Instance.roadLimitAbsolute);
    }

    public void AssignColors(List<int> order)
    {
        for (int i = 0; i < collectables.Count; i++)
        {
            collectables[i].Item2.colorIndex = order[i];
        }
    }

    private void RandomlyAssignColors()
    {
        var options = new List<int>(Enumerable.Range(0, GameManager.Instance.availableColors.Count));
        options.Shuffle();
        AssignColors(options);
    }
}
