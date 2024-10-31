using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PuzzleBlockScriptableObject", menuName = "Scriptable Object PuzzleBlock/Create Puzzle Block SO")]
public class PuzzleBlockScriptableObject : ScriptableObject
{
    public string Description;

    // still need working for what variables needs and where to connect 


        //Creates PuzzleBlock list  (you can add different ready made SO PuzzleBlocks to the SO if you want to) 
     public List<PuzzleBlockScriptableObject> PuzzleBlocks = new List<PuzzleBlockScriptableObject>();

}
