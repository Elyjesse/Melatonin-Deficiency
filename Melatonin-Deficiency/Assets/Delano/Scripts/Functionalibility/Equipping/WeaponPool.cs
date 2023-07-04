using UnityEngine;

public class WeaponPool : MonoBehaviour
{
    public int index;
    public int selectedWeapon;
    public int pastSelectedWeapon;

    public Transform weaponPool;

    //enabling/disbling whenever gameobject is pickedUp

    //with pickitup in co-response

    private void Start()
    {
        DetectWeapon();
    }

    private void Update()
    {
        pastSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
            selectedWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollwWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }
        if(pastSelectedWeapon != selectedWeapon)
        {
            DetectWeapon();
        }

    }
    void DetectWeapon()
    {
        index = 0;
        foreach(Transform weapon in weaponPool)
        {
            if(index == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            index++;
        }
    }

    void SwitchingTeams()
    {
        print("switching teams up/down");
    }
}
