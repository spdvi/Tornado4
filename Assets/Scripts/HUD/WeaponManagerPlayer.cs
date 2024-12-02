using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManagerPlayer : MonoBehaviour
{
    private List<GameObject> weapons = new List<GameObject>();
    private List<Image> weaponImages = new List<Image>();
    private int activeWeapon;
    
    void Start()
    {
        int numWeapons = transform.childCount;
        
        for (int i = 0; i < numWeapons; i++)
        {
            weapons.Add(transform.GetChild(i).gameObject);
            for (int j = 0; j < weaponImages.Count; j++)
            {
                if (weaponImages[j].gameObject.name == transform.GetChild(i).gameObject.name)
                {
                    weaponImages[j].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                }
            }
        }
        
        activeWeapon = 0;

        for (int i = 0; i < weapons.Count; i++)
        {
            if (i != activeWeapon)
            {
                weapons[i].SetActive(false);
            }
            else
            {
                weapons[i].SetActive(true);
                for (int j = 0; j < weaponImages.Count; j++)
                {
                    if (weaponImages[j].gameObject.name == weapons[i].gameObject.name)
                    {
                        weaponImages[j].GetComponent<Image>().color = Color.red;
                    }
                }
            }
        }
    }

    public void AddWeapon(Transform weapon)
    {
        weapons.Add(weapon.gameObject);
        for (int i = 0; i < weaponImages.Count; i++)
        {
            if (weaponImages[i].gameObject.name == weapon.name)
            {
                weaponImages[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
    
    public void SelectWeapon(int weaponIndex)
    {
        activeWeapon = weaponIndex;

        for (int i = 0; i < weapons.Count; i++)
        {
            if (i != activeWeapon)
            {
                weapons[i].SetActive(false);
            }
            else
            {
                weapons[i].SetActive(true);
                for (int j = 0; j < weaponImages.Count; j++)
                {
                    if (weaponImages[j].gameObject.name == weapons[i].gameObject.name)
                    {
                        weaponImages[j].GetComponent<Image>().color = Color.red;
                    }
                }
            }
        }
    }
    
}
