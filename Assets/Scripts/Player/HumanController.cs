using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour, IAnimController
{
    ParticleSystem _particles;

    private void Awake()
    {
        _particles = GetComponentInChildren<ParticleSystem>();
        _particles.Stop();
    }

    public void UpdateMovementAnim(Vector2 velocity)
    {
        if((velocity.x != 0 || velocity.y != 0) && !_particles.isPlaying)
        {
            _particles.Play(true);
            //Debug.Log("particle play");
        }
        else if ((velocity.x == 0 && velocity.y == 0) && _particles.isPlaying)
        {
            //Debug.Log("particle stop " + velocity.x + " " + velocity.y + " " + _particles.isPlaying);
            _particles.Stop();            
        }
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
