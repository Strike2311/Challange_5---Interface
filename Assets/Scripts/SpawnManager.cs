using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] goodPrefabs;
    public GameObject[] badPrefabs;
    public float spawnInterval;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI titleText;
    public Button restartButton;
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;
    private int score;
    public bool isGameOver;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    void Start()
    {
        
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
        SetObjectsActivityOnGameOver();
    }

    public void RestartGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame (int difficulty) {
        isGameOver = false;
        StartCoroutine(SpawnTarget());
        SetObjectsActivityOnStart();
        score = 0;
        UpdateScore(0);
        SetSpawnIntervalForDifficulty(difficulty);
    }

    public void SetObjectsActivityOnStart() {
        
        gameObject.SetActive(true);

        gameOverText.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        easyButton.gameObject.SetActive(false);
        mediumButton.gameObject.SetActive(false);
        hardButton.gameObject.SetActive(false);
    }

    public void SetObjectsActivityOnGameOver() {
        
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        titleText.gameObject.SetActive(false);
        gameObject.SetActive(false);
        easyButton.gameObject.SetActive(false);
        mediumButton.gameObject.SetActive(false);
        hardButton.gameObject.SetActive(false);
    }

    private void SetSpawnIntervalForDifficulty(int difficulty) {
        switch (difficulty) {
            case 1:
                spawnInterval = 1f;
                break;
            case 2:
                spawnInterval = 0.6f;
                break;
            case 3:
                spawnInterval = 0.3f;
                break;
        }
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
