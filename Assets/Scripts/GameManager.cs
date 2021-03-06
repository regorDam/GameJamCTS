﻿using UnityEngine;
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
        //DontDestroyOnLoad(gameObject);

        uiManager = UIManager.Instance;//GameObject.Find("UI").GetComponent<UIManager>();
        uiManager.SetState(GameState.GAME);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
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
            if (!player) player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            //Update Time
            UIManager.Instance.textTime.text = "  <color=cyan>TIME : </color> " +
                string.Format("{0:#0}:{1:00}.{2:00}",
                    Mathf.Floor((time) / 60),
                    Mathf.Floor((time) % 60),
                    Mathf.Floor((time) * 100 % 100));

            //Update Coins
			UIManager.Instance.textCount.text = + coins +"/"+ (SceneManager.GetActiveScene().buildIndex + 6);

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
            //Restart();
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
        if (!player) Debug.Log("null");
        player.canFire = true;
        player.weaponModel.SetActive(true);
		string path = "";
        if (type == 0)
        {
            player.weaponModel.transform.Find("pinzell").gameObject.SetActive(false);
            player.weaponModel.transform.Find("teclado").gameObject.SetActive(true);
			path = "HUD/render_teclat";

        }
        else
        {
            player.weaponModel.transform.Find("pinzell").gameObject.SetActive(true);
            player.weaponModel.transform.Find("teclado").gameObject.SetActive(false);
			path = "HUD/render_pincell";
        }
        player.weaponRole = type;

		UIManager.Instance.gamePanel.Find ("Type").GetComponent<Image> ().enabled = true;
		UIManager.Instance.gamePanel.Find ("Type").GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
    }
}
