using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    // Start is called before the first frame update
    public static CameraZoom instance { get; private set; }

    public float duration = 0.5f;
    public float endCameraSize = 4f;
    public AnimationCurve animCurveZoom;
    private Camera cam;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    public void startzoomcourout()
    {
        StartCoroutine(zoomAnim());
    }
    private IEnumerator zoomAnim()
    {
        float startsize = cam.orthographicSize;
        float starttime = Time.time;
        while (Time.time < starttime + duration)
        {
            Debug.Log(cam.orthographicSize);
            cam.orthographicSize = Mathf.Lerp(startsize, endCameraSize, animCurveZoom.Evaluate((Time.time - starttime) / duration));
            yield return null;
        }
        cam.orthographicSize = startsize;
    }
}
