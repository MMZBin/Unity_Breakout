using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Title
{
    public class StartGame : MonoBehaviour
    {
        public void OnClick()
        {
            GameObject.Find("Manager").GetComponent<Manager>().GameStart();
        }
    }
}
