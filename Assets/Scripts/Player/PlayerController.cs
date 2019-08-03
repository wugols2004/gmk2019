using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    MovementController _move;

    private void Awake()
    {
        instance = this;

        _move = GetComponent<MovementController>();
    }

    public void DisableMovement()
    {
        _move.DisableMovement();
    }

    public void EnableMovement()
    {
        _move.EnableMovement();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
