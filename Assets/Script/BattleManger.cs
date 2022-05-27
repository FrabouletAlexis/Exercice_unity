using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManger : MonoBehaviour

{
    public Rigidbody2D corp;
    public Rigidbody2D enemy;
    public Ennemi ennemiScript;

    public float speed = 1f;
    public Vector2 destination;

    void Start()
    {
  
    }

    void Update()
    {
        
    }

    


    public void Eject()
    {
        corp.transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime);
        Debug.Log("pouf");
    }
}
