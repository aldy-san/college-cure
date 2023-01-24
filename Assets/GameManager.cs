using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int currentCharacter = 0;
    public CharacterDatabase characterDB;
    [HideInInspector]public CharacterScriptableObject currentCharacterData;

    // UI
    public Slider hpSlider;
    public Slider expSlider;
    public TextMeshProUGUI levelText;
    PlayerStats playerStats;
    private void Awake()
    {
        currentCharacterData = characterDB.characters[currentCharacter];
    }
    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }
    private void Update()
    {
        expSlider.value = playerStats.experience / playerStats.experienceCap;
        hpSlider.value = playerStats.CurrentHealth / playerStats.CurrentMaxHealth;
        levelText.text = "Level " + playerStats.level;
    }

}
