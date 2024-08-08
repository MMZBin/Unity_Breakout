using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Title
{
    //タイトルのシーンを管理する
    public class Manager : MonoBehaviour
    {
        private void Start()
        {
            _difficulty.value = (int)GameManager.Instance.Difficulty; //設定されている難易度を取得し、表示する
            _difficulty.onValueChanged.AddListener(delegate { OnDifficultyChanged(); }); //難易度が変更されたときにOnDifficultyChanged()メソッドを呼び出すように設定する
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameStart();
            }
        }

        //Mainシーンに移行する
        public void GameStart()
        {
            GameManager.Instance.SetState(GameManager.GameState.PLAYING);
        }

        //難易度を変更する
        public void OnDifficultyChanged()
        {
            string item =_difficulty.options[_difficulty.value].text;

            switch (item)
            {
                case "かんたん":
                    GameManager.Instance.Difficulty = GameManager.GameDifficulty.EASY;
                    return;
                case "普通":
                    GameManager.Instance.Difficulty = GameManager.GameDifficulty.NORMAL;
                    return;
                case "難しい":
                    GameManager.Instance.Difficulty = GameManager.GameDifficulty.HARD;
                    return;
                case "ベリハ":
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
