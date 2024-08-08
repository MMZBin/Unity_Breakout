using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ÉQÅ[ÉÄëSëÃÇÃä«óùÇÇ∑ÇÈ
public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        TITLE,
        PLAYING,
        FINISHED
    }

    public enum ResultType
    {
        CLEAR,
        FAILED
    }

    public enum GameDifficulty
    {
        NORMAL,
        EASY,
        HARD,
        VERY_HARD
    }

    public void Finish(ResultType result)
    {
        SceneManager.LoadScene("Result");

        State = GameState.FINISHED;
        Result = result;
    }

    public void SetState(GameState state)
    {
        switch (state)
        {
            case GameState.TITLE:
                SceneManager.LoadScene("Title");
                break;
            case GameState.PLAYING:
                SceneManager.LoadScene("Main");
                break;
            case GameState.FINISHED:
                SceneManager.LoadScene("Result");
                break;

        }

        State = state;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameManager Instance { get; private set; }

    public GameState State { get; private set; } = GameState.TITLE;
    public ResultType Result {  get; private set; } = ResultType.CLEAR;
    public GameDifficulty Difficulty { get; set; } = GameDifficulty.NORMAL;
    public uint Score { get; set; }  = 0;
    public float Time { get; set; } = 0;
    public bool UseSlider { get; set; } = false;
    public float PlayerSpeed { get; set; } = 0.5f;
    public uint BallSpeed { get; set; } = 1000;
}
