using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj;
    private bool spawned;
    private bool gameOver;
    [HideInInspector]
    public bool startGame;
    [SerializeField]
    private GameObject hitPoint;
    private GameObject clone;
    [HideInInspector]
    public int level;
    [HideInInspector]
    public int score;
    [HideInInspector]
    public int multiplier;
    private int highscore;
    public Image health;
    public TMP_Text scoreText;
    public GameObject gameOverUI;
    public TMP_Text highscoreText;
    public TMP_Text postScoreText;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        
        highscore = PlayerPrefs.GetInt("highscore");
        // Make the game run as fast as possible
        Application.targetFrameRate = -1;
        // Limit the framerate to 60
        Application.targetFrameRate = 60;
        spawned = false;
        gameOver = false;
        startGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
        toString();
    }

    void Spawn()
    {
        if (!gameOver && startGame)
        {
            if (!spawned)
            {
                Instantiate(playerObj);
                player = GameObject.Find("Player(Clone)").GetComponent<Player>();
                spawned = true;
            }
            if (score >= 2000)
            {
                health.fillAmount -= 0.2f * Time.deltaTime;
                multiplier = 5;
                level = 5;
            }
            else if (player.speed >= 400)
            {
                health.fillAmount -= 0.2f * Time.deltaTime;
                multiplier = 4;
                level = 4;
            }
            else if (player.speed >= 300)
            {
                health.fillAmount -= 0.1f * Time.deltaTime;
                multiplier = 3;
                level = 3;
            }
            else if (player.speed >= 200)
            {
                health.fillAmount -= 0.1f * Time.deltaTime;
                multiplier = 2;
                level = 2;
            }
            else
            {
                health.fillAmount -= 0.1f * Time.deltaTime;
                multiplier = 1;
                level = 1;
            }

            if (!GameObject.Find("Circle Hit Marker(Clone)"))
            {
                var randomSpawn = Random.Range(0, 360);
                clone = Instantiate(hitPoint);
                clone.transform.eulerAngles = new Vector3(0, 0, randomSpawn);
                clone.transform.SetParent(GameObject.Find("Circle").transform, false);
            }
            
            if (health.fillAmount <= 0)
            {
                gameOver = true;
            }
        }
        else if (gameOver)
        {
            if (score > highscore)
            {
                highscore = score;
                PlayerPrefs.SetInt("highscore", highscore);
            }
            gameOverUI.SetActive(true);
            Destroy(GameObject.Find("Player(Clone)"));
            Destroy(GameObject.Find("Circle Hit Marker(Clone)"));
        }
    }

    void toString()
    {
        if (score <= 0)
        {
            score = 0;
        }
        scoreText.text = "" + score.ToString();
        highscoreText.text = "Highscore\n" + highscore.ToString();
        postScoreText.text = "Score\n" + score.ToString();
    }

    public void StartBtn()
    {
        startGame = true;
        GameObject.Find("Start").SetActive(false);
    }

    public void RetryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
