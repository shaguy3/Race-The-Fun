using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameInformationManager : MonoBehaviour
{

    private int m_AmountOfFuel = 100;
    private int m_Score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindGameObjectsWithTag("Obsticle").Contains(other.gameObject))
        {
            Debug.Log("Obsticle collision detected");
            // TODO: handle obsticle collision.
        }
        else if (GameObject.FindGameObjectsWithTag("Fuel").Contains(other.gameObject))
        {
            Debug.Log("Fuel powerup collision detected");
            // TODO: handle powerup collision.
        }
        else if (GameObject.FindGameObjectsWithTag("Pass Collider").Contains(other.gameObject))
        {
            Debug.Log("The player just crossed an obsticle.");
            // TODO: handle obsticle passing.
        }
    }
}
