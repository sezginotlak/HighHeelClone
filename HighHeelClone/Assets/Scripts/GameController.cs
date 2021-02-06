using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text startText;
    public Text completedText;
    public Text gameOverText;
    public Text levelText;
    public bool isCollided;
    private float timePassed = 0;
    private int levels;
    private PlayerMovement playerMovement;

    private void Start()
    {
        levels = SceneManager.sceneCountInBuildSettings;
        playerMovement = GetComponentInParent<PlayerMovement>();
        levelText.text = "Level " + (SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        GameStarted();
        LevelCompleted();
        GameOver();
    }

    private bool isFalling()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x - 0.2f, transform.position.y + 1f, transform.position.z), -Vector3.up, out hit))
        {
            timePassed = 0;
        }
        else
        {
            timePassed += Time.deltaTime;
        }

        if (timePassed > 2f && transform.position.y < 0) return true;
        else return false;
        
    }

    private void GameStarted()
    {
        if (playerMovement.isGameStarted)
        {
            startText.gameObject.SetActive(false);
        }
    }
    private void LevelCompleted()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x - 0.2f, transform.position.y + 1f, transform.position.z), -Vector3.up, out hit))
        {
            if (hit.transform.tag == "Finish")
            {
                completedText.gameObject.SetActive(true);
                playerMovement.enabled = false;
                StartCoroutine("NextScene");
            }
        }
    }

    private void GameOver()
    {
        if((isCollided == true && transform.parent.Find("LeftFoots").childCount == 0) || isFalling())
        {
            gameOverText.gameObject.SetActive(true);
            playerMovement.enabled = false;
            StartCoroutine("Reload");
        }
    }

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator NextScene()
    {
        yield return new WaitForSeconds(5f);
        if (SceneManager.GetActiveScene().buildIndex == levels - 1) SceneManager.LoadScene(0);
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
