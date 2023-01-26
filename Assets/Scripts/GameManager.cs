using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class GameManager : MonoBehaviour
{
    public int currentCharacter = 0;
    public int currentLevel = 1;
    public CharacterDatabase characterDB;
    public LevelDatabase levelData;
    [HideInInspector]public CharacterScriptableObject currentCharacterData;
    public float currentTime = 0; //seconds
    // UI
    public Slider hpSlider;
    public Slider expSlider;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI timeText;
    public GameObject gameoverCanvas;
    public SpriteRenderer characterIcon;

    //GameOver UI
    public TextMeshProUGUI resTimeText;
    PlayerStats playerStats;
    void Awake()
    {
        currentCharacterData = characterDB.characters[currentCharacter];
        characterIcon.sprite = currentCharacterData.icon;
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
        timeText.text = "Time : " + TimeSpan.FromSeconds(currentTime).ToString("mm':'ss'.'f");
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameoverCanvas.SetActive(true);
        resTimeText.text = timeText.text;
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
