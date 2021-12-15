using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public int rowWidth = 10;
    public int segmentsInMemory = 3;
    
    public int openingGapRows = 4;
    public int contentRows = 14;
    public int closeingGapRows = 2;
    public int maxConsecutiveRows = 6;

    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private GameObject colorShifterPrefab;

    private Pool<CollectableRow> rowsPool;
    private List<GameObject> roadSegments;

    private void Awake()
    {
        //rowsPool = new Pool<CollectableRow>(rowPrefab, contentRows * segmentsInMemory);
        roadSegments = new List<GameObject>(segmentsInMemory);
        
        for(int i = 0; i < segmentsInMemory; i++)
        {
            var segment = new GameObject();
            roadSegments.Add(segment);
        }
    }

    private void Start()
    {
        for (int i = 0; i < roadSegments.Count; i++)
        {
            FillSegment(roadSegments[i]);
            roadSegments[i].transform.SetPositionZ(i * 200);
        }
    }

    private void FillSegment(GameObject segment)
    {
        int relativeZ = openingGapRows * rowWidth;
        int rowsLeft = contentRows;

        while (rowsLeft > 0)
        {
            // Should skip row
            if (Random.value < 0.3)
            {
                relativeZ += rowWidth;
                rowsLeft--;
                continue;
            }

            // Get amount of consecutive rows to fill
            int filledRows = Random.Range(1, Mathf.Min(maxConsecutiveRows, rowsLeft));
            
            // Determine the color order for the following rows
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

            relativeZ += rowWidth;
            rowsLeft -= filledRows + 1;
        }

        relativeZ += closeingGapRows * rowWidth;
        var shifter = Instantiate(colorShifterPrefab, segment.transform);
        shifter.transform.SetPositionZ(relativeZ);
    }
}
