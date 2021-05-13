using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Wars
{
    //[SerializeField] private float _healthEnemy;
    //[SerializeField] private float _currenthealth;
    //[SerializeField] private float _damage;+
    private GameObject _tower;

    protected override void Start()
    {  
        base.Start();
       _tower=GameObject.Find ("Tower");
       _target=_tower.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    private void OnCollisionEnter (Collision other) 
    {  
        _movementSpeed= 0f; 
        
       //if (other.gameObject.tag=="Enemy") 
        if  (other.gameObject.GetComponent<Wars>() !=null)
            {
                StartCoroutine(Hit(_damage));
               // other.gameObject.GetComponent<Wars>().TakeDamage(_damage);

            } 
       _movementSpeed= 2f;
           
       /* if  (other.gameObject.GetComponent<Tower>())
              
             other.gameObject.GetComponent<Tower>().TakeDamage(_damage);
              
           //gameObject.SetActive(false);
           */
    }

     private void OnCollisionExit(Collision other) 
    {
       //if (other.gameObject.tag=="Enemy") 
      //  if  (other.gameObject.GetComponent<Wars>() ==null )
      // {   
        

           _movementSpeed= 2f; 
           //gameObject.SetActive(false);
      // }
     
    }

    /*
    public void TakeDamage (int damage)
    {
     _currenthealth-=damage;
    }
    */
}
