using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    float speed = 1;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float moveAcceleration = 75;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    float dashAcceleration = 120;

    [SerializeField, Tooltip("deceleration rate when no input is made")]
    float drag = 70;

    [SerializeField, Tooltip("movement bounds padding")]
    float padding = 1f;

    private Vector2 velocity;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    public bool isMovable = true;

    IAnimController _anim;

    private void Awake()
    {
        _anim = transform.GetComponentInChildren<IAnimController>();
        SetUpMoveBoundaries();
    }

    public Vector2 getCurrentVelocity()
    {
        return velocity;
    }

    public void DisableMovement()
    {
        isMovable = false;
        velocity = Vector2.zero;
    }

    public void EnableMovement()
    {
        isMovable = true;
        velocity = Vector2.zero;
    }

    private void Update()
    {
        if (!isMovable) {
            return;
        };


        float horiInput = Input.GetAxisRaw("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, speed * horiInput, moveAcceleration * Time.deltaTime);

        if (horiInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * horiInput, moveAcceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, drag * Time.deltaTime);
        }

        float vertInput = Input.GetAxisRaw("Vertical");
        velocity.y = Mathf.MoveTowards(velocity.y, speed * vertInput, moveAcceleration * Time.deltaTime);

        if (vertInput != 0)
        {
            velocity.y = Mathf.MoveTowards(velocity.y, speed * vertInput, moveAcceleration * Time.deltaTime);
        }
        else
        {
            velocity.y = Mathf.MoveTowards(velocity.y, 0, drag * Time.deltaTime);
        }

        transform.Translate(velocity * Time.deltaTime);

        // clamp position

        //var newXPos = Mathf.Clamp(transform.position.x, xMin, xMax);
        //var newYPos = Mathf.Clamp(transform.position.y, yMin, yMax);

        //transform.position = new Vector2(newXPos, newYPos);

        if(_anim != null)
        {
            _anim.UpdateMovementAnim(velocity);
        }
        

        //Debug.Log("curent position: " + transform.position.x + " bound X " + xMin + " - " + xMax);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
