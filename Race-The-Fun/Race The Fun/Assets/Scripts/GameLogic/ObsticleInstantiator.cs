using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObsticleInstantiator : MonoBehaviour
{
    [SerializeField]
    private GameObject m_FirstObsticle;

    [SerializeField]
    private GameObject m_SecondObsticle;

    [SerializeField]
    private GameObject m_ThirdObsticle;

    [SerializeField]
    private GameObject m_ForthObsticle;

    public List<GameObject> m_obsticles = new List<GameObject>();

    private float m_obsticleSpeed;
    private float m_obsticleTimer;

    // Start is called before the first frame update
    void Start()
    {
        m_obsticleSpeed = 60.0f;
        m_obsticleTimer = 3.0f;
        
        m_obsticles.Add(m_FirstObsticle);
        m_obsticles.Add(m_SecondObsticle);
        m_obsticles.Add(m_ThirdObsticle);
        m_obsticles.Add(m_ForthObsticle);

        StartCoroutine(InstantiateObsticleTimer(m_obsticleTimer));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }

    private IEnumerator InstantiateObsticleTimer(float i_WaitForTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(i_WaitForTime);
            
            var whichObsticleGenerator = new System.Random();
            int obsticleChoice = whichObsticleGenerator.Next(m_obsticles.Count);
            GameObject instantiatedObsticle = Instantiate(m_obsticles[obsticleChoice], new Vector3(0,0,200.0f), Quaternion.identity);
            instantiatedObsticle.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.back * m_obsticleSpeed);
            Destroy(instantiatedObsticle, 10.0f);
        }
    }
    
    public List<GameObject> GetObsticleList()
    {
        return m_obsticles;
    }

    private void AdvanceLevel()
    {
        m_obsticleSpeed += 10.0f;
        m_obsticleTimer -= 0.5f;
    }
}