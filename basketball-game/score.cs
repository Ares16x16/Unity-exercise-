using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {
	
	int mScore=0;	
	float   vSbarValue =0.0f;
	void Start () {		
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().isKinematic = true;
		
	}
	
	int t_valueUpDown=0;
	void Update () {
		 float translation = Time.deltaTime * 20;
	
		if(vSbarValue>9.0f){t_valueUpDown=1; }
		if(vSbarValue<0.0f){t_valueUpDown=0;}
		
		if(t_valueUpDown==0){
		   vSbarValue=vSbarValue+translation;
		}else{
		   vSbarValue=vSbarValue-translation;
		}
		
		if (Input.GetButtonDown("Fire1")) {	
			GetComponent<Rigidbody>().isKinematic = false;
			GetComponent<Rigidbody>().AddForce (Vector3.up * (vSbarValue*120) ); //60
			GetComponent<Rigidbody>().AddForce (Vector3.forward * 180);
			GetComponent<Rigidbody>().AddForce (Vector3.right* 2);
        }

		if(gameObject.gameObject.transform.position.y<-10){
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			GetComponent<Rigidbody>().isKinematic = true;
			GetComponent<Rigidbody>().position=new Vector3(0,-0.83f,-6.56f);

		}
		
	}

	 void OnTriggerExit(Collider other) {
		if(other.transform.name=="PointEvent"){
			mScore=mScore+1;
		}
		
    }

    
	void OnGUI () {
		GUI.VerticalScrollbar(new Rect(25, 20, 100, 120), vSbarValue, 1.0F, 10.0F, 0.0F);
        GUI.Label(new Rect(0,0,400,400)," Score:"+mScore);
    }
 
	
}
