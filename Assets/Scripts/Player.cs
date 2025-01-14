using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Settings")]
    public float JumpForce;

    [Header("References")]
    public Rigidbody2D PlayerRigidBody;

    public BoxCollider2D PlayerCollider;

    public Animator PlayerAnimator;

    //if the player is on the ground 
    private bool isGrouneded = true;

    //given lives is 3 to a player
    public int lives = 3;
    public bool isInvincible = false;

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

    void KillPlayer()
    {
        PlayerCollider.enabled = false;
        PlayerAnimator.enabled = false;
        PlayerRigidBody.AddForceY(JumpForce, ForceMode2D.Impulse);
    }
    void Hit()
    {
        lives -= 1;
        if (lives == 0)
        {
            KillPlayer();
        }

    }

    void Heal()
    {
        lives = Mathf.Min(3, lives + 1);
    }

    void StartInvincible()
    {
        isInvincible = true;
        //after 5s then make it stop!
        Invoke("StopInvincible", 5f);
    }

    void StopInvincible()
    {
        isInvincible = false;
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
            if (!isInvincible)
            {
                Destroy(collider.gameObject);
                Hit();
            }

        }
        else if (collider.gameObject.tag == "food")
        {
            Destroy(collider.gameObject);
            Heal();
        }
        else if (collider.gameObject.tag == "golden")
        {
            Destroy(collider.gameObject);
            StartInvincible();
        }
    }
}
