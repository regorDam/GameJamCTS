using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private PlayerController player;
    private int coins = 0;
    private float time = 60f;

    private UIManager uiManager;

    public static GameManager Instance
    {

        get
        {
            return instance;
        }
    }

    void Awake()
    {
        //Check if instanbce already exist
        if (instance == null)
            //if notm set instance to this;
            instance = this;
        //If instance already exist and it's not this
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        uiManager = GameObject.Find("UI").GetComponent<UIManager>();
        uiManager.SetState(GameState.GAME);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        UIManager.Instance.SetState(GameState.GAME);
        coins = 0;
        time = 60f;
        //Debug.Log("Restart");
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        UIManager.Instance.SetState(GameState.GAME);
    }

    void Update()
    {
        if (UIManager.Instance.state.Equals(GameState.GAME))
        {
            //Update Time
            UIManager.Instance.textTime.text = "TIME : " +
                string.Format("{0:#0}:{1:00}.{2:00}",
                    Mathf.Floor((time) / 60),
                    Mathf.Floor((time) % 60),
                    Mathf.Floor((time) * 100 % 100));

            //Update Coins
            UIManager.Instance.textCount.text = "x " + coins;

            UpdateColorsTime();
        }

        if (time <= 0)
        {
            //Debug.Log("timeout");
            if (player)
            {
                player.isDead = true;
                player.m_Character.m_Anim.Play("CharacterDie");
            }
            Restart();
        }

        time -= Time.deltaTime;


    }

    private void UpdateColorsTime()
    {
        //Update Colors Time
        if (time > 41)
            UIManager.Instance.textTime.color = Color.green;
        else if (time > 21)
            UIManager.Instance.textTime.color = Color.yellow;
        else if (time > 11)
            UIManager.Instance.textTime.color = Color.red;
    }

    public void TimeHit(float value)
    {
        time -= value;
    }

    public void AddCoin()
    {
        coins++;
    }

    public void AddRole(int type)
    {
        player.canFire = true;
        player.weaponRole = type;
    }
}
