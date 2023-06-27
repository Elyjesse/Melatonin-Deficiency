using Unity.VisualScripting;
using UnityEngine;

public class EnemySwordsman : MonoBehaviour
{
    public UiProps userInterface;
    public float health;

    private void Update()
    {
        if (health <= 0f)
        {
            userInterface.navigator.enabled = false;
            print("object destroyed");
            Destroy(gameObject);
        }
    }

    public void TakeDMG(float ammount)
    {
        health -= ammount;
    }

    public void GiveDMG()
    {

    }
}
