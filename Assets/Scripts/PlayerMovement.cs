using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 400; //the speed of the car
    float currentSpeed;  //the speed of car that modifiers will be applied to

    public float rotationSpeed = 2; //speed which the car will turn at
    float h, v;

    Rigidbody2D body;

    float modifierLastsFor = 0;  //how long a modifier will last for
    bool modifierActive = true;  //indicates if a modifier is active
    float elapsed = 0;  //recorda time passed

    public string HorizontalInputName = "Horizontal"; //requireds two player
    public string VerticalInputName = "Vertical"; //required two players


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentSpeed = movementSpeed;
    }

    void Update()
    {
        //modifiers have a length that they are applied for
        if (modifierActive)
        {
            //when a modifier is active we need to track how much time is passing
            elapsed += Time.deltaTime;

            //if the time passed is greater than the modifiers length
            if (elapsed >= modifierLastsFor)
            {
                modifierActive = false;  //turn of the modifier
                currentSpeed = movementSpeed;  //reset our speed to the original
                elapsed = 0;  //reset the timer
            }
        }

        //get the input from the user
        h = Input.GetAxisRaw(HorizontalInputName);
        v = Input.GetAxisRaw(VerticalInputName);

        //use the horizontal input to rotate the player
        // note the negative h value to make rotate in the correct direction
        //try it with the -symbol to see the effect
        transform.Rotate(0, 0, -h * rotationSpeed);
    }

    private void FixedUpdate()
    {
        //transform.up is the forward direction of the game object in 2D
        //move the object in the forward direction by the current speed
        body.velocity = transform.up * v * currentSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we hit an object tagged as modifier
        if (collision.gameObject.CompareTag("Modifier"))
        {
            //get the speedModifier component from the object we hit
            SpeedModifier mod = collision.gameObject.GetComponent<SpeedModifier>();

            //set the current speed to be the original speed multipied by the modifier
            //example (currentSpeed = 400 * 0.5f;), will half the speed of the player
            currentSpeed = movementSpeed * mod.Modifier;

            //copy the data from the modifier into our own local variables
            //these are used in the update
            modifierLastsFor = mod.LastFor;
            modifierActive = true;
            elapsed = 0;
        }
    }
}
