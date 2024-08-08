using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Main
{
    public class StartShot : MonoBehaviour
    {

        // Use this for initialization
        public void Start()
        {
            transform.eulerAngles = new Vector3(0, Random.Range(120, 150), 0);

            Rigidbody rig = gameObject.GetComponent<Rigidbody>();
            rig.velocity = Vector3.zero;
            rig.AddForce(transform.forward * GameManager.Instance.BallSpeed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Destroyer>() == null) { return; }
            OnBreak();
        }
        public void OnBreak()
        {
            _point += 10;
            _scoreText.text = $"Score: {_point}";
            GameManager.Instance.Score = _point;
        }

        [SerializeField] private TextMeshProUGUI _scoreText;

        private uint _point = 0;
    }
}
