using StarterAssets;
using UnityEngine;

public class GameManager : SingletonGeneric<GameManager>
{
    public ThirdPersonController player;
    public QuestionController questionController;
    
    public GameState GameState;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        StartingGame();
    }
    private void StartingGame()
    {
        Debug.Log("Starting game");
        questionController.LoadQuestion();
    }
    public void ChangeState(GameState state)
    {
        GameState = state;
        switch (state)
        {
            case GameState.Playing: player.CanMove = true; Cursor.lockState = CursorLockMode.Locked; break;
            case GameState.Answering: player.CanMove = false; Cursor.lockState = CursorLockMode.None; break;
        }
    }

    public void GameVictory()
    {
        // TO DO : Victory
    }
}

public enum GameState
{
    Playing,
    Answering
}
