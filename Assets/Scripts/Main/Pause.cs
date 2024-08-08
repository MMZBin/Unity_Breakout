using Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//一時停止する
public class Pause : MonoBehaviour
{
    private void Start()
    {
        _manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    private void Update()
    {
        if (_manager.IsFinished || _madeInHeaven.IsUsing) { return; }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isPaused = !_isPaused;
        }

        if (_isPaused)
        {
            Color color = _overlayImage.color;
            color.a = 0.5f;
            _overlayImage.color = color;

            _pauseText.gameObject.SetActive(true);
            _overlayImage.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            _pauseText.gameObject.SetActive(false);
            _overlayImage.gameObject.SetActive(false);
            Time.timeScale = 1;
        }

        _manager.IsPaused = _isPaused; //マネージャーに一時停止しているかどうかを報告する
    }

    [SerializeField] private Image _overlayImage;
    [SerializeField] private TextMeshProUGUI _pauseText;
    [SerializeField] private MadeInHeaven _madeInHeaven;

    private Manager _manager;
    private bool _isPaused = false;
}
