using Game.Logic;
using UnityEngine;

public class Asteroid : Enemy
{
    [SerializeField] protected GameObject ChildTemplate;
    [SerializeField] protected int NumberSpawnChildren;

    public override void Die()
    {
        gameObject.SetActive(false);
        SpawnChildren();
    }

    public void SpawnChildren() 
    {
        CreateChildren(NumberSpawnChildren, ChildTemplate);
    }

    private void CreateChildren(int numberSpawnChildren, GameObject templateChildren)
    {
        for (int i = 0; i < numberSpawnChildren; i++)
        {
            Instantiate(templateChildren, transform.position, transform.rotation);
        }
    }

}
