using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Grid grid;
    // Use this for initialization
    void Start () {

        Vector3Int cellPosition = grid.WorldToCell(transform.position);
        transform.position = grid.GetCellCenterLocal(cellPosition);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(grid.cellSize.x, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(0, 0f, grid.cellSize.y);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(-grid.cellSize.x, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(0, 0f, -grid.cellSize.y);
        }
    }

}
