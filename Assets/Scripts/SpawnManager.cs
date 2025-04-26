using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] goodPrefabs;
    public GameObject[] badPrefabs;
    public float spawnInterval = 3f;
    public float yMapLimit = -2f;
    private float spawnTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTimer > spawnInterval) {
            if (Random.Range(1, 10) < 4) {
                
                Instantiate(getRandomObject(badPrefabs));
            } else {
                Instantiate(getRandomObject(goodPrefabs));
            }
            spawnTimer = Time.time;
        }

        if (transform.position.y < yMapLimit) {
            Destroy(gameObject);
        }
        
    }

    GameObject getRandomObject(GameObject[] prefabs) {
        return prefabs[Random.Range(0,prefabs.Length)];
    }
}
