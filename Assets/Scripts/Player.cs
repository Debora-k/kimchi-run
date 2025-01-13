using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Settings")]
    public float JumpForce;

    [Header("References")]
    public Rigidbody2D PlayerRigidBody;

    public Animator PlayerAnimator;

    //if the player is on the ground 
    private bool isGrouneded = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //when a user press 'space'
        if (Input.GetKeyDown(KeyCode.Space) && isGrouneded)
        {
            PlayerRigidBody.AddForceY(JumpForce, ForceMode2D.Impulse);
            isGrouneded = false;
            PlayerAnimator.SetInteger("state", 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            //when this game begin
            if (!isGrouneded)
            {
                PlayerAnimator.SetInteger("state", 2);
            }
            isGrouneded = true;

        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "enemy")
        {

        }
        else if (collider.gameObject.tag == "food")
        {

        }
        else if (collider.gameObject.tag == "golden")
        {

        }
    }
}
