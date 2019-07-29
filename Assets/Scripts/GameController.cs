using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public Vector3 spawnPoint;
    public int asteroidCount;
    public float startWait;
    public float spawnWait;

    //UI
    public Text scoreText;
    public int score = 0;
    public Text endText;
    private bool gameEnded;

    // Start is called before the first frame update
    void Start()
    {
        gameEnded = false;
        endText.gameObject.SetActive(false);
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (gameEnded)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Level1");
            }
        }
    }

    public void EndGame()
    {
        gameEnded = true;
        endText.gameObject.SetActive(true);
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < asteroidCount; i++)
            {
                Vector3 spawnAt = new Vector3(
                    Random.Range(-spawnPoint.x, spawnPoint.x),
                    spawnPoint.y,
                    spawnPoint.z
                    );
                Instantiate(asteroid, spawnAt, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }
}
