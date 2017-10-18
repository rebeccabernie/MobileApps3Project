using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webcamScript : MonoBehaviour {

    // Adapted from https://www.youtube.com/embed/T6bd_MQ2ass
    public GameObject webCameraPlane;
    //public Button fireButton;
    // Use this for initialization
    void Start () {
        if (Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = this.transform.position;
            this.transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.right, 90);
        }

        Input.gyro.enabled = true;

        //fireButton.onClick.AddListener(OnButtonDown);


        WebCamTexture webCameraTexture = new WebCamTexture();
        webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
        webCameraTexture.Play();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
