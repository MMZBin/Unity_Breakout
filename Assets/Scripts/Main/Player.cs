using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Main
{
    //�v���C���[(�_)
    public class Player : MonoBehaviour
    {
        private void Start()
        {
            SPEED = GameManager.Instance.PlayerSpeed;
            float center = transform.localScale.x / 2;

            _leftLimit = _leftWall.transform.position.x - _leftWall.transform.localScale.x - center;
            _rightLimit = _rightWall.transform.position.x + _rightWall.transform.localScale.x + center;

            _madeInHeaven = _slider.GetComponent<MadeInHeaven>();

            _gm = GameObject.Find("Manager").GetComponent<Manager>();

            if (GameManager.Instance.UseSlider)
            {
                _posSlider.gameObject.SetActive(true);
                _posSlider.maxValue = _leftLimit;
                _posSlider.minValue = _rightLimit;
                _posSlider.value = 0;
            }
            else
            {
                _posSlider.gameObject.SetActive(false);
            }

            Debug.Log(_posSlider.minValue);
            Debug.Log(_posSlider.maxValue);
        }

        private void Update()
        {
            if (!_gm || _gm.IsFinished || _gm.IsPaused) { return; }

            float speed = 0;

            bool isPressShift = Input.GetKey(KeyCode.LeftShift);

            if (GameManager.Instance.UseSlider)
            {
                Vector3 pos = transform.position;
                pos.x = _posSlider.value;
                transform.position = pos;
                return;
            }

            //Shift�L�[�������n�߂����Ƃ����C�w�ɒʒm����
            if (isPressShift)
            {
                _madeInHeaven.Press();
            }

            //���C�w�̎c�ʂ��c���Ă�����v���C���[�̑��x��2�{�ɂ��A���Ԃ�0.25�{�܂Œx������
            if (_madeInHeaven.IsReady && isPressShift)
            {
                speed = SPEED * 2;
                Time.timeScale = 0.25f;
            }
            else
            {
                //�����łȂ���Ζ߂�
                _madeInHeaven.Release();
                speed = SPEED;
                Time.timeScale = 1;
            }

            //Ctrl�L�[�������Ă���ԃv���C���[�̑��x��2�{�ɂ���
            if (Input.GetKey(KeyCode.LeftControl))
            {
                speed = SPEED * 2;
            }

            //�ǂɂԂ����Ă��Ȃ���΃v���C���[�𓮂���
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x <= _leftLimit)
            {
                transform.position += transform.right * speed;
            }
            else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x >= _rightLimit)
            {
                transform.position -= transform.right * speed;
            }
        }

        private float SPEED;

        [SerializeField] private GameObject _leftWall;
        [SerializeField] private GameObject _rightWall;
        [SerializeField] private GameObject _slider;
        [SerializeField] private Slider _posSlider;

        private MadeInHeaven _madeInHeaven;
        private float _leftLimit = 0;
        private float _rightLimit = 0;
        private Manager _gm;
    }
}
