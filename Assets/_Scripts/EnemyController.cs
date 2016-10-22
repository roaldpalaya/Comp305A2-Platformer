using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    //PIVATE VARS
    private Transform _trfrm;
    private Rigidbody2D _rigidBody;
    private bool _grounded;
    private bool _groundAhead;
    private bool _playerSeen;

    private float Spd = 2f;
    public float maxSpd = 4f;
    public Transform SightStart;
    public Transform SightEnd;
    public Transform LineOfSight;


    public AudioSource BarkSound;

    //public Transform LineOfSight;


	// Use this for initialization
	void Start () {
        this._trfrm = GetComponent<Transform>();
        this._rigidBody = GetComponent<Rigidbody2D>();
        this._grounded = false;
        this._groundAhead = true;
        this._playerSeen = false;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        Debug.Log("update called");
        if (this._grounded)
        {
            this._rigidBody.velocity = new Vector2(this._trfrm.localScale.x, 0) * this.Spd;
            
            this._groundAhead = Physics2D.Linecast(this.SightStart.position, this.SightEnd.position,
               1 << LayerMask.NameToLayer("Solid"));
            this._playerSeen = Physics2D.Linecast(this.SightStart.position, this.LineOfSight.position,
               1 << LayerMask.NameToLayer("Player"));
            /*
             * Debug purposes
            Debug.DrawLine(this.SightStart.position, this.SightEnd.position);
            Debug.Log("1: "+this._groundAhead);*/
            if (this._groundAhead == false)
            {
                this._flip();
                //this._groundAhead = true;
               // Debug.Log("3:  " + this._groundAhead);
            }
            if (this._playerSeen)
            {
                this.Spd *= 3f;
                if (this.Spd > this.maxSpd)
                {
                    this.Spd = this.maxSpd;
                }
            }
            

        }
	}

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Dog"))
        {
            this._flip();
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("Land"))
        {
            this._grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("Land"))
        {
            this._grounded = false;
        }

        
    }
    private void _flip()
    {
        if (this._trfrm.localScale.x == 1)
        {
            this._trfrm.localScale = new Vector2(-1f, 1f);
           
            Debug.Log("2: "+this._groundAhead);
        }
        else
        {
            this._trfrm.localScale = new Vector2(1f, 1f);
           
            Debug.Log(this._groundAhead);
        }
    }
}
