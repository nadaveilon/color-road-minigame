using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            GameManager.Instance.StartGame();
        }
    }

    public void OnAnimationComplete()
    {
        Destroy(gameObject);
    }
}
