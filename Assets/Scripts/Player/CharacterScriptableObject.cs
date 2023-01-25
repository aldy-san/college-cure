using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="CharacterScriptableObject", menuName ="ScriptableObjects/Character")]
public class CharacterScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject StartingWeapon;
    public GameObject startingWeapon { get => StartingWeapon; private set => StartingWeapon = value; }
    [SerializeField]
    Sprite Icon;
    public Sprite icon { get => Icon; private set => Icon = value; }

    [SerializeField]
    float MaxHealth;
    public float maxHealth { get => MaxHealth; private set => MaxHealth = value; }

    [SerializeField]
    float Recovery;
    public float recovery { get => Recovery; private set => Recovery = value; }

    [SerializeField]
    float MoveSpeed;
    public float moveSpeed { get => MoveSpeed; private set => MoveSpeed = value; }

    [SerializeField]
    float Might;
    public float might { get => Might; private set => Might = value; }

    [SerializeField]
    float ProjectileSpeed;
    public float projectileSpeed { get => ProjectileSpeed; private set => ProjectileSpeed = value; }

    [SerializeField]
    RuntimeAnimatorController Animation;
    public RuntimeAnimatorController animation { get => Animation; private set => Animation = value; }
}
