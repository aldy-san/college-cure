using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject Prefab;
    public GameObject prefab { get => prefab; private set => prefab = value; }

    [SerializeField]
    float Damage;
    public float damage { get => Damage; private set => Damage = value; }
    [SerializeField]
    float MoveSpeed;
    public float moveSpeed { get => MoveSpeed; private set => MoveSpeed = value; }
    [SerializeField]
    float MaxHealth;
    public float maxHealth { get => MaxHealth; private set => MaxHealth = value; }
}
