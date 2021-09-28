using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    private GameObject topBG;

    [SerializeField]
    private GameObject botBG;
    private float size;

    private Vector3 topTargetPos = new Vector3();
    private Vector3 botTargetPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        size = topBG.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        topBG.transform.position = SetPos(topTargetPos,topBG.transform.position.x, topBG.transform.position.y + 0.3f, topBG.transform.position.z); 
        botBG.transform.position = SetPos(topTargetPos,botBG.transform.position.x, botBG.transform.position.y + 0.3f, botBG.transform.position.z); 

        if(transform.position.y < botBG.transform.position.y)
        {
            topBG.transform.position = SetPos(topTargetPos,topBG.transform.position.x, botBG.transform.position.y - size*10, topBG.transform.position.z);
            Vector3 tmpPos = botTargetPos;
            botTargetPos = topTargetPos;
            topTargetPos = tmpPos;

            GameObject tmpObj = botBG;
            botBG = topBG;
            topBG = tmpObj;
        }
    }
    

    private Vector3 SetPos(Vector3 pos,float x, float y, float z)
    {
        pos.x = x;
        pos.y = y;
        pos.z = z;
        return pos;
    }

}
