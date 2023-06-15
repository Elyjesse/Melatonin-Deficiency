using UnityEngine;

public class Gun : MonoBehaviour
{
    //gun properties

    public float damageDealing, range;
    public bool fullAuto;

    //keyBinds

    public KeyCode firing = KeyCode.Mouse0;

    //object refrences

    public RaycastHit rHit;
    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        ShootingImplied();
    }

    void ShootingImplied()
    {
        if(fullAuto == true)
        {
            if (Input.GetKey(firing))
            {
                print("Full Auto Firing");
                Shooting();
            }
        }
        else //this makes possible for both singleshot and burst shot
        {
            if (Input.GetKeyDown(firing))
            {
                print("Single Shot Firing");
                Shooting();
            }
        }

        void Shooting()
        {
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rHit, range))
            {
                Debug.Log(rHit.transform.name);

                EnemySwordsman enemies = rHit.transform.GetComponent<EnemySwordsman>();

                if(enemies != null)
                {
                    enemies.TakeDMG(damageDealing);
                }
            }
        }

    }
}
