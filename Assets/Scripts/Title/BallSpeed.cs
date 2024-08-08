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
        _slider = GetComponent<Slider>(); //�{�[���̏����x�̃X���C�_�[
        _slider.onValueChanged.AddListener(delegate { OnSliderChanged(); }); //�X���C�_�[�̒l���ύX���ꂽ�Ƃ���OnSliderChanged()���\�b�h���Ăяo���悤�ɐݒ肷��
        _display.contentType = TMP_InputField.ContentType.IntegerNumber;
        _display.onEndEdit.AddListener(delegate { OnInputFieldChanged(); }); //�����x�̐��l���ύX���ꂽ�Ƃ���OnInputFieldChanged()���\�b�h���Ăяo���悤�ɐݒ肷��

        _display.text = $"{GameManager.Instance.BallSpeed}"; //�ۑ�����Ă��鏉���l��\������
        OnInputFieldChanged();
    }

    //�X���C�_�[�̒l���ύX���ꂽ��
    private void OnSliderChanged()
    {
        if (_isEditing) { return; }
        _isEditing = true;

        _display.text = $"{_slider.value}";
        GameManager.Instance.BallSpeed = (uint)_slider.value;

        _isEditing = false;
    }

    //�e�L�X�g�{�b�N�X�̒l���ύX���ꂽ��
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

    [SerializeField] TMP_InputField _display; //�����x�̃e�L�X�g�{�b�N�X
    private Slider _slider;
    private bool _isEditing = false; //�X���C�_�[�̒l�ƃe�L�X�g�{�b�N�X�̏����������Ɏ��s����Ȃ��悤�ɂ���
}
