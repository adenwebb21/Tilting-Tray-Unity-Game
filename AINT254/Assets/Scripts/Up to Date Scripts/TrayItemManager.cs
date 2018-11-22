using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayItemManager : MonoBehaviour
{
    [SerializeField]
    private GameObject spherePrefab, cubePrefab, cylinderPrefab;

    [SerializeField]
    private Transform objectSpawn;

    private GameObject[] selectedTrayItems;

    private int index = 0;
    private bool isSpawning;
    private float timestamp;
    private float timeBetweenObjectSpawns = 0.5f;

    private void Start()
    {
        ResetTrayItems();
    }

    private void ChooseTrayItems()
    {
        int selection;

        for (int i = 0; i < selectedTrayItems.Length; i++)
        {
            selection = Random.Range(0, 3);

            switch (selection)
            {
                case 0:
                    selectedTrayItems[i] = spherePrefab;
                    break;
                case 1:
                    selectedTrayItems[i] = cubePrefab;
                    break;
                case 2:
                    selectedTrayItems[i] = cylinderPrefab;
                    break;
                default:
                    break;
            }
        }
    }

    public void ResetTrayItems()
    {
        GameObject[] currentlyInScene = GameObject.FindGameObjectsWithTag("TrayItems");

        foreach (GameObject trayItem in currentlyInScene)
        {
            Destroy(trayItem);
        }

        selectedTrayItems = new GameObject[Random.Range(2, 6)];

        ChooseTrayItems();

        isSpawning = true;
        timestamp = timeBetweenObjectSpawns;
        index = 0;

        GetComponent<ScoreKeeper>().SetScore(selectedTrayItems.Length);
    }

    private void InstantiateItem()
    {
        Instantiate(selectedTrayItems[index], objectSpawn.transform.position, new Quaternion(0, 0, 0, 0));
    }

    private void Update()
    {
        if(isSpawning)
        {
            timestamp -= Time.deltaTime;

            if (timestamp <= 0 && index <= selectedTrayItems.Length - 1)
            {
                InstantiateItem();
                timestamp = timeBetweenObjectSpawns;
                index++;
            }
        }  
    }
}
