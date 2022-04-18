using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
    public List<GameObject> contructionSites;
    public void RevealMenus()
    {
        foreach (GameObject site in contructionSites)
        {
            site.SetActive(true);
        }
    }

    public void HideMenus()
    {
        foreach (GameObject site in contructionSites)
        {
            site.SetActive(false);
        }
    }
    public void AddSite(GameObject site)
    {
        contructionSites.Add(site);
        site.SetActive(false);
    }

    public void RemoveSite(GameObject site)
    {
        contructionSites.Remove(site);
    }
}
