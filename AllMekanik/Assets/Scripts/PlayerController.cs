using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private float movementSpeed = 3f; 
   private LevelSystem levelSystem;
   public Rigidbody2D rb;
   Vector2 movement;

   private void Start() {
    levelSystem = GetComponent<LevelSystem>();
   }


   private void Update() {
    Movement();
   }

   void Movement(){
     movement.x = Input.GetAxisRaw("Horizontal");
     movement.y = Input.GetAxisRaw("Vertical");
   }

   void FixedUpdate()
   {
      rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
   }

   private void OnTriggerEnter2D(Collider2D other) {
     if(other.CompareTag("EXP")){
        levelSystem.AddXP(50);
        Destroy(other.gameObject);
     }
   }
}
