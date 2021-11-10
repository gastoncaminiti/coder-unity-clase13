using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int lifePlayer = 3;
    [SerializeField] private float cameraAxisX = -90f;
    [SerializeField] private float speedPlayer = 3f;
    [SerializeField] private float speedTurn= 7f;

    [SerializeField] private Animator animPlayer;
    [SerializeField] private AudioClip punchSound;
    [SerializeField] private AudioClip walkSound;

    private AudioSource audioPlayer;
    private Rigidbody rbPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        animPlayer.SetBool("isRun", false);
        audioPlayer = GetComponent<AudioSource>();
        rbPlayer    = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioPlayer.PlayOneShot(punchSound, 1f);
            animPlayer.SetBool("isPunch", true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            animPlayer.SetBool("isPunch", false);
        }
    }

    private void FixedUpdate()
    {
        Move();
        RotatePlayer();
    }

    private void Move()
    {
        float ejeHorizontal = Input.GetAxis("Horizontal");
        float ejeVertical   = Input.GetAxis("Vertical");

        if (ejeHorizontal != 0 || ejeVertical != 0) {
            animPlayer.SetBool("isRun", true);
            rbPlayer.AddRelativeForce(Vector3.forward * speedPlayer * ejeVertical, ForceMode.Force);
            rbPlayer.AddRelativeForce(Vector3.right  * speedPlayer * ejeHorizontal, ForceMode.Force);
            if (!audioPlayer.isPlaying)
            {
                audioPlayer.PlayOneShot(walkSound, 0.5f);
            }
        }
        else
        {
            animPlayer.SetBool("isRun", false);
        }
    }
    private void RotatePlayer()
    {
        if(Input.GetAxis("Mouse X") != 0) { 
            cameraAxisX += Input.GetAxis("Mouse X");
            Quaternion angulo   = Quaternion.Euler(0, cameraAxisX * speedTurn, 0);
            transform.rotation = angulo;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lifePlayer--;
            Destroy(collision.gameObject);
            if(lifePlayer < 0)
            {
                Debug.Log("GAME OVER");
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Generator"))
        {
            other.gameObject.GetComponent<GeneratorController>().setNewColor(Color.black);
        }
    }
}
