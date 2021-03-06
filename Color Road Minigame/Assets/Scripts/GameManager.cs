using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Editor Fields

    [Header("Global Variables")]
    public List<Color> availableColors;
    [SerializeField] private int collectableValue = 1;

    [Space]
    [Header("Events")]
    public UnityEvent<int, Color> OnActiveColorChanged;
    public UnityEvent<string> OnScoreChanged;
    public UnityEvent OnGameStart;
    public UnityEvent OnGameOver;

    #endregion

    #region Constants
    
    public const float roadLimitAbsolute = 2f;

    #endregion

    #region Public Properties
    
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
        private set { instance = value; }
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

    private int score = 0;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            OnScoreChanged.Invoke(value.ToString());
        }
    }

    #endregion

    #region Unity Methods

    private void Reset()
    {
        // Reset all properties to their default values
        score = 0;
        collectableValue = 1;
        availableColors = new List<Color>()
        {
            new Color(0.2666667f, 0.8666667f, 0.3411765f), // Green #FF44DD57
            new Color(0.9568627f, 0.4666667f, 0.4196078f), // Red #FFF4776B
            new Color(1f, 0.8235294f, 0.1960784f) // Yellow #FFFFD232
        };
    }

    private void Awake()
    {
        // Make sure only a single instance of the game manager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    #endregion

    #region Public Methods

    public void ItemCollected()
    {
        Score += collectableValue;
    }

    public void StartGame()
    {
        OnGameStart.Invoke();
    }

    public void EndGame()
    {
        OnGameOver.Invoke();
    }

    #endregion
}
