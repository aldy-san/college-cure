using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class GameManager : MonoBehaviour
{
    public int currentCharacter = 0;
    public CharacterDatabase characterDB;
    [HideInInspector]public CharacterScriptableObject currentCharacterData;
    public float currentTime = 0; //seconds
    // UI
    public Slider hpSlider;
    public Slider expSlider;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI timeText;
    public GameObject gameoverCanvas;
    PlayerStats playerStats;
    void Awake()
    {
        currentCharacterData = characterDB.characters[currentCharacter];
    }
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }
    void Update()
    {
        expSlider.value = playerStats.experience / playerStats.experienceCap;
        hpSlider.value = playerStats.CurrentHealth / playerStats.CurrentMaxHealth;
        levelText.text = "Level " + playerStats.level;

        currentTime += Time.deltaTime;
        timeText.text = TimeSpan.FromSeconds(currentTime).ToString("mm':'ss'.'f");
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameoverCanvas.SetActive(true);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
