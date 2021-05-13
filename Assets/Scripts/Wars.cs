using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Wars : MonoBehaviour
{
    [SerializeField] private int _maxHealth=30; // макс здоровье
    [SerializeField] protected float _movementSpeed= 3f; //скорость движения
    [SerializeField] protected int _damage;
    //protected Rigidbody2D _rigidbody; // компонент физики для движения
    private int _currentHealth; // текущее здоровье
    protected Transform _target; // цель
    //[SerializeField] private int _damage;

   protected virtual void Start()
    {
        _currentHealth=_maxHealth;//текущее здоровье равно максимальному
       // _rigidbody=GetComponent <Rigidbody2D>(); // получаем доступ к компоненту физики

    }

    public virtual void TakeDamage (int damage)// урон по танку, переопределим только у игрока
    {   
        _currentHealth-=damage; // текущее значение - урон

        if (_currentHealth<=0)
        {
           // Stats.Score +=_points; // после смерти танка, будем получать кол-во очков
           // _ui.UpdateScoreAndLevel(); // обновляем текс жизней
           gameObject.SetActive(false);
          //  print (_currentHealth);
        }
    }

     public void Move() // у игрока движение по клавишам, у врагов по таргету, поэтому не реализуем
     {
        transform.position=Vector3.MoveTowards(transform.position, _target.position, _movementSpeed*Time.deltaTime); // двигаемся к точке i
     }

     protected IEnumerator Hit (int _damage)
     {
       TakeDamage(_damage); 
       yield return new WaitForSeconds(5);
       StartCoroutine(Hit(_damage));
     }

}
