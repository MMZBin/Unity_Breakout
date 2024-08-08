using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Result
{
    public class PlayAgain : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnClick();
            }
        }

        public void OnClick()
        {
            GameManager.Instance.SetState(GameManager.GameState.TITLE);
        }
    }
}
