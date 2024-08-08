using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stop : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            OnExecute();
        }
    }

    public void OnExecute()
    {
        GameManager.Instance.SetState(GameManager.GameState.TITLE);
    }
}
