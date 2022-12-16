using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	public float speed = 15f;
	public GameObject target;
	public Vector3 offset;
	private Vector3 targetPos;
	public Camera cam;
	[Header("Zoom in Size")]
	public bool zoom = false;
	public int camSize;
	[Header("Zoom out Size (original size)")]
	public bool zoomOut = false;
	public int camSizeOut;
	[Header("Shake multiplier")]
	public bool shake = false;
	public float shakeMultiplier;
	public float shakeExtendor;
	// Use this for initialization
	/// <summary>
	/// Initialises the camera to the targetPos(the player)
	/// </summary>
	void Start(){cam = GetComponent<Camera>();targetPos = transform.position;}
	
	/// <summary>
	/// Adds lerp to the targetPos
	/// Starts coRountines for Zoomin, Zoomout and shake the camera
	/// </summary>
	void Update()
	{ 
		if (target)
		{
			Vector3 posNoZ = transform.position + offset;
			Vector3 targetDirection = (target.transform.position - posNoZ);
			float interpVelocity = targetDirection.magnitude * speed;
			targetPos = (transform.position) + (targetDirection.normalized * interpVelocity * Time.deltaTime);
			transform.position = Vector3.Lerp(transform.position, targetPos, 0.25f);
		}
		if (zoom == true && zoomOut == false){StartCoroutine(cameraZoom(camSizeOut, camSize, 0.5f));}
		if (zoomOut == true && zoom == false){StartCoroutine(cameraZoomOut(camSize, camSizeOut, 0.5f));}
		if (shake == true){StartCoroutine(shakeCam(shakeMultiplier));}
	}

	/// <summary>
	/// Zooming the camera, fairly self explanatory
	/// </summary>
	/// <param name="oldSize"></param>
	/// <param name="newSize"></param>
	/// <param name="time"></param>
	/// <returns></returns>
	IEnumerator cameraZoom(float oldSize, float newSize, float time)
	{
	
		float elapsed = 0;
		while (elapsed <= time)
		{
			float quarterWay = time / 1.5f;
			float speed;
			if (quarterWay > elapsed)
			{
				speed = 2.0f;
			}
			else { speed = 0.3f; }
			elapsed += Time.deltaTime * speed;
			float t = elapsed / time;
			Camera.main.orthographicSize = Mathf.Lerp(oldSize, newSize, t);
			yield return null;
		} zoom = false;
	}
	/// <summary>
	/// Zooming out the camera, also fairly self explanatory
	/// </summary>
	/// <param name="oldSize"></param>
	/// <param name="newSize"></param>
	/// <param name="time"></param>
	/// <returns></returns>
	IEnumerator cameraZoomOut(float oldSize, float newSize, float time)
	{
		float elapsed = 0;
		while (elapsed <= time)
		{
			float speed = 0.5f;
			elapsed += Time.deltaTime * speed;
			float t = elapsed / time;
			Camera.main.orthographicSize = Mathf.Lerp(oldSize, newSize, t);
			yield return null;
		} zoomOut = false;
	}
	/// <summary>
	/// Shakes the camera by adding small amount or random change * the shake multiplier a few times
	/// </summary>
	/// <param name="shakeMultiplier"></param>
	/// <returns></returns>
	IEnumerator shakeCam(float shakeMultiplier)
	{
		transform.localPosition = cam.transform.position + Random.insideUnitSphere * shakeMultiplier;
		yield return new WaitForSeconds(shakeExtendor);
		transform.localPosition = cam.transform.position + Random.insideUnitSphere * shakeMultiplier;
		yield return new WaitForSeconds(shakeExtendor);
		transform.localPosition = cam.transform.position + Random.insideUnitSphere * shakeMultiplier;
		shake = false;
	}
}