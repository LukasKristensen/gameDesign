using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class trashSpawn : MonoBehaviour
{
    public int maxTrash = 5;
    public GameObject prefabTrash;
    public GameObject prefabAttackingTrash;

    public float nextSpawn = 0.0f;
    public float intervalSpawn = 1.0f;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            generateTrashpile();
            nextSpawn += intervalSpawn;
        }

        /*foreach (Transform trashPile in thisGame.transform)
        {
            if (trashPile != null)
            {
                trashPile.transform.position += new Vector3(0.01f, 0, 0);
            }
        }*/
    }

    void generateTrashpile()
    {
        if ((gameObject.transform).childCount >= maxTrash)
        {
            GameObject enemyToSpawn = Instantiate(prefabAttackingTrash, new Vector3(0, 1, 0), Quaternion.identity);
            enemyToSpawn.transform.SetParent(gameObject.transform);
        }

        else
        {
            float x = UnityEngine.Random.Range(-2, 2);
            float y = UnityEngine.Random.Range(-2, 2);

            GameObject newTrashPile = Instantiate(prefabTrash, new Vector3(x, 0.5f, y), Quaternion.identity);
            newTrashPile.transform.parent = gameObject.transform;
        }
    }
}
