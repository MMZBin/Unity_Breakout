using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Title
{
    //�^�C�g���̃V�[�����Ǘ�����
    public class Manager : MonoBehaviour
    {
        private void Start()
        {
            _difficulty.value = (int)GameManager.Instance.Difficulty; //�ݒ肳��Ă����Փx���擾���A�\������
            _difficulty.onValueChanged.AddListener(delegate { OnDifficultyChanged(); }); //��Փx���ύX���ꂽ�Ƃ���OnDifficultyChanged()���\�b�h���Ăяo���悤�ɐݒ肷��
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameStart();
            }
        }

        //Main�V�[���Ɉڍs����
        public void GameStart()
        {
            GameManager.Instance.SetState(GameManager.GameState.PLAYING);
        }

        //��Փx��ύX����
        public void OnDifficultyChanged()
        {
            string item =_difficulty.options[_difficulty.value].text;

            switch (item)
            {
                case "���񂽂�":
                    GameManager.Instance.Difficulty = GameManager.GameDifficulty.EASY;
                    return;
                case "����":
                    GameManager.Instance.Difficulty = GameManager.GameDifficulty.NORMAL;
                    return;
                case "���":
                    GameManager.Instance.Difficulty = GameManager.GameDifficulty.HARD;
                    return;
                case "�x���n":
                    GameManager.Instance.Difficulty = GameManager.GameDifficulty.VERY_HARD;
                    return;
            }
        }

        public void OnUseSliderToggled()
        {
            if (GameManager.Instance.State != GameManager.GameState.TITLE) { return; }
            GameManager.Instance.UseSlider = _useSlider.isOn;
        }

        [SerializeReference] private TMP_Dropdown _difficulty;
        [SerializeField] private Toggle _useSlider;
    }
}
