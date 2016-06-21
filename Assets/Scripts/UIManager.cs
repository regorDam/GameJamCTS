using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum GameState { MENU, GAME, OPTIONS, FINISH }

public class UIManager : MonoBehaviour
{

    public GameState state { get; private set; }

    public Transform menuPanel;
    public Transform gamePanel;
    public Transform optionsPanel;
    public Transform finishPanel;

    private static UIManager instance = null;

    [HideInInspector]
    public Text textTime;
    [HideInInspector]
    public Text textCount;

    public static UIManager Instance { get { return instance; } }

    // Use this for initialization
    void Awake()
    {
        SetState(GameState.MENU);
        DontDestroyOnLoad(gameObject);
        instance = this;

        textTime = UIManager.Instance.gamePanel.FindChild("Text").GetComponent<Text>();
        textCount = UIManager.Instance.gamePanel.FindChild("Count").GetComponent<Text>();
    }


    public void SetState(GameState gameState)
    {
        state = gameState;
    }


    void OnGUI()
    {

        DissableUI();
        switch (state)
        {

            case GameState.MENU:
                menuPanel.gameObject.SetActive(true);
                break;

            case GameState.GAME:
                gamePanel.gameObject.SetActive(true);
                break;

            case GameState.OPTIONS:
                break;

            case GameState.FINISH:
                break;

            default:
                break;
        }

    }

    private void DissableUI()
    {
        menuPanel.gameObject.SetActive(false);
        gamePanel.gameObject.SetActive(false);
        optionsPanel.gameObject.SetActive(false);
        finishPanel.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
		//Quit the application
		Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }


    public void ShowOptions()
    {

    }
}
