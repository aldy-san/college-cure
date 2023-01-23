using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentCharacter = 0;
    public CharacterDatabase characterDB;
    [HideInInspector]public CharacterScriptableObject currentCharacterData;

    private void Awake()
    {
        currentCharacterData = characterDB.characters[currentCharacter];
    }

}
