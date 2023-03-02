using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    public Renderer SpriteRenderer { get; private set; }
    public SpriteRenderer Renderer { get; private set; }

    void Start()
    {
        //find the GameObject game object
        GameObject foundObject = GameObject.FindGameObjectWithTag("GameController");

        //if the GameController has been found
        if (foundObject != null)
        {
            //get the gameManager script
            GameManager manager = foundObject.GetComponent<GameManager>();
            //get the sprite renderer of the player
            SpriteRenderer = Renderer = GetComponent<SpriteRenderer>();

            //set the sprite of the player to be sprite stored in the game manager
            //remember this is the sprite we picked in the carSelect scene
            Renderer.sprite = manager.selectedCar;
        }
    }

    void Update()
    {
        
    }
}
