using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
    public List<GameObject> contructionSites;
    public void RevealMenus()
    {
        Debug.Log("Revealing");
        foreach (GameObject site in contructionSites)
        {
            site.SetActive(true);
        }
    }

    public void HideMenus()
    {
        Debug.Log("Hiding");
        foreach (GameObject site in contructionSites)
        {
            site.SetActive(false);
        }
    }
    public void AddSite(GameObject site)
    {
        if (!contructionSites.Contains(site))
        {
            contructionSites.Add(site);
            Debug.Log("added");
        }
        
    }

    public void RemoveSite(GameObject site)
    {
        if (contructionSites.Contains(site))
        {
            contructionSites.Remove(site);
            Debug.Log("removed");
        }
    }
}
