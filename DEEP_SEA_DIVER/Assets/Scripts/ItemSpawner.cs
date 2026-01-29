using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner instance;
    public Transform[] spawnPoints;
    public Player player;
    public GameObject item;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        List<int> rand = new List<int>();
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            rand.Add(i);
        }
        for(int i = 0; i < rand.Count; i++)
        {
            int temp = rand[i];
            int randomIndex = Random.Range(i,rand.Count);
            rand[i] = rand[randomIndex];
            rand[randomIndex] = temp;
        }
        for(int i = 0; i < player.inventorySize; i++)
        {
            Instantiate(item, spawnPoints[rand[i]].position, Quaternion.identity);
            
            UIManager.instance.setImage(item, i);
        }
    }

    void Update()
    {
        
    }
}
