using System.Collections;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] goodPrefabs;
    public GameObject[] badPrefabs;
    public float spawnInterval = 3f;
    public TextMeshProUGUI scoreText;
    private int score;
    private float spawnTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    void Start()
    {

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
