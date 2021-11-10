using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    [SerializeField] private Vector3 cicleVelocity = new Vector3(1f, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = cicleVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //ROTATE ARROUND
        transform.RotateAround(Vector3.zero, Vector3.right  , 30f * Time.deltaTime);
        transform.LookAt(Vector3.zero);
        */
    }
}
