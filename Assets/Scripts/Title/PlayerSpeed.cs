using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(delegate { OnSliderChanged(); });
        _display.contentType = TMP_InputField.ContentType.DecimalNumber;
        _display.onEndEdit.AddListener(delegate { OnInputFieldChanged(); });

        _display.text = $"{Math.Round(GameManager.Instance.PlayerSpeed, 1)}";
        OnInputFieldChanged();
    }

    private void OnSliderChanged()
    {
        if (_isEditing) { return; }
        _isEditing = true;

        _display.text = $"{Math.Round(_slider.value, 1)}";
        GameManager.Instance.PlayerSpeed = _slider.value;

        _isEditing = false;
    }

    private void OnInputFieldChanged()
    {
        if (_isEditing) { return; }
        _isEditing = true;

        float value = float.Parse(_display.text);

        if (value > _slider.maxValue) { _display.text = $"{Math.Round(_slider.maxValue, 1)}"; }
        else if (value < _slider.minValue) { _display.text = $"{Math.Round(_slider.minValue, 1)}"; }

        _slider.value = value;
        GameManager.Instance.PlayerSpeed = value;

        _isEditing = false;
    }

    [SerializeField] TMP_InputField _display;
    private Slider _slider;
    private bool _isEditing = false;
}
