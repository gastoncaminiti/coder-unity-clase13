using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject shootOrigen;
    [SerializeField] private float distanceRay = 10f;
    [SerializeField] private int shootCooldown = 2;

    [SerializeField] private float timerShoot = 0;
    [SerializeField] private GameObject bulletPrefab;

    private bool  canShoot = true;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            RaycastCannon();
        }
        else
        {
           timerShoot += Time.deltaTime;
        }

     
        if(timerShoot > shootCooldown)
        {
            canShoot = true;
        }


    }


    private void RaycastCannon()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(shootOrigen.transform.position, shootOrigen.transform.TransformDirection(Vector3.forward), out hit, distanceRay))
        {
            if(hit.transform.tag == "Player")
            {
                Debug.Log("COLISION PLAYER");
                canShoot   = false;
                timerShoot = 0;
                GameObject b = Instantiate(bulletPrefab, shootOrigen.transform.position, bulletPrefab.transform.rotation);
                b.GetComponent<Rigidbody>().AddForce(shootOrigen.transform.TransformDirection(Vector3.forward) * 10f, ForceMode.Impulse);
            }
        }

    }

    private void OnDrawGizmos()
    {

        if (canShoot) { 
            Gizmos.color = Color.blue;
            Vector3 direction = shootOrigen.transform.TransformDirection(Vector3.forward) * distanceRay;
            Gizmos.DrawRay(shootOrigen.transform.position, direction);
        }

    }
}
