/* Platoformer Assignment
 * Roald Russel T. Palaya
 * 300714999
 * Date last Modified: 10/22/2016
 */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishCheckpointController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cat"))
        {
            SceneManager.LoadScene("RestartScene");
        }
    }
}
