using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Wars
{
    //[SerializeField] private int _damage;
    //private Transform _target; // цель
    private GameObject _enemy;
    

   protected override void Start()
    {   
        base.Start();
       _enemy=GameObject.Find ("Enemy");
       _target=_enemy.GetComponent<Transform>();
      
    }

   
    void Update()
    {
         Move(); 
    }
    /*
    private void Move () // движение
    {
        transform.position=Vector3.MoveTowards(transform.position, _target.position, _movementSpeed*Time.deltaTime); // двигаемся к точке i
    }
     */
    private void OnCollisionEnter(Collision other) 
    {
       //if (other.gameObject.tag=="Enemy") 
        if  (other.gameObject.GetComponent<Wars>() !=null)
       {   
          // other.gameObject.GetComponent<Wars>().TakeDamage(_damage);
          // gameObject.SetActive(false);
           StartCoroutine(Hit(_damage));
       }
    
    }
 
}
