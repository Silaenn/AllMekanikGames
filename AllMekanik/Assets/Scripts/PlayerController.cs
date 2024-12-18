using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float movementSpeed = 3f; 
   public float movementSpeedRun = 5f; 
   private LevelSystem levelSystem;
   public Rigidbody2D rb;
   public GameObject bulletPrefab;
   public Vector2 facingDirection;
   public Transform firepoint;
   Vector2 movement;

   private void Start() {
      levelSystem = GetComponent<LevelSystem>();
   }


   private void Update() {
      Movement();
      if(levelSystem.attack && levelSystem.canShoot){
         Shoot();
         levelSystem.canShoot = false;
      } 

      if(!levelSystem.attack){
         levelSystem.canShoot = true;  
      }
   }

   void Movement(){
     movement.x = Input.GetAxisRaw("Horizontal");
     movement.y = Input.GetAxisRaw("Vertical");

     if(movement != Vector2.zero){
      facingDirection = movement.normalized;

      if(bulletPrefab != null && firepoint != null){
         float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
     }
   }
   }

   void Shoot(){
      if(bulletPrefab != null && firepoint != null){
         float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
         firepoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

         Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
   }

   void FixedUpdate()
   {
      float speedMove = levelSystem.run ? movementSpeedRun : movementSpeed;
      rb.MovePosition(rb.position + movement * speedMove * Time.fixedDeltaTime);
   }

   private void OnTriggerEnter2D(Collider2D other) {
     if(other.CompareTag("EXP")){
        levelSystem.AddXP(50);
        Destroy(other.gameObject);
     }
   }
}
