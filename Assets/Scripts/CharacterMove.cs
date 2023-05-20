using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed;
    public GameObject followCamara;
    public Vector3 camaraOffSet;
    public Animator characterAnimator;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Quaternion facingFoward;
    private Quaternion facingBack;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        facingFoward = new Quaternion(0, 0, 0, 0);
        facingBack = new Quaternion(0, 180, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (!InputManager.isPaused)
        {
        //player input goes here
        movement.x = InputManager.GetHorizontal();
        movement.y = InputManager.GetVertical();

        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }
        Animate();
    }
    private void FixedUpdate()
    {
        //physics are managed here
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime * speed);
    }
    private void LateUpdate()
    {
        //for camara follow
        followCamara.transform.position = gameObject.transform.position + camaraOffSet;

    }
    private void Animate()
    {
        if (movement.x >= 0.1f)
        {
            if (characterAnimator.gameObject.transform.rotation == facingBack)
                characterAnimator.gameObject.transform.rotation = facingFoward;
            characterAnimator.Play("Rogue_run_01");
        }
        else if (movement.x <= -0.1f)
        {
            characterAnimator.gameObject.transform.rotation = facingBack;
            characterAnimator.Play("Rogue_run_01");
        }
        else if (movement.y != 0)
        {
            characterAnimator.Play("Rogue_run_01");
        }
        else
        {
            characterAnimator.Play("Rogue_idle_01");
        }
    }
}
