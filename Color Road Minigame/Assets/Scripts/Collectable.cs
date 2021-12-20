using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Collider objectCollider;
    
    public int ColorIndex { get; set; }

    private void Reset()
    {
        // Initialize required components
        meshRenderer = GetComponent<MeshRenderer>();
        objectCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        if (meshRenderer != null)
        {
            meshRenderer.material.color = GameManager.Instance.availableColors[ColorIndex];
        }

        if (objectCollider != null)
        {
            objectCollider.isTrigger = ColorIndex == GameManager.Instance.ActiveColorIndex;
        }

        GameManager.Instance.OnActiveColorChanged.AddListener(ActiveColorChanged);
    }

    public void ActiveColorChanged(int index, Color color)
    {
        objectCollider.isTrigger = ColorIndex == index;
    }

    private void OnTriggerEnter(Collider other)
    {
        // If collectable is the same color as the ball, it will be a trigger and should be collected
        GameManager.Instance.ItemCollected();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If collectable is NOT the same color as the ball, it will have collision and should end the game
        GameManager.Instance.EndGame();
    }
}
