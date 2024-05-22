using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) {
            logic.addScore(1);
        }
    }
}
