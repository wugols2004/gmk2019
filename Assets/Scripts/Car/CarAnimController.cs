using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimController : MonoBehaviour, IAnimController
{
    [SerializeField]
    Sprite[] sprites;

    SpriteRenderer _sprite;

    public void UpdateMovementAnim(Vector2 velocity)
    {
        float x = velocity.x;
        float y = velocity.y;
            

        if (x > 0)
        {
            if (y > 0)
            {
                _sprite.sprite = sprites[2];
            }
            else if (y < 0)
            {
                _sprite.sprite = sprites[7];
            }
            else
            {
                _sprite.sprite = sprites[4];
            }
        }
        else if (x < 0)
        {
            if (y > 0)
            {
                _sprite.sprite = sprites[0];
            }
            else if (y < 0)
            {
                _sprite.sprite = sprites[5];
            }
            else
            {
                _sprite.sprite = sprites[3];
            }
        } else
        {
            if (y > 0)
            {
                _sprite.sprite = sprites[1];
            }
            else if (y < 0)
            {
                _sprite.sprite = sprites[6];
            }
        }
    }

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

}
