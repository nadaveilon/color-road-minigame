using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;

    void Update()
    {
        // Start the game on tap/click
        if (Input.GetButtonUp("Fire1"))
        {
            GameManager.Instance.StartGame();
        }
    }

    public void OnStartAnimationComplete()
    {
        Destroy(startScreen);
    }
}
