using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameState _gameState;
    private int contPlayer1=2;
    private int contPlayer2=2;

    public TextMesh playerName;



    private void Awake()
    {
        Instance = this;
        playerName.text="Player 1";
    }

    void Start()
    {
        _gameState = GameState.start;
        
    }

    public void UpdateGameState(GameState state)
    {
        _gameState = state;
    }
    public GameState GetGameState => _gameState;
    public void SwitchPlayer()
    {
        if (_gameState == GameState.player1 && contPlayer1 > 0){
            _gameState = GameState.player1;
            contPlayer1--;
            if(contPlayer1==0)
                _gameState = GameState.player2;
                contPlayer2=2;
        }
        else if (_gameState == GameState.player2 && contPlayer2 > 0){
            _gameState = GameState.player2;
            contPlayer2--;
            if(contPlayer2==0){
                _gameState = GameState.player1;
                contPlayer1=2;
            }
           
        }
    }

    void Update()
    {
        switch(_gameState)
        {
            case GameState.start:
                UpdateGameState(GameState.player1);
                break;
            case GameState.player1:
                playerName.text="Player 1";
                break;
            case GameState.player2:
                playerName.text="Player 2";
                break;
            case GameState.end:
                break;
        }
    }
    public enum GameState
    {
        start,
        player1,
        player2,
        end
    }
}
