using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // by deafult, the script can only communicate with object and transform
    // to make it communicate with other components, add a reference
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    [SerializeField]
    private float down_y = -17; // Limit y fall
    [SerializeField]
    private float up_y = 17; // Limit y fall

    // Start is called before the first frame update
    // runs any code as soon as the script is enabled
    // runs once
    void Start()
    {
        //gameObject.name="Bird_Player";
        // Use FindGameObjectWithTag instead of FindGameObjectsWithTag
        GameObject logicObject = GameObject.FindGameObjectWithTag("Logic");

        // Check if logicObject is not null before getting the component
        if (logicObject != null)
        {
            logic = logicObject.GetComponent<LogicScript>();
        }
        else
        {
            Debug.LogError("No GameObject with tag 'Logic' found.");
        }

        //logic.startGame();

    }

    // Update is called once per frame
    // runs constantly when the script is enabled
    // runs every line of code at every frame over and over again
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            key_space();
        }
        else if(Input.touchCount > 0 && birdIsAlive)
        {
            key_touch();
        }
       
    }

    void key_space()
    {
        myRigidbody.velocity = Vector2.up * flapStrength;
        if (transform.position.y <= down_y || transform.position.y >= up_y)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    void key_touch()
    {
        if (Input.touchCount > 0 && birdIsAlive)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                myRigidbody.velocity = Vector2.up * flapStrength;
            }
        }

        if (transform.position.y <= down_y || transform.position.y >= up_y)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
