using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moveman : MonoBehaviour {
	
	public int bl;
	public AudioSource[] se;
	public Text pointtext;
	public int point;
	public float power;
	public Rigidbody rb;
	public GameObject gobj;
	public Vector3 gobjscale;
	public Vector3 nextlocate;
	public bool control;
	public int direction;
	public Quaternion q = Quaternion.Euler (new Vector3 (0, 0, 0));
	public GameObject cam;
	// Use this for initialization
	public void Start () {
		bl = 1;
		power = 0f;
		control = false;
		point = -3;
		direction = 0;
	}

	// Update is called once per frame
	public void FixedUpdate () {
		if (control == true) {
			if (Input.GetMouseButton (0)) {
				if (se [1].isPlaying == false) {
					se [1].Play ();
				}
				power += 2f;
				if (this.gameObject.transform.localScale.y >= 0.02f) {
					this.gameObject.transform.localScale = new Vector3 (this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y - 0.0005f, this.gameObject.transform.localScale.z);
					gobj.gameObject.transform.localScale = new Vector3 (gobj.gameObject.transform.localScale.x, gobj.gameObject.transform.localScale.y - 0.0005f, gobj.gameObject.transform.localScale.z);
				}
			}
		}
	}
	public void Update () {
			//this.gameObject.transform.eulerAngles = new Vector3 (0, 0, 0);
			if (Input.GetMouseButtonUp (0)&&control==true) {
					control = false;
					se [0].Play ();
					if (direction <= 20) {
						
				rb.AddForce (new Vector3(2f*power*nextlocate.x,1,2f*power*nextlocate.z)+new Vector3 (0f, 140f, 0f));
					} else {
						
				rb.AddForce (new Vector3(2f*power*nextlocate.x,1,2f*power*nextlocate.z)+new Vector3 (0f, 140f, 0f));
					}
					this.gameObject.transform.localScale = new Vector3 (0.047f, 0.085f, 0.045f);
					gobj.gameObject.transform.localScale = gobjscale;
					power = 0f;
					
				}
				if (this.gameObject.transform.position.y < 0) {
					control = false;
				}
		}

	public void OnCollisionEnter(Collision coll){
		rb.velocity=new Vector3 (0, 0, 0);
		this.gameObject.transform.eulerAngles = new Vector3 (0, 0, 0);
		if (gobj != coll.gameObject) {
			gobj = coll.gameObject;
			gobjscale = gobj.gameObject.transform.localScale;
			if (control == false) {
				float a = Vector3.Distance (this.gameObject.transform.position, gobj.gameObject.transform.position);
				Debug.Log ("current model distance："+a);
				if (a < 0.129f) {
					se [2].Play();
					bl += 2;
					point += bl;
				} else {
					bl = 1;
					point+=bl;
				}

				pointtext.text =""+point;
				GameObject the_next;
				the_next = (GameObject)Resources.Load ("Cube"+Random.Range(0,4));
				GameObject outnext;
				direction = Random.Range (0,10000);
				float nd;
				nd = ((float)point) * 0.005f+0.4f;
				if (nd > 1) {
					nd = 1f;
				}
				float outp = 0.3f - Random.Range (0f, 0.2f * nd);
				if (direction <= 20) {
					outnext = Instantiate (the_next, new Vector3 (gobj.gameObject.transform.position.x + Random.Range (0.4f, nd), gobj.gameObject.transform.position.y, gobj.gameObject.transform.position.z), q);
					outnext.gameObject.transform.localScale = new Vector3 (outp,outnext.gameObject.transform.localScale.y,outp);
					nextlocate = outnext.gameObject.transform.position-this.gameObject.transform.position;
					cam.SendMessage ("getcam", gobj.gameObject.transform.position);
				} else {
					outnext = Instantiate (the_next, new Vector3 (gobj.gameObject.transform.position.x, gobj.gameObject.transform.position.y, gobj.gameObject.transform.position.z + Random.Range (0.4f, nd)), q);
					outnext.gameObject.transform.localScale = new Vector3 (outp,outnext.gameObject.transform.localScale.y,outp);
					nextlocate = outnext.gameObject.transform.position-this.gameObject.transform.position;
					cam.SendMessage ("getcam", gobj.gameObject.transform.position);
				}

			}
		}
		control = true;

	}

}

