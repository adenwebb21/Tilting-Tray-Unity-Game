using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayItemManager : MonoBehaviour {

    public GameObject spherePrefab, cubePrefab, cylinderPrefab;
    public Transform objectSpawn;
    private Vector3[] startingOptions;
    private GameObject[] selectedTrayItems;

    private void Start()
    {
        selectedTrayItems = new GameObject[Random.Range(2, 6)];

        startingOptions = new Vector3[5];

        //startingOptions[0] = new Vector3(-0.36f, 2f, -28.8f);
        //startingOptions[1] = new Vector3(0.103f, 2f, -28.8f);
        //startingOptions[2] = new Vector3(-0.537f, 2f, -28.54f);
        //startingOptions[3] = new Vector3(0.464f, 2f, -28.971f);
        //startingOptions[4] = new Vector3(-0.031f, 2f, -28.842f);


        ResetTrayItems();
    }

    private void ChooseTrayItems()
    {
        int selection;

        for(int i = 0; i < selectedTrayItems.Length; i++)
        {
            selection = Random.Range(0, 3);

            switch(selection)
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
        foreach(GameObject trayItem in currentlyInScene)
        {
            Destroy(trayItem);
        }

        selectedTrayItems = new GameObject[Random.Range(2, 6)];

        ChooseTrayItems();
        
        //for(int i = 0; i < selectedTrayItems.Length; i++)
        //{
        //    Instantiate(selectedTrayItems[i], startingOptions[Random.Range(0, 5)], new Quaternion(0, 0, 0, 0));
            
        //}

        Instantiate(cubePrefab, objectSpawn.transform.position, new Quaternion(0, 0, 0, 0));

        GetComponent<ScoreKeeper>().SetScore(selectedTrayItems.Length);
    }
}
