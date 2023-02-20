using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;


    private Touch xtouch;

    private Vector3 touchDown;
    private Vector3 touchUp;

    public bool canWalk;
    private bool isMoving;
    private bool dragStarted;


    void Start()
    {
       

        canWalk = true;
    }

    void Update()
    {
        
        if (canWalk)
        {

            if (Input.touchCount > 0)
            {
                xtouch = Input.GetTouch(0);
                if (xtouch.phase == TouchPhase.Began)
                {

                    dragStarted = true;
                    isMoving = true;
                    touchDown = xtouch.position;
                    touchUp = xtouch.position;
                }
            }
            if (dragStarted)
            {
                if (xtouch.phase == TouchPhase.Moved)
                {
                    touchDown = xtouch.position;
                }

                if (xtouch.phase == TouchPhase.Ended)
                {

                    touchDown = xtouch.position;
                    isMoving = false;
                    dragStarted = false;

                }

                gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotation(), rotationSpeed * Time.deltaTime);
                gameObject.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }

            

        }
    }



    Quaternion CalculateRotation()
    {
        Quaternion temp = Quaternion.LookRotation(CalculateMovement(), Vector3.up);
        return temp;
    }

    Vector3 CalculateMovement()
    {
        Vector3 dir = (touchDown - touchUp).normalized;
        dir.z = dir.y;
        dir.y = 0;
        return dir;
    }
}
