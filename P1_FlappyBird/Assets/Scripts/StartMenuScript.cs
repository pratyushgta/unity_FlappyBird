using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
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

    public void OnPlayButton()
    {
        logic.isGameActive = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnQuitButton()
    {
        Application.Quit(); 
    }
}
