using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Idle,
        Playing,
        GameLost,
        GameWon
    } 
    GameState currentGameState;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentGameState = GameState.Idle;
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3f);
        currentGameState = GameState.Playing;
    }
}
