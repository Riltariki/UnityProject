using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscilator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector;

    // todo remove from inspector later
    [Range(0, 3)]    [SerializeField]  float movementFactor; // 0 for not moved, 1 for fully moved

    Vector3 startingPos;
    Vector3 endPos;
    bool again = false;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        endPos = transform.position + movementVector;
    }

    // Update is called once per frame
    void Update()
    {
        if (again== false)
        {
            transform.position += movementVector * movementFactor * Time.deltaTime;
            if (transform.position == endPos) again = true;
        }
        else
        {
            transform.position -= movementVector * movementFactor * Time.deltaTime;
            if (transform.position == startingPos) again = false;
        }

    }
}
