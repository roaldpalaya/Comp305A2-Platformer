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

    //PUBLIC VARIABLES
    public float Velocity = 15f;
    public float _jumpForce = 150f;
    private GameObject camera;
    public Transform _spawnPoint;
	// Use this for initialization
	void Start () {
        this._init();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (this._grounded)
        {
            this._move = Input.GetAxis("Horizontal");
            if (this._move > 0f)
            {
                this._move = 1;
                this._faceRight = true;
                this._flip();

            }
            else if (this._move < 0f)
            {
                this._move = -1;
                this._faceRight = false;
                this._flip();

            }
            else
            {
                this._move = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this._jump = 1;
            }
            this._rigidBody.AddForce(new Vector2(this._move * this.Velocity, this._jump*this._jumpForce), ForceMode2D.Force);
        } else
        {
            this._move = 0f;
            this._jump = 0f;
        }

        this.camera.transform.position = new Vector3((this._trfrm.position.x*0.85f)+6f, this._trfrm.position.y, -10f);
        Debug.Log(this._grounded);
	}
    private void _init()
    {
         this._trfrm = GetComponent<Transform>();
        this._rigidBody = GetComponent<Rigidbody2D>();
       this.camera = GameObject.FindWithTag("MainCamera");
        this._faceRight = true;
        this._grounded = false;
        this._move = 0f;
        this._jump = 0f;
    }

    private void _flip()
    {
        if (this._faceRight)
        {
            this._trfrm.localScale = new Vector2(0.4f, 0.4f);
        }
        else
        {
            this._trfrm.localScale = new Vector2(-0.4f, .4f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DeathPlane"))
        {
            this._trfrm.position = this._spawnPoint.position;
            //life
            //sound
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
    }

 }
