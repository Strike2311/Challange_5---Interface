using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] goodPrefabs;
    public GameObject[] badPrefabs;
    public float spawnInterval = 3f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private int score;
    public bool isGameOver;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    void Start()
    {
        isGameOver = false;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void SetGameOver() {
        isGameOver = true;
        gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    GameObject getRandomObject(GameObject[] prefabs) {
        return prefabs[Random.Range(0,prefabs.Length)];
    }

    IEnumerator SpawnTarget() {
        while (true) {
            yield return new WaitForSeconds(spawnInterval);
            if (Random.Range(1, 10) < 4) {
                
                Instantiate(getRandomObject(badPrefabs));
            } else {
                Instantiate(getRandomObject(goodPrefabs));
            }
        }
    }
}
