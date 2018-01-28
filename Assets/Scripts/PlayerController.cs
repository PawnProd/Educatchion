using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public PlayerMovement pM;

    public DetectionBehavior detect;

    public Animator animator;

    public AudioSource sourceAttack;

    public AudioSource sourceProjectile;

    public GameObject projectilPrefab;

    public Transform spawnProjectil;

    public ATHManager ath;

    public int ammo = 4;

    private void Start()
    {
        pM = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        
        if(Input.GetAxis("Horizontal") > 0) // RIGHT
        {
            pM.MoveRight();
            animator.SetBool("isWalking", true);
        }
        else if(Input.GetAxis("Horizontal") < 0) // LEFT
        {
            pM.MoveLeft();
            animator.SetBool("isWalking", true);
        }
        else if(Input.GetAxis("Vertical") > 0) // UP
        {
            pM.MoveUp();
            animator.SetBool("isWalking", true);
        }
        else if(Input.GetAxis("Vertical") < 0) // DOWN
        {
            pM.MoveDown();
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        
        if(Input.GetMouseButtonDown(0) && detect.student != null) // HIT a student
        {
            detect.student.SendMessage("getHit", SendMessageOptions.DontRequireReceiver);
            animator.SetBool("isAttack", true);
            sourceAttack.Play();
        }

        if (Input.GetMouseButtonDown(1) && ammo > 0)
        {
            --ammo;
            sourceProjectile.Play();
            ath.UpdateAmmo(ammo);
            GameObject projectile = Instantiate(projectilPrefab, spawnProjectil.position, Quaternion.identity, transform.parent);
            GameObject position = new GameObject("ProjectilePosition");

            

            position.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.transform.position = new Vector3(position.transform.position.x, position.transform.position.y, 0);
            projectile.GetComponent<Projectile>().student = position;

            RaycastHit2D hit;

            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.tag == "Student" && !hit.collider.GetComponent<StudentScript>().isListening)
            {
                projectile.GetComponent<Projectile>().student = hit.collider.gameObject;
            }
        }

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Atk_Prof"))
        {
            animator.SetBool("isAttack", false);
        }
    }
}
