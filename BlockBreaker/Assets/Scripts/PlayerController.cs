using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Define Variables
    [SerializeField] int wolrdUnitScreenSize = 16;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMousePosInUnits = (Input.mousePosition.x / Screen.width * wolrdUnitScreenSize);
        Vector3 paddlePos = new Vector3(xMousePosInUnits, transform.position.y, transform.position.z);
        transform.position = paddlePos;
    }
}
