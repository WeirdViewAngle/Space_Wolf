using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Character : UnitedFederationOfInvokers
{
    //Jump Control
    Vector2 jumpDirection = new Vector2(0, 90);
    public static float jumpForce;

    //Rigidbody
    Rigidbody2D rb2d;

    //Timers
    Timer jumpCoolDown;
    Timer coolDownAfterBoost;

    bool inAir = false;

    float previousHeight;

    AnimDemo animations;

    bool isFalling = false;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();


        jumpCoolDown = GetComponent<Timer>();

        coolDownAfterBoost = GetComponent<Timer>();
        coolDownAfterBoost.Duration = 0.5f;
        coolDownAfterBoost.Run();

        jumpForce = GameConstants.JumpForce;

        
        dictOfInvokers.Add(EventName.DamageTakenEvent, new DamageTakenEvent());
        EventManager.AddInvoker(EventName.DamageTakenEvent, this);

        animations = GetComponent<AnimDemo>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animations.Landing();
        if(isFalling)
        {        
            if (collision.gameObject.CompareTag("Platforms"))
            {
                jumpCoolDown.Duration = 0.3f;
                jumpCoolDown.Run();

                inAir = false;
            }
            else if(collision.gameObject.CompareTag("BoostPlatforms") && coolDownAfterBoost.Finished)
            {
                inAir = false;
                Jump(GameConstants.JumpForce * 2);
            
                coolDownAfterBoost.Duration = 0.5f;
                coolDownAfterBoost.Run();
                AudioManager.Play(AudioNames.BoostTake);
            }
            else if (collision.gameObject.CompareTag("FirstPlatform") || collision.gameObject.CompareTag("ThirdPlatform") || collision.gameObject.CompareTag("SecondPlatform"))
            {
                jumpCoolDown.Duration = 0.3f;
                jumpCoolDown.Run();

                inAir = false;
            }
        }
    }


    void Update()
    {
        float inputJump = Input.GetAxis("Jump");
        if (inputJump > 0 && jumpCoolDown.Finished)
        {

            Jump(jumpForce);

            jumpCoolDown.Duration = 0.3f;
            jumpCoolDown.Run();

        }

        previousHeight = gameObject.transform.position.y;


        if(rb2d.velocity.y < -0.1)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }
    }


   

    private void FixedUpdate()
    {   
        float inputMoves = Input.GetAxis("Horizontal");
        if (inputMoves != 0)
        {
            Move(inputMoves);
        }
    }


    public virtual void Jump(float jumpForce)
    {
        if (!inAir)
        {
            rb2d.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
            inAir = true;
            AudioManager.Play(AudioNames.Jump);
            animations.Jump();
        }
    }

    public virtual void Move(float directionToMove)
    {
        animations.Walk();
        rb2d.velocity = new Vector2(directionToMove * GameConstants.MoveForce, rb2d.velocity.y);
    }



}

