using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 
 * TODO: if at right when still letters left - level-- 
 * if string emptied - add new object + a little fast (gamemanager) 
 * 
 * */

public enum CoreLoopPhase
{
    PREWARM,
    CORELOOP,
    WON,
    LOST
}

public class GameCoreLoop : MonoBehaviour
{
    public GameObject ToyPrefab;
    public StringManager stringManager;

    public float SpawnIntervall;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        CreateToy();
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > SpawnIntervall)
        {
            timer = 0.0f;

            CreateToy();
        }
    }

    public void CreateToy(int type = 0)
    {
        GameObject instance = Instantiate(ToyPrefab, Vector3.zero, Quaternion.identity);
        TextMesh display = instance.GetComponentInChildren<TextMesh>();
        stringManager.AddToyString(display);
    }
}
