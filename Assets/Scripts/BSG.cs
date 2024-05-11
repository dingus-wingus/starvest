using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// BSG  Script
/// Kozeng Yang 
// 4/30/24
public class BSG : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private RawImage _img;
    [SerializeField] private float x, y;

    //public float speed = 4f;
    // private Vector3 StartPos;
    void Start()
    {
       // StartPos = transform.position;
    }

    // Update is called once per frame
    /// <summary>
    /// Update the image and move it
    /// </summary>
    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(x, y) * Time.deltaTime, _img.uvRect.size);
       // transform.Translate(translation: Vector3.down * speed * Time.deltaTime);
       // if(transform.position.y < -35.1f)
       // {
            //transform.position = StartPos;
      //  }
    }
}
