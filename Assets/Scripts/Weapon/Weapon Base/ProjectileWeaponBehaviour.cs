using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    protected Vector3 direction;
    public float destroyAfterSeconds;
    protected bool freezeDirection = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (dir.x < 0 && dir.y== 0) // left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        } 
        else if (dir.x == 0 && dir.y < 0) // down
        {
            scale.y = scale.y * -1;
        }
        else if (dir.x == 0 && dir.y > 0) // up
        {
            scale.x = scale.x * -1;
        } else if (dir.x > 0 && dir.y > 0) // right up
        {
            rotation.z = 0f;
        }
        else if (dir.x > 0 && dir.y < 0) // right down
        {
            rotation.z = -90f;
        }
        else if (dir.x < 0 && dir.y > 0) // right up
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -90f;
        }
        else if (dir.x < 0 && dir.y < 0) // right up
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }

}