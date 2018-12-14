using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 
 * TODO: init gameobjects, attach random string, 
 * move from left to right, if at right when still letters left - level-- 
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
