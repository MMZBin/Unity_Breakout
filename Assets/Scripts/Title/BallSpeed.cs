using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public class BallSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        _slider = GetComponent<Slider>(); //ボールの初速度のスライダー
        _slider.onValueChanged.AddListener(delegate { OnSliderChanged(); }); //スライダーの値が変更されたときにOnSliderChanged()メソッドを呼び出すように設定する
        _display.contentType = TMP_InputField.ContentType.IntegerNumber;
        _display.onEndEdit.AddListener(delegate { OnInputFieldChanged(); }); //初速度の数値が変更されたときにOnInputFieldChanged()メソッドを呼び出すように設定する

        _display.text = $"{GameManager.Instance.BallSpeed}"; //保存されている初期値を表示する
        OnInputFieldChanged();
    }

    //スライダーの値が変更された時
    private void OnSliderChanged()
    {
        if (_isEditing) { return; }
        _isEditing = true;

        _display.text = $"{_slider.value}";
        GameManager.Instance.BallSpeed = (uint)_slider.value;

        _isEditing = false;
    }

    //テキストボックスの値が変更された時
    private void OnInputFieldChanged()
    {
        if (_isEditing) { return; }
        _isEditing = true;

        uint value = uint.Parse(_display.text);

        if (value > _slider.maxValue) { _display.text = $"{_slider.maxValue}"; }
        else if (value < _slider.minValue) { _display.text = $"{_slider.minValue}"; }

        _slider.value = value;
        GameManager.Instance.BallSpeed = value;

        _isEditing = false;
    }

    [SerializeField] TMP_InputField _display; //初速度のテキストボックス
    private Slider _slider;
    private bool _isEditing = false; //スライダーの値とテキストボックスの処理が同時に実行されないようにする
}
