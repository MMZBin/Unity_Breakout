
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Result
{
    public class TextChange : MonoBehaviour
    {
        void Start()
        {
            switch (GameManager.Instance.Result)
            {
                case GameManager.ResultType.CLEAR:
                    _result.text = "CLEAR!!!!!";
                    break;
                case GameManager.ResultType.FAILED:
                    _result.text = "Game Over!";
                    break;

            }

            _score.text = $"Score: {GameManager.Instance.Score}";
            _time.text = $"Time: {Math.Round(GameManager.Instance.Time, 2)}";
        }

        [SerializeField] private TextMeshProUGUI _result;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private TextMeshProUGUI _time;
    }

}