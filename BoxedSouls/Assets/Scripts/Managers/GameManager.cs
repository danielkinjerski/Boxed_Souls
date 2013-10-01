using UnityEngine;
using System.Collections;

public enum GameState { Pause, InGame, MainMenu, EndGame};
public enum Relationship { Friend, Foe };
public enum Difficulty { Easy, Normal, Hard };

public class GameManager : MonoBehaviour {
    static public GameState gameState;
    static public Difficulty difficulty;
	// Use this for initialization
	void Start () {
        gameState = GameState.MainMenu;
	}
	
	// Update is called once per frame
	void Update () {
        switch(gameState)
        {
            #region MainMenu
            case GameState.MainMenu:

                break;
            #endregion

            #region EndGame
            case GameState.EndGame:

                break;
            #endregion

            #region InGame
            case GameState.InGame:

                break;
            #endregion

            #region Pause
            case GameState.Pause:

                break;
            #endregion
        }
	
	}
}
