using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    TITLE,
    GAME,
    GAMEOVER
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    CutsceneManager cutscene;

    [SerializeField]
    PlayerController player;

    [SerializeField]
    GameObject TitleScreen;

    [SerializeField]
    GameObject GameOverScreen;

    //[SerializeField]
    //Color day;

    [SerializeField]
    Color nightColor;

    Color currentColor = Color.white;

    float timeSpeed = 0.05f; 

    GameState state;

    void StartTitleScreen()
    {
        TitleScreen.SetActive(true);
        player.DisableMovement();
    }

    void ExitTitleScreen ()
    {
        TitleScreen.SetActive(false);
        player.EnableMovement();
    }

    void ChangeState(GameState state)
    {
        this.state = state;
        switch (state)
        {
            case GameState.TITLE:
                StartTitleScreen();
                break;
            case GameState.GAME:
                ExitTitleScreen();
               
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Make the ambient lighting red

        ChangeState(GameState.TITLE);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case GameState.TITLE:
                if(Input.anyKey)
                {
                    ChangeState(GameState.GAME);
                }
                break;
        }

        

        RenderSettings.ambientLight = Color.Lerp(Color.white, nightColor, Mathf.PingPong(Time.time * timeSpeed, 1));

        
    }
}
