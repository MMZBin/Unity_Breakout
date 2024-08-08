using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    //’ê•Ó‚ÉÕ“Ë‚µ‚½‚çƒŠƒUƒ‹ƒg‚ÉˆÚs‚·‚é
    public class GameOver : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            GameObject.Find("Manager").GetComponent<Manager>().Finish(GameManager.ResultType.FAILED);
        }
    }
}
