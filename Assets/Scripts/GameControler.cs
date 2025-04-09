using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    public Ball ball;
    public int health = 3;
    public GameObject ballPrefab;
    public GameObject player;
    public Vector3 offset;
    bool newBall = false;
    public GameObject restartPanel;
    public GameObject inGamePanel;
    public GameObject winPanel;
    public Text healthText;
    public GameObject blocksContainer;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        restartPanel.SetActive(false);
        winPanel.SetActive(false);
        inGamePanel.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (ball == null)
        {
            newBall = true;
            health--;
            if (health > 0)
            {
                GameObject ballInstance = Instantiate(ballPrefab);
                ballInstance.transform.SetParent(transform);
                ballInstance.transform.position = player.transform.position + offset;
                newBall = false;
                ball = ballInstance.GetComponent<Ball>();
            }
            
        }
        if(health == 0)
        {
            restartPanel.SetActive(true);
            //winPanel.SetActive(false);
            inGamePanel.SetActive(false);
            Time.timeScale = 0;
        }
        healthText.text = "Lifes " + (health -1);

        if(blocksContainer.transform.childCount == 0)
        {
            Time.timeScale = 0;
            //restartPanel.SetActive(false);
            inGamePanel.SetActive(false);
            winPanel.SetActive(true);

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game_");
    }
}
