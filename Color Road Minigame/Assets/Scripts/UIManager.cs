using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject endScreen;

    // Update is called once per frame
    void Update()
    {
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
