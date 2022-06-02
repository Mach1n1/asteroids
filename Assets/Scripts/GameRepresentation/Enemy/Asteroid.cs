using Game.Logic;
using UnityEngine;

public class Asteroid : Enemy
{
    [SerializeField] protected GameObject childTemplate;
    [SerializeField] protected int numberSpawnChildren;

    public override void Die()
    {
        gameObject.SetActive(false);
        AddScore();
        SpawnChildren();
    }

    public void SpawnChildren() 
    {
        instantiateChildren(numberSpawnChildren, childTemplate);
    }

    private void instantiateChildren(int numberSpawnChildren, GameObject childTemplate)
    {
        for (int i = 0; i < numberSpawnChildren; i++)
        {
            Instantiate(childTemplate, transform.position, transform.rotation);
        }
    }
}
