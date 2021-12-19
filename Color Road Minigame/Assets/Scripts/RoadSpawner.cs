using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [Header("Global Properties")]
    [Range(3, 5)]
    [SerializeField] private int segmentsInMemory = 3;
    
    [Space]
    [Header("Segment Properties")]
    [Range(10,15)]
    [SerializeField] private int rowWidth = 13;
    [SerializeField] private int openingGapRows = 4;
    [SerializeField] private int contentRows = 14;
    [SerializeField] private int closeingGapRows = 2;
    [Range(2, 10)]
    [SerializeField] private int maxConsecutiveRows = 6;

    [Space]
    [Header("Prefabs")]
    [SerializeField] private GameObject roadSegmentPrefab;
    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private GameObject colorShifterPrefab;

    // Private data members
    private List<GameObject> roadSegments;
    private int lastShifterColorIndex;
    private int rowsTotal;
    private float relativeUnitScale;

    private void Reset()
    {
        segmentsInMemory = 3;
        rowWidth = 13;
        openingGapRows = 4;
        contentRows = 14;
        closeingGapRows = 2;
        maxConsecutiveRows = 6;
    }

    private void Awake()
    {
        rowsTotal = openingGapRows + contentRows + closeingGapRows;
        relativeUnitScale = rowWidth / 10f;

        // Initialize road segments
        roadSegments = new List<GameObject>(segmentsInMemory);
        
        for(int i = 0; i < segmentsInMemory; i++)
        {
            var segment = new GameObject();
            roadSegments.Add(segment);
        }
    }

    private void Start()
    {
        lastShifterColorIndex = GameManager.Instance.ActiveColorIndex;

        // Generate data for each segment and position it on screen
        for (int i = 0; i < roadSegments.Count; i++)
        {
            FillSegment(roadSegments[i]);
            roadSegments[i].transform.SetPositionZ(i * rowsTotal * rowWidth);
        }
    }

    private void FillSegment(GameObject segment)
    {
        // Create actual road from prefab
        var road = Instantiate(roadSegmentPrefab, segment.transform);
        road.transform.localScale = new Vector3(1, 1, (rowsTotal + 2) * relativeUnitScale);
        road.transform.position = new Vector3(0, 0, (5 * relativeUnitScale * (rowsTotal + 2)) - (5 * relativeUnitScale));
        road.GetComponentInChildren<MeshRenderer>().material.mainTextureScale = new Vector2(0.5f, rowsTotal + 2);

        // Initialize loop variables
        int relativeZ = openingGapRows * rowWidth;
        int rowsLeft = contentRows;

        // Filling each row
        while (rowsLeft > 0)
        {
            relativeZ += rowWidth;

            // Randomly skip rows
            if (Random.value < 0.3)
            {
                rowsLeft--;
                continue;
            }

            // Get amount of consecutive rows to fill
            int filledRows = Random.Range(1, Mathf.Min(maxConsecutiveRows, rowsLeft));
            
            // Determine the color order for the following consecutive rows
            var colorOrder = Enumerable.Range(0, GameManager.Instance.availableColors.Count).ToList();
            colorOrder.Shuffle();

            // Fill rows
            for (int i = 0; i < filledRows; i++)
            {
                var row = Instantiate(rowPrefab, segment.transform);
                row.transform.SetPositionZ(relativeZ);
                row.GetComponent<CollectableRow>().AssignColors(colorOrder);
                relativeZ += rowWidth;
            }
            
            rowsLeft -= filledRows + 1;
        }

        // Creating color shifter at the end of the segment
        relativeZ += closeingGapRows * rowWidth;
        var shifter = Instantiate(colorShifterPrefab, segment.transform);
        shifter.transform.SetPositionZ(relativeZ);
        lastShifterColorIndex = shifter.GetComponent<ColorShifter>().SetRandomColorIndex(lastShifterColorIndex);
    }
}
