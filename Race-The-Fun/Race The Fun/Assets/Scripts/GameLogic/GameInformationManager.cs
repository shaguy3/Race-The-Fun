using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameInformationManager : MonoBehaviour
{

    private int m_AmountOfFuel = 100;
    private float m_FuelReductionTimer = 1.0f;
    private int m_Score = 0;

    [SerializeField]
    private Text m_UIFuelText;

    [SerializeField]
    private Text m_UIScoreText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReduceFuel(m_FuelReductionTimer));
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
            IncreaseScore(1);
        }
    }

    private IEnumerator ReduceFuel(float i_WaitForTime)
    {
        while (m_AmountOfFuel > 0)
        {
            yield return new WaitForSeconds(i_WaitForTime);

            m_AmountOfFuel -= 1;

            m_UIFuelText.text = $"Fuel: {m_AmountOfFuel}";
        }

        // TODO: handle out of fuel.
    }

    private void IncreaseScore(int i_AmountToIncrease)
    {
        m_Score += i_AmountToIncrease;
        m_UIScoreText.text = $"Score: {m_Score}";
    }
}
