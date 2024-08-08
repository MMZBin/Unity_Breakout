using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public class Destroyer : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
}
