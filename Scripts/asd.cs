using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asd : MonoBehaviour
{
    #region Singleton class:GameManager
   public static asd Instance;
   void Awake()
   {
       if(Instance==null)
       Instance=this;
   }
   #endregion

   [HideInInspector] public bool isGameOver=false;
}
