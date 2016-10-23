/* Platoformer Assignment
 * Roald Russel T. Palaya
 * 300714999
 * Date last Modified: 10/22/2016
 */
using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {
    //PRIVATE VARIABLES
    private Transform _trfrm;
    private Rigidbody2D _rigidBody;
    private float _move;
    private float _jump;
    private bool _faceRight;
    private bool _grounded;
    private bool _groundJump;
    private bool _blockAhead;
    private bool _blockAhead1;
    private bool _blockAhead2;
    private bool _blockAhead3;
    private bool _check;
   // private GameObject camera;
    private GameObject _spawnPoint;

    private GameObject _gControllerObject;
    private GameController _gController;

    //PUBLIC VARIABLES
    public float Velocity = 15f;
    public float _jumpForce = 150f;
    
    public Animator _animator;

    
    public AudioSource JumpSound;
    public AudioSource Pickupsound;
    public AudioSource DeathSound;
    public AudioSource DogDeathSound;

    public Transform SightCheck;
    public Transform JumpCheck;
    public Transform BlockCheck;
   
    // Use this for initialization
    void Start () {
        this._init();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (this._grounded)
        {
            this._groundJump = Physics2D.Linecast(this.SightCheck.position, this.JumpCheck.position,
               1 << LayerMask.NameToLayer("Solid"));
            this._blockAhead = Physics2D.Linecast(this.SightCheck.position, this.BlockCheck.position,
                1 << LayerMask.NameToLayer("Solid"));
            
           this._move = Input.GetAxis("Horizontal");
            if (this._move > 0f)
            {
                this._animator.SetInteger("CatState", 1);
                this._move = 1;
                this._faceRight = true;
                this._flip();

            }
            else if (this._move < 0f)
            {
                this._animator.SetInteger("CatState",1);
                this._move = -1;
                this._faceRight = false;
                this._flip();

            }
            else
            {
                this._animator.SetInteger("CatState", 0);
                this._move = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space) && this._groundJump && !this._blockAhead)//add linecasr as another requirement to jump
            {
                this._animator.SetInteger("CatState", 2);
                this._jump = 1;
                this.JumpSound.Play();
            }
            this._rigidBody.AddForce(new Vector2(this._move * this.Velocity, this._jump*this._jumpForce), ForceMode2D.Force);
        } else
        {
            this._move = 0f;
            this._jump = 0f;
        }

       //this.camera.transform.position = new Vector3((this._trfrm.position.x)+10f, this._trfrm.position.y, -15f);

      
        Debug.Log(this._grounded);
	}
    private void _init()
    {
         this._trfrm = GetComponent<Transform>();
        this._rigidBody = GetComponent<Rigidbody2D>();
        this._animator = GetComponent<Animator>();
        //this.camera = GameObject.FindGameObjectWithTag("MainCamera");
        this._gControllerObject = GameObject.Find("Game Controller");
        this._gController = this._gControllerObject.GetComponent < GameController >() as GameController; 
        this._spawnPoint = GameObject.FindWithTag("SpawnPoint");
        this._faceRight = true;
        this._grounded = false;
        this._blockAhead = false;
        this._groundJump = false;
        this._move = 0f;
        this._jump = 0f;
    }
    
    private void _flip()
    {
        if (this._faceRight)
        {
            this._trfrm.localScale = new Vector2(1f, 1f);
        }
        else
        {
            this._trfrm.localScale = new Vector2(-1f, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DeathPlane"))
        {
            this.DeathSound.Play();
            this._gController.Lives -= 1;
            this._trfrm.position = this._spawnPoint.transform.position;
            
        }
        if (other.gameObject.CompareTag("Mushroom"))
        {
            Destroy(other.gameObject);
            this.Pickupsound.Play();
            this._gController.Score +=100;
        }
        if (other.gameObject.CompareTag("Dog"))
        {
            this.DeathSound.Play();
            this._trfrm.position = this._spawnPoint.transform.position;
            this._gController.Lives-=1;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Dog"))
        {
            this.DogDeathSound.Play();
            Destroy(other.gameObject);
            this._gController.Score+=200;
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("Land"))
        {
            this._grounded = true;
        }
    }
    private void OnCollisionExit2D (Collision2D other)
    {
        this._grounded = false;
        this._animator.SetInteger("CatState", 2);
    }

 }
