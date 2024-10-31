using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaOfEffect : MonoBehaviour
{
    // Use Coroutines and maybe state machines?    REMEMBER ATTACKSEQUENCE

    //You can use sphere / ball for this AND maybe sphere cast if needed?

    //Also??---- The Basics of OnTriggerEnter, OnTriggerStay, & OnTriggerExit in Unity C#https://www.youtube.com/watch?v=OCsi53mwfRo

    //Create a Ball which u instantiate to location.
    // make it grow bigger and then stop.
    // make it check everything inside the area
    //apply damage and effects to GameObjects(enemies) there

    //apply graphic efffects to right points of the sequence

    //connect the effects to enemies and their possible STATES

    // you can add physics forces with effectors https://www.youtube.com/watch?v=hgUqhsAzGWs

    // ALSO THERE SHOULD BE AREA EFFECTOR 2D IN THE COMPONENTS!! https://www.youtube.com/watch?v=2LSXHtl0Mss
    // OR USE POINT EFFECTOR TO REPULSE


    // aoe AIR can use 2 different balls first one for check second 1 for growing with rigidbody and boxcollider and pushing enemies out


    //Nav Mesh Agent for stupid pathfinding? dont confuse with actual AI

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
