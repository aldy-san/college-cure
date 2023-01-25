using UnityEngine;
public interface ICollectible 
{
    Transform transform {get;}
    void Collect();
    void Move(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, 6f * Time.deltaTime);
    }
}
