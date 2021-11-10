using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float forcePower = 20f;

    private Rigidbody rbItem;


    void Start()
    {
        rbItem = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Debug.Log(other.gameObject.CompareTag("PlayerHand"));
        if (other.gameObject.CompareTag("PlayerHand"))
        {
            //APLICAR FUERZA
            //rbItem.AddForce(Vector3.left * 100f);
            //rbItem.AddForce(Vector3.forward * forcePower);
            rbItem.AddRelativeForce(Vector3.forward * forcePower, ForceMode.Acceleration);
            rbItem.AddTorque(Vector3.forward * forcePower);

        }
    }
    */

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Ground"))
        {
            rbItem.AddForce(Vector3.up * 4f, ForceMode.Impulse);
        }
        //SE RECOMIENDA SWITCH 
        if (collision.contacts[0].otherCollider.gameObject.CompareTag("PlayerHand"))
        {
            //APLICAR FUERZA
            //rbItem.AddForce(Vector3.left * 100f);
            //rbItem.AddForce(Vector3.forward * forcePower);
            //rbItem.AddRelativeForce(Vector3.forward * forcePower, ForceMode.Acceleration);
            //rbItem.AddTorque(Vector3.forward * forcePower);
            GameManager.score += 1;
            GameManager.instance.addScore();
            Debug.Log(GameManager.GetScore());
            Debug.Log(GameManager.score);
            Destroy(gameObject);
        }
    }
}
