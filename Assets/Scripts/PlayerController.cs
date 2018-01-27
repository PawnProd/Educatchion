using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public PlayerMovement pM;

    public DetectionBehavior detect;

    public GameObject projectilPrefab;

    public Transform spawnProjectil;

    public ATHManager ath;

    public int ammo = 4;

    private void Start()
    {
        pM = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        
        if(Input.GetAxis("Horizontal") > 0) // RIGHT
        {
            pM.MoveRight();
        }
        else if(Input.GetAxis("Horizontal") < 0) // LEFT
        {
            pM.MoveLeft();
        }
        else if(Input.GetAxis("Vertical") > 0) // UP
        {
            pM.MoveUp();
        }
        else if(Input.GetAxis("Vertical") < 0) // DOWN
        {
            pM.MoveDown();
        }
        
        if(Input.GetMouseButtonDown(0) && detect.student != null) // HIT a student
        {
            detect.student.SendMessage("getHit", SendMessageOptions.DontRequireReceiver);
        }

        if (Input.GetMouseButtonDown(1) && ammo > 0)
        {
            --ammo;
            ath.UpdateAmmo(ammo);
            GameObject projectile = Instantiate(projectilPrefab, spawnProjectil.position, Quaternion.identity, transform.parent);
            GameObject position = new GameObject("ProjectilePosition");

            position.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.transform.position = new Vector3(position.transform.position.x, position.transform.position.y, 0);
            projectile.GetComponent<Projectile>().student = position;

            RaycastHit2D hit;

            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
<<<<<<< HEAD
            //print("Coucou");
            if (hit.collider.tag == "Student")
            {
                //print("Coucou 1");
                GameObject projectile = Instantiate(projectilPrefab, spawnProjectil.position, Quaternion.identity, transform.parent);
=======
            if (hit.collider != null && hit.collider.tag == "Student" && !hit.collider.GetComponent<StudentScript>().isListening)
            {
>>>>>>> 24526b3ddf922b392f8163c4a7f6791f6c494e74
                projectile.GetComponent<Projectile>().student = hit.collider.gameObject;
            }
        }
    }
}
