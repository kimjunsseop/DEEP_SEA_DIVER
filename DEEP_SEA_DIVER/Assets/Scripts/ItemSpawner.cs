using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Mono.Cecil.Cil;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner instance;
    public Transform[] spawnPoints;
    public Player player;
    public GameObject[] items;
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
        List<int> r = new List<int>();
        for(int i = 0; i < items.Length; i++)
        {
            r.Add(i);
        }
        for(int i = 0; i < items.Length; i++)
        {
            int temp = r[i];
            int randomIndex = Random.Range(i, r.Count);
            r[i] = r[randomIndex];
            r[randomIndex] = temp;
        }
        for(int i = 0; i < player.inventorySize; i++)
        {
            Instantiate(items[r[i]], spawnPoints[rand[i]].position, Quaternion.identity);
            
            //UIManager.instance.setImage(item, i);
            UIManager.instance.itemss.Add(i, items[r[i]]);
        }
    }

    void Update()
    {
        
    }
}
