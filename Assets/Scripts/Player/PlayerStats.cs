using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    CharacterScriptableObject characterData;
    GameManager gameManager;

    float currentMaxHealth;
    public float CurrentMaxHealth { get => currentMaxHealth; private set => currentMaxHealth = value; }
    float currentHealth;
    public float CurrentHealth { get => currentHealth; private set => currentHealth = value; }
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

    [Header("Player Components")]
    SpriteRenderer sr;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        sr = GetComponent<SpriteRenderer>();
        characterData = gameManager.currentCharacterData;
        currentMaxHealth = characterData.maxHealth;
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
            experienceCap = experienceCap * experienceCapIncrease;
        }
    }

    public void TakeDamage(float damage)
    {
        StartCoroutine("HitEffect");
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
    IEnumerator HitEffect()
    {

        sr.color = new Color(1f, 0.4f, 0.4f, 1f);
        yield return new WaitForSeconds(0.2f);
        sr.color = new Color(1f, 1f, 1f, 1f);
    }
    public void Kill()
    {
        gameManager.GameOver();
    }

}
