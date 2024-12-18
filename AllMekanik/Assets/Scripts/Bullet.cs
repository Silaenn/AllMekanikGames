using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    private float lifetime = 2f;
    private LevelSystem levelSystem;
    void Start()
    {
        levelSystem = GetComponent<LevelSystem>();
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("EXP")){
            levelSystem.AddXP(50);
            Destroy(other.gameObject);
        }
    }
}
