/* Platoformer Assignment
 * Roald Russel T. Palaya
 * 300714999
 * Date last Modified: 10/22/2016
 */

using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {
    //PRIVATE VARS
    private Transform _trfrm;
    private GameObject SpawnPoint;

    //PUBLIC VARS
    public AudioSource ChkpointSound;

	// Use this for initialization
	void Start () {
        this._trfrm = GetComponent<Transform>();
        this.SpawnPoint = GameObject.FindWithTag("SpawnPoint");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Cat"))
        {
            this.SpawnPoint.transform.position = this._trfrm.position;
            this.ChkpointSound.Play();
        }
    }
}
