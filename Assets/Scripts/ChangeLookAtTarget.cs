using UnityEngine;
using System.Collections;

public class ChangeLookAtTarget : MonoBehaviour {

	public GameObject target; // the target that the camera should look at

	void Start() {
		if (target == null) 
		{
			target = this.gameObject;
			Debug.Log ("ChangeLookAtTarget target not specified. Defaulting to parent GameObject");
		}
	}

	// Called when MouseDown on this gameObject
	void OnMouseDown () {

        // stop audio from all planets
        GameObject[] planet = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject p in planet)
        {
            Debug.Log("looking for audio of " + p.name);
            AudioSource audio = p.GetComponent<AudioSource>() as AudioSource;
            if (audio != null && audio.isPlaying)
            {
                audio.Stop();
                Debug.Log("Stoping audio of "+p.name);
            }
        }

		// change the target of the LookAtTarget script to be this gameobject.
		LookAtTarget.target = target;
		Camera.main.fieldOfView = 60*target.transform.localScale.x;

        // access the target's audioSource component to play it while camera is on target
        AudioSource targetAudio = target.GetComponent<AudioSource>() as AudioSource;
        if (targetAudio != null)
            targetAudio.Play();
    }
}
