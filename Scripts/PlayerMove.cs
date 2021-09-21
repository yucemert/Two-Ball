using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    #region Singleton class:PlayerMove
    public static PlayerMove Instance;
    void Awake()
    {
        if(Instance==null)
            Instance=this;
    }
    #endregion
    [SerializeField] CircleCollider2D RedBallCol;
    [SerializeField] CircleCollider2D BlueBallCol;
    Vector3 startPosition;



    [SerializeField] float speed;
    [SerializeField] float RotationSpeed;
    Rigidbody2D rb;
    
    void Start()
    {
        startPosition=transform.position;
        rb=GetComponent<Rigidbody2D>();
        MoveUp();

    }

    
    void Update()
    {
        if(!asd.Instance.isGameOver)
        {
             if(Input.GetKey(KeyCode.LeftArrow))
        {
            RotateLeft();
        }
         else if(Input.GetKey(KeyCode.RightArrow))
        {
            RotateRight();
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow)||Input.GetKeyUp(KeyCode.RightArrow))
        rb.angularVelocity=0.0f;
        }
        

        
        }
    void MoveUp()
    {
        rb.velocity=Vector2.up*speed;
    }
    void RotateLeft()
    {
        rb.angularVelocity=RotationSpeed;
    }
     void RotateRight()
    {
        rb.angularVelocity=-RotationSpeed;
    }
    public void Restart()
    {
        RedBallCol.enabled=false;
        BlueBallCol.enabled=false;
        rb.angularVelocity=0.0f;
        rb.velocity=Vector2.zero;

        transform.DORotate(Vector3.zero,1f)
        .SetDelay(1f)
        .SetEase(Ease.InOutBack);

        transform.DOMove(startPosition,1f)
        .SetDelay(1f)
        .SetEase(Ease.InOutFlash)
        .OnComplete(()=>{
            RedBallCol.enabled=true;
            BlueBallCol.enabled=true;
            asd.Instance.isGameOver=false;
            MoveUp();
        });

    }



void OnTriggerEnter2D(Collider2D col)
{
    if(col.gameObject.tag=="LevelEnd")
    {
        Destroy(col.gameObject);
        Debug.Log("Win");
        int currentLevelIndex=EditorSceneManager.GetActiveScene().buildIndex;
        if(currentLevelIndex<EditorSceneManager.sceneCount)
        EditorSceneManager.LoadSceneAsync(++currentLevelIndex);
    }
}

}

