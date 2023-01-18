using UnityEngine;
using System.Collections;
public class PlayerConroller : MonoBehaviour
{

    public Transform groundCheck;
    public LayerMask groundLayer, waterLayer;
    public Animator animator;
    public ParticleSystem suction, hearts;
    public float playerSpeed = 10;
    public float jumpForce = 3;
    public float gravity = -9.8f;
    private AudioManager myAudioManger;
    private CharacterController controller;
    private bool allowDoubleJump = true;
    private Vector3 direction;
    private RaycastHit hit;
    private float hitDelay = 0.4f;
    private float jumpDistance = 2.0f;
    private bool isDrowned;
    public bool freeze;
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        myAudioManger = FindObjectOfType<AudioManager>();
        isDrowned = false;
        freeze = false;
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(hInput * playerSpeed));
        direction.x = hInput * playerSpeed;
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        animator.SetBool("isGrounded", isGrounded);
        if (isGrounded)
        {
            allowDoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
            }
        }
        else
        {
            if (allowDoubleJump && Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
                animator.SetTrigger("flip");
                allowDoubleJump = false;
            }
            if (!isDrowned) direction.y += gravity * Time.deltaTime;

        }
        if (hInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(0, 0, hInput));//-ve hinput rotate 180 in z direction where our model was initially facing
            transform.rotation = newRotation;
        }
        if (!freeze) controller.Move(direction * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        animator.SetTrigger("fire");
        suction.Play();
        hearts.Play();
        myAudioManger.PlayDelayed("Fire", hitDelay);

        if (Physics.Raycast(transform.position, transform.right, out hit))
        {
            if (hit.transform.tag == "enemy")
            {
                Invoke("HitEffect", hitDelay + 0.4f);
            }
        }
    }
    private void HitEffect()
    {
        hit.collider.gameObject.GetComponent<EnemyDamage>().TakeHit();//enemy is taking hit from fire

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Beach")
        {
            isDrowned = true; //stop gravity effect 
        }
        if (other.tag == "enemy")
        {
            if (Vector3.Angle(transform.right, other.transform.forward) > 90)// player (root) right is kirby mesh forward. generally 180 facing each other
                controller.Move(transform.right * -jumpDistance); //-ve dir push backward. 
            else
                controller.Move(transform.right * jumpDistance); // hit from behind push forward

        }

    }
}
