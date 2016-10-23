/* Platoformer Assignment
 * Roald Russel T. Palaya
 * 300714999
 * Date last Modified: 10/22/2016
 */

using UnityEngine;
using System.Collections;

public class CamScript : MonoBehaviour {
    //PRIVATE VARS
    private bool _camBounds;
    private Vector2 _vel;
    private Transform _trfrm;
    private GameObject _cat;
    private Vector3 _minCamPos;
    private Vector3 _maxCamPos;


    // Use this for initialization
    void Start () {
        this._cat = GameObject.FindGameObjectWithTag("Cat");
        this._minCamPos.x = -4.6f;
        this._maxCamPos.x = 350f;
        this._minCamPos.y = 3f;
        this._maxCamPos.y = 5f;
	}
	
	// Update is called once per frame
	void LateUpdate () {
            
            transform.position = new Vector3(Mathf.Clamp(_cat.transform.position.x, _minCamPos.x, _maxCamPos.x),
                Mathf.Clamp(_cat.transform.position.y, _minCamPos.y, _maxCamPos.y),transform.position.z);

     
    }
}
