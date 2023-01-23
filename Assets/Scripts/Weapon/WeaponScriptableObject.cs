using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WeaponScriptableObject", menuName ="ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject Prefab;
    public GameObject prefab { get => Prefab; private set => Prefab = value; }

    [SerializeField]
    float Damage;
    public float damage { get => Damage; private set => Damage = value; }

    [SerializeField]
    float Speed;
    public float speed { get => Speed; private set => Speed = value; }

    [SerializeField]
    float CooldownDuration;
    public float cooldownDuration { get => CooldownDuration; private set => CooldownDuration = value; }

    [SerializeField]
    int Pierce;
    public int pierce { get => Pierce; private set => Pierce = value; }
}
