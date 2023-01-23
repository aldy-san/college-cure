using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]
   public class Drops
    {
        public string name;
        public GameObject itemPrefab;
        public float dropRate;
    }
    bool isQuitting = false;
    public List<Drops> drops;

    void OnDestroy()
    {
        float randonNumber = UnityEngine.Random.Range(0f, 100f);
        List<Drops> possibleDrops = new List<Drops>();
        foreach (Drops drop in drops)
        {
            if (randonNumber <= drop.dropRate)
            {
                possibleDrops.Add(drop);
            }
        }
        if(possibleDrops.Count > 0)
        {
            Drops drop = possibleDrops[UnityEngine.Random.Range(0, possibleDrops.Count)];
            if (!isQuitting)
            {
                Instantiate(drop.itemPrefab, transform.position, Quaternion.identity);
            }
        }
    }
    void OnApplicationQuit()
    {
        isQuitting = true;
    }
}
