using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : PhysicsObject {

	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 7;
    public int currentHealth;
    public int maxHealth = 5;



	private SpriteRenderer spriteRenderer;
	private Animator animator;
    private gameMaster gm;
    // Use this for initialization



    void Awake () 
	{
        currentHealth = maxHealth;
		spriteRenderer = GetComponent<SpriteRenderer> (); 
		animator = GetComponent<Animator> ();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
	}


	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Coin") {
			Destroy (col.gameObject);
            gm.points += 1;
		}
	}

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        else if (currentHealth <= 0) Die();
    }

    public void Die() {
        PlayerPrefs.SetInt("Health", maxHealth);
        PlayerPrefs.SetInt("Points", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Damage(int dmg) {
        currentHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("Player_Hurt");
    }

    public void SetHealth(int savedHealth) {
        currentHealth = savedHealth;
    }


}