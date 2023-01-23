using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    SpriteRenderer sr;
    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;
    void Awake()
    {
        currentMoveSpeed = enemyData.moveSpeed;
        currentHealth = enemyData.maxHealth;
        currentDamage = enemyData.damage;
        sr = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        StartCoroutine("HitEffect");
        if (currentHealth <= 0)
        {
            Kill();
        }
    }
    public void Kill(){
        Destroy(gameObject);
    }
    IEnumerator HitEffect()
    {

        sr.color = new Color(1f, 0.4f, 0.4f, 1f);
        yield return new WaitForSeconds(0.2f);
        sr.color = new Color(1f, 1f, 1f, 1f);
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerStats player = col.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage);
        }
    }
}
