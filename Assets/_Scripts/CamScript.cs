using UnityEngine;
using System.Collections;

public class CamScript : MonoBehaviour {
    private bool _camBounds;
    private Vector2 _vel;
    private Transform _trfrm;

    public GameObject _cat;
    public Vector3 _minCamPos;
    public Vector3 _maxCamPos;

    public float xDelay;
    public float yDelay;
    private float _posX;
    private float _posY;
    
    // Use this for initialization
    void Start () {
        this._cat = GameObject.FindGameObjectWithTag("Cat");
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        _posX = Mathf.SmoothDamp(transform.position.x, _cat.transform.position.x, ref _vel.x, xDelay);
        _posY = Mathf.SmoothDamp(transform.position.y, _cat.transform.position.y, ref _vel.y, yDelay);

        transform.position = new Vector3(_posX, _posY, transform.position.z);
        if (_camBounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minCamPos.x, _maxCamPos.x),
                Mathf.Clamp(transform.position.y, _minCamPos.y, _maxCamPos.y),
                Mathf.Clamp(transform.position.z, _minCamPos.z, _maxCamPos.z));

        }
    }
}
