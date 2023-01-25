using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        transform.position = player.transform.position;
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out ICollectible collectible))
        {
            //collide
            collectible.Move(player.transform);
        }
    }
}
