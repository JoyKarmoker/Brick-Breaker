using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 1.25f;
    [SerializeField] float maxX = 14.75f;
    [SerializeField] float screenWidthInUnits = 16f;

    //Cached Ref
    private GameSession myGameSession;
    private float mouseXPosition;
    private Ball myBall;
    // Start is called before the first frame update
    void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
        myBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {  
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePosition;
    }

    private float GetXPos()
    {
        if(myGameSession.IsAutoPlayEnabled())
        {
            return myBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
