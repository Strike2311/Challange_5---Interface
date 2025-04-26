using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] goodPrefabs;
    public GameObject[] badPrefabs;
    public float spawnInterval = 3f;
    private float spawnTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
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
