using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    CharacterScriptableObject characterData;
    GameManager gameManager;

    float currentHealth;
    float currentRecovery;
    float currentMoveSpeed;
    float currentMight;
    float currentProjectileSpeed;

    [Header("Experience/Level")]
    public float experience = 0;
    public int level = 1;
    public float experienceCap = 100;
    public float experienceCapIncrease = 1.25f;

    [Header("I-Frames")]
    public float invincibilityDuration;
    float invincibilityTime;
    bool isInvicible;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        characterData = gameManager.currentCharacterData;
        currentHealth = characterData.maxHealth;
        currentRecovery = characterData.recovery;
        currentMoveSpeed = characterData.moveSpeed;
        currentMight = characterData.might;
        currentProjectileSpeed = characterData.projectileSpeed;
    }

    private void Update()
    {
        if(invincibilityTime > 0)
        {
            invincibilityTime -= Time.deltaTime;
        }
        else if (isInvicible)
        {
            isInvicible = false;
        }
    }

    public void InccreaseExperience(int amount)
    {
        experience += amount;
        LevelUpChecker();
    }

    void LevelUpChecker()
    {
        if (experience >= experienceCap)
        {
            level++;
            experience -= experienceCap;
            experienceCap *= experienceCapIncrease;
        }
    }

    public void TakeDamage(float damage)
    {
        if (!isInvicible)
        {
            currentHealth -= damage;

            invincibilityTime = invincibilityDuration;
            isInvicible = true;

            if (currentHealth <= 0)
            {
                Kill();
            }
        }

        
    }

    public void Kill()
    {
        //kill
    }

}
