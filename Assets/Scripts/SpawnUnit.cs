using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SpawnUnit : MonoBehaviour
{   [SerializeField] private string _projectileTag; // тег снаряда (ур 8 24*00)
    //[SerializeField] private Transform _shootPoint; //точка спавна
    [SerializeField] private float _reloadTime=2f; //перезарядка
    private float _timer;
    [SerializeField] private List <Transform> _spawnPoints; // точки спавна
    //public int numberOfPoint=3;
    //private Queue<Transform> _shootPoint; // список точек спавна
    //public Transform[] _shootPoint;

    private ObjectPooler _objectPooler; //скрипт pool объектов

    void Start()
    {   
         _objectPooler=ObjectPooler.Instance; //синглтон
    }
private void Update() 
{   
    if (_timer<=0) // пока таймер =0
      {
        if (Input.GetMouseButton(0)) // нажата левая кнопка
          {
              BornUnit(); // выстрел
              _timer=_reloadTime;
          } 
      } 
    else
       _timer-=Time.deltaTime;
               
}
    // Update is called once per frame
    protected void BornUnit () //выстрел через pool объектов
    {  
        for (int i = 0; i <_spawnPoints.Count; i++)
         {
            // objectQueue.Enqueue(Instantiate(prefab) as Transform);
           _objectPooler.SpawnFromPool (_projectileTag, _spawnPoints[i].position, transform.rotation);

            //_objectPooler.SpawnFromPool (_projectileTag,_shootPoint.position, transform.rotation);
         }      
    }

}
