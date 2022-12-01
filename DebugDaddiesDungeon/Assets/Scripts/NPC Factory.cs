using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Script is a Factory for all of the NPCs. This will Instantiate all of the NPCs, and you will be able to pass a Transform
/// to each of the Gameobjects while instantiating, to spawn it in the spot wanted in the world
/// 
/// 
/// </summary>

public class NPCFactory : MonoBehaviour
{


    public GameObject Type1NPC; // GRUNT
    public GameObject Type2NPC; // RANGED
    //public GameObject Type3NPC; // BRUTE
    //public GameObject Type4NPC; // TBD
    //public GameObject Type5NPC; // BOSS

    public void SpawnType1NPC(Transform t_transform) // GRUNT
    {
        // This currently defaults to original Prefab location (should be 0,0,0)
        Instantiate(Type1NPC, t_transform); // t_transform is passed in by the world enemy Spawner
    }
    public void SpawnType2NPC(Transform t_transform) // RANGED
    {
        Instantiate(Type2NPC, t_transform); // t_transform is passed in by the world enemy Spawner
    }
}
