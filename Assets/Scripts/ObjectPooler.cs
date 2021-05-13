using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ObjectPooler: MonoBehaviour //на камеру
{ 
   [System.Serializable] // чтобы класс был виден и сериализуем 
   
   public class Pool
   
   { // для каждого типа пуль будет тег, свой префаб и установим размер данного пула
      public string tag; 
      public GameObject prefab;
      public int size; // размер данного пула, подбирается опытным путем, скольок может вместится пуль на сцене за раз

   }
   

   public static ObjectPooler Instance; // т.к. поле статическое мы можем к нему обратится через класс, а не через объект
// экземпляр данного класса, т.е. если на сцене есть какой либо объект содержащий этот скрипт то данное статическое поле Instans
// всегда будет содержать ссылку на этот самый экземпляр объекта, т.е. на этот скрипт и никакого поиска не надо будет делать
   public void Awake()
   {
       Instance=this; // данный инстанс =текущий скрипт
   }

   public List <Pool> pools; // лист пулов
   public Dictionary <string, Queue<GameObject>> poolDictionary; // словарь, очередь из обеъктов

   private void Start()
   {
      poolDictionary=new Dictionary <string, Queue<GameObject>>();

      foreach (Pool pool in pools) // для каждого пула в листе этих пулов
      { 
         Queue<GameObject> objectPool=new Queue<GameObject>(); // инициализируем в очередь

         for (int i=0; i<pool.size; i++) //pool.size - размер пула
         {
            GameObject obj=Instantiate(pool.prefab);// будем создаватьобъекты
            obj.SetActive(false); // скрываем их
            objectPool.Enqueue(obj); //заносим в очередь
         }

         poolDictionary.Add (pool.tag, objectPool); // добавляем в наш словарь
         //pool.tag - ключ словаря, objectPool - очередь (объект словоря)
         
      }
   }

   public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
   //спавнит наши объекты из пула.... что спавним, в какой позиции, ориентацию 
   {
      if (!poolDictionary.ContainsKey(tag)) //проверка на то что нету данного тега в словаре
      return null;

      GameObject objectToSpawn=poolDictionary [tag].Dequeue(); //убераем первое что есть в очереди и заносим его в objectToSpawn

      objectToSpawn.SetActive(true);    // активируем его
      objectToSpawn.transform.position=position; //позиция объекта
      objectToSpawn.transform.rotation=rotation; // ориентация
      poolDictionary[tag].Enqueue(objectToSpawn); // заносим снова в очередь, он будет там последним

      return objectToSpawn; //возвращаем объект который заспавнили
   }
  
}

