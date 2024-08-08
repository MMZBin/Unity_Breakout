using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public void OnBreak()
    {
        _point += 10;
        _scoreText.text = $"Score: {_point}";
        GameManager.Instance.Score = _point;
    }

    [SerializeField] private TextMeshProUGUI _scoreText;
    
    private uint _point = 0;
}
