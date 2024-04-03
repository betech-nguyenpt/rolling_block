using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private float _rollSpeed = 9;
    private bool _isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (_isMoving)
        {
            return;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("up arrow key is held down");
            Assemble(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("down arrow key is held down");
            Assemble(Vector3.back);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("left arrow key is held down");
            Assemble(Vector3.left);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("right arrow key is held down");
            Assemble(Vector3.right);
        }
    }
    void Assemble(Vector3 dir)
    {
        var anchor = transform.position + (Vector3.down + dir) * 0.5f;
        var axis = Vector3.Cross(Vector3.up, dir);
        StartCoroutine(Roll(anchor, axis));
    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        _isMoving = true;

        for (int i = 0; i < (90/_rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        _isMoving = false;
    }
}
