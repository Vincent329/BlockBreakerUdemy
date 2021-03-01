using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Level : MonoBehaviour
{
    // parameters
    [SerializeField] int breakableBlocks; // debugging purposes

    // cache reference
    SceneLoader sceneLoader; // in this case, the level acts as our scene loader

    // Start is called before the first frame update
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Keeps track of how many breakable blocks there are within the level
    // Method is called in the Blocks.cs script
    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.loadNextScene();
        }
    }
}
