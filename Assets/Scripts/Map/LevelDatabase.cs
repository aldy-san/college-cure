using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObjects/LevelDB")]
public class LevelDatabase : ScriptableObject
{
    [SerializeField]
    List<LevelScriptableObject> Levels;
    public List<LevelScriptableObject> levels { get => Levels; private set => Levels = value; }
}
