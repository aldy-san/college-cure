using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObjects/CharacterDB")]
public class CharacterDatabase : ScriptableObject
{
    [SerializeField]
    List<CharacterScriptableObject> Characters;
    public List<CharacterScriptableObject> characters { get => Characters; private set => Characters = value; }
}
