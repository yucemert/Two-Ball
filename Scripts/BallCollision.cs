using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
  ParticleSystem explosion;
  int ballIndex;
  void Start()
  {
    explosion=transform.GetChild(0).GetComponent<ParticleSystem>();
    ballIndex=transform.position.x>0?0:1;
  }
  void OnCollisionEnter2D(Collision2D col)
  {
      if(col.gameObject.tag=="Balls")
      {
         asd.Instance.isGameOver=true;
         explosion.Play();
         Splatters.Instance.AddSplatter(col.transform,col.contacts[0].point,ballIndex);
          PlayerMove.Instance.Restart();
      }
  }
}
