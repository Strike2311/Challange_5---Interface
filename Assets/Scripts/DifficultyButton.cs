using System;
using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private SpawnManager spawnManager;
    public int difficulty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        button.onClick.AddListener(SetDifficulty);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty() {
        spawnManager.StartGame(difficulty);
    }
}
