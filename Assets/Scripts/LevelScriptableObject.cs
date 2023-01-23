using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CharacterScriptableObject", menuName ="ScriptableObjects/Level")]
public class LevelScriptableObject : ScriptableObject
{
    // [System.Serializable]
    [System.Serializable]
    public class Enemies
    {
        public GameObject prefab;
        public int spawnRate;
    }
    [System.Serializable]
    public class Wave
    {
        public float spawnTime;
        public int spawnCount;
        public List<Enemies> enemies;
    }
    [SerializeField]
    List<Wave> Waves;
    public List<Wave> waves { get => Waves; private set => Waves = value; }
}
