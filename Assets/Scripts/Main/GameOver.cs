using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    //��ӂɏՓ˂����烊�U���g�Ɉڍs����
    public class GameOver : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            GameObject.Find("Manager").GetComponent<Manager>().Finish(GameManager.ResultType.FAILED);
        }
    }
}
