using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent<int, Color> OnActiveColorChanged;
    
    public List<Color> availableColors;

    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
        private set
        {
            instance = value;
        }
    }
    
    private int activeColorIndex = 0;
    public int ActiveColorIndex
    {
        get { return activeColorIndex; }
        set
        {
            // Make sure new index is valid
            if (value < 0 || value >= availableColors.Count)
                return;

            activeColorIndex = value;
            OnActiveColorChanged?.Invoke(value, availableColors[value]);
        }
    }

    private void Awake()
    {
        // Make sure only a single instance of the game manager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
