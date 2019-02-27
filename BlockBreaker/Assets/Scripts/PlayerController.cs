using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Define Variables
    [SerializeField] int wolrdUnitScreenSize = 16;
    [SerializeField] float paddlePosXMin = 1f;
    [SerializeField] float paddlePosXMax = 15f;

    // Update is called once per frame
    void Update()
    {
        PaddleControl();
    }

    // Moves paddle based on location of the mouse
    private void PaddleControl()
    {
        float xMousePosInUnits = (Input.mousePosition.x / Screen.width * wolrdUnitScreenSize);
        Vector3 paddlePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        paddlePos.x = Mathf.Clamp(xMousePosInUnits, paddlePosXMin, paddlePosXMax);
        transform.position = paddlePos;
    }
}
