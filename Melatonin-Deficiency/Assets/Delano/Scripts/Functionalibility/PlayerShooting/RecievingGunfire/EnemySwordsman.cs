using Unity.VisualScripting;
using UnityEngine;

public class EnemySwordsman : MonoBehaviour
{

    public float health;

    private void Update()
    {
        if (health <= 0f)
        {
            print("object destroyed");
            Destroy(gameObject);
        }
    }

    public void TakeDMG(float ammount)
    {
        health -= ammount; //yuh
    }

}
