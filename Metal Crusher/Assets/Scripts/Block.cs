using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    // Configuration Parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX; // prefab particles
    [SerializeField] int maxHits;     // keep track of the block's current state & how many hits the block can take


    // cached reference.
    Level level;

    [SerializeField] // State Variables
    int timesHit; // ONLY SERIALIZED FOR DEBUG PURPOSES
 

    //Play an audio source right next to the camera 
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>(); // search for a particular type of object that is Level
        if (tag == "Breakable")
        {
            level.CountBlocks(); // Goes through every block and tallies up to the total score
        }
    }

    // method to take care of updating the block's condition
    private void HandleHit()
    {
        // we want something to happen
        timesHit++; // add a total number of hit

        if (timesHit >= maxHits) // if the amount of times hit is greater than the maximum hit
        {
            DestroyBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // nested if statement
        if (tag == "Breakable") // whenever the ball comes into contact with the block, it'll trigger the general collision effect
        {
            HandleHit();

        }

    }

    private void DestroyBlock()
    {
        PlayBlockDestroyedSFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparkleVFX();
    }

    private void PlayBlockDestroyedSFX()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparkleVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

   
}
