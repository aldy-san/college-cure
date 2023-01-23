using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    public float destroyAfterSeconds;

    protected float currentDamage;
    protected float currentCooldownDuration;
    // Start is called before the first frame update
    void Awake()
    {
        currentDamage = weaponData.damage;
        currentCooldownDuration = weaponData.cooldownDuration;
    }
    protected virtual void Start()
    {
        
        Destroy(gameObject, destroyAfterSeconds);
    }
    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
        }
    }
}
