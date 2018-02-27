using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bird : MonoBehaviour {
    Rigidbody2D rgb_bird;
    AudioSource Audio;
    public float power = 10f;
    
	void Start () {
        rgb_bird = GetComponent<Rigidbody2D>();
        Audio = GetComponent<AudioSource>();
        Audio.playOnAwake = false;
        Audio.loop = false;
	}
	
	void Update () {
        Vector3 pos = transform.position;
        if (pos.y < 12.5f) {
            Application.LoadLevel(0);
        }
		if (Input.GetKeyDown(KeyCode.Space)) {
            //rgb_bird.AddForce(Vector2.up * power,ForceMode2D.Impulse);

            transform.eulerAngles = new Vector3(0,0,0);
            rgb_bird.velocity = new Vector2(0f,power);
            //Vector2 movement = new Vector2(0f,5f);
            //rgb_bird.AddForce(movement * power);
            // transform.rotation.z =
            // rgb_bird.transform.Rotate(Vector3.left,speedbird * Time.deltaTime);
            
            Audio.Play();
            
        }
        Vector3 speedbird = rgb_bird.velocity;
        transform.eulerAngles = new Vector3(0,0,speedbird.y*4f);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "TubeBot" || collision.gameObject.tag == "TubeTop") {
             Application.LoadLevel(0);
        }
    }

}

