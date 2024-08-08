using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;

namespace Main
{
    public class Manager : MonoBehaviour
    {
        private void Awake()
        {
            InitField();
        }

        private void Start()
        {
            _startTime = Time.time;
        }

        private void Update()
        {
            if (GameManager.Instance.State != GameManager.GameState.PLAYING || IsFinished) { return; }

            _time.text = $"Time: {Math.Round(Time.time - _startTime, 2)}";

            if (RemainingBlocks == 0)
            {
                Finish(GameManager.ResultType.CLEAR);
            }
        }

        //難易度に合わせてフィールドを生成する
        private void InitField()
        {
            float scaleX = 10;   //X軸方向の広さ
            float rangeY = 9;    //ブロックが置かれるY軸方向の範囲
            float barLength = 0; //プレイヤーの長さ
            Vector2 density = Vector2.zero; //ブロックの密度

            switch (GameManager.Instance.Difficulty)
            {
                case GameManager.GameDifficulty.EASY:
                    scaleX = 10;
                    rangeY = 9;
                    barLength = 7;
                    density = new Vector2(3, 2);
                    break;
                case GameManager.GameDifficulty.NORMAL:
                    scaleX = 10;
                    rangeY = 9;
                    barLength = 4;
                    density = new Vector2(1, 2);
                    break;
                case GameManager.GameDifficulty.HARD:
                    scaleX = 20;
                    rangeY = 20;
                    barLength = 3;
                    density = new Vector2(4, 4);
                    break;
                case GameManager.GameDifficulty.VERY_HARD:
                    scaleX = 40;
                    rangeY = 40;
                    barLength = 5;
                    density = new Vector2(1, 2);
                    break;
            }

            //床の長さを決定する
            Vector3 floorScale = _floor.transform.localScale;
            floorScale.x = scaleX;
            _floor.transform.localScale = floorScale;
            //プレイヤーの長さを決定する
            Vector3 playerScale = _player.transform.localScale;
            playerScale.x = barLength;
            _player.transform.localScale = playerScale;


            //ブロックが左右対称になるように値をオフセットする
            //例：10 -> 6, -4
            float rangeYMax = 0;
            switch (scaleX)
            {
                case 10:
                    rangeYMax = rangeY - 6;
                    break;
                case 20:
                    rangeYMax = rangeY - 10;
                    break;
                case 40:
                    rangeYMax = rangeY - 21;
                    break;
            }

            _box.GetComponent<BlockInit>().RangeY = new Range(rangeYMax - rangeY, rangeYMax);
            _box.GetComponent<BlockInit>().Density = density;

        }

        public void Finish(GameManager.ResultType result)
        {
            IsFinished = true;
            //StartCoroutine(SlowFinish(result));
            StartCoroutine(Fadeout(result));
        }

        //非同期でn秒待機し、画面を暗くする
        private IEnumerator Fadeout(GameManager.ResultType result)
        {
            float totalTime = Time.time - _startTime;

            Time.timeScale = 0.05f; //速度を0.05倍にする
            _overlayImage.SetActive(true); //黒の画像を表示する

            float startTime = Time.realtimeSinceStartup;

            float elapsedTime = 0;
            const int duration = 3;
            while (elapsedTime <= duration) //指定した時間を過ぎるまで繰り返す
            {
                if (GameManager.Instance.State != GameManager.GameState.PLAYING) {  break; }
                Color color = _overlayImage.GetComponent<Image>().color; //元のカラーを取得する
                color.a = Mathf.Lerp(0, 1, elapsedTime / duration); //経過時間に合わせて透明度を下げる

                _overlayImage.GetComponent<Image>().color = color;

                elapsedTime = Time.realtimeSinceStartup - startTime;
                yield return null;
            }

            Time.timeScale = 1;
            _overlayImage.SetActive(false);

            Debug.Log(totalTime);

            GameManager.Instance.Time = totalTime;
            GameManager.Instance.Finish(result);
        }

        //残っているブロック数を取得する
        private int RemainingBlocks {
            get
            {
                if (_blockParent == null) { return -1; }
                return _blockParent.transform.childCount;
            }
        }

        public bool IsFinished { get; private set; } = false;
        public bool IsPaused { get; set; } = false;

        [SerializeField] private GameObject _blockParent;  //ブロックの親
        [SerializeField] private GameObject _overlayImage; //終わったときに上から被せる画像

        [SerializeField] private GameObject _box;    //外枠
        [SerializeField] private GameObject _floor;  //床
        [SerializeField] private GameObject _player; //プレイヤー(動く棒)

        [SerializeField] private TextMeshProUGUI _time;

        private float _startTime; //つかってない
    }
}
