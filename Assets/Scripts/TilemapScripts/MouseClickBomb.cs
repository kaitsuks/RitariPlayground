using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseClickBomb : MonoBehaviour
{
	
	public TileBase m_Border;
	public TileBase m_ExplodedFloor;
	public GameObject m_Explosion;
	
	private Grid m_Grid;
	private Tilemap m_Foreground;
	private Tilemap m_BackGround;
		void Start ()
	{
		m_Grid = GetComponent<Grid>();
		m_Foreground = GameObject.Find("Ruoho").GetComponent<Tilemap>();
		m_BackGround = GameObject.Find("Puut").GetComponent<Tilemap>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (m_Grid && Input.GetMouseButtonDown(0))
		{
            Debug.Log("Hiirtä klikattu");
			Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3Int gridPos = m_Grid.WorldToCell(world);
            Debug.Log("Hiirtä klikattu" + gridPos);

            ExplodeCell(gridPos);
			
		}
	}

	private void ExplodeCell(Vector3Int position)
	{
		if (m_Foreground.GetTile(position) == m_Border)
			return;

		
		foreach (var pos in new BoundsInt(position.x - 1, position.y - 1, position.z, 3, 3, 1).allPositionsWithin)
		{
			if (m_Foreground.GetTile(pos) != null)
			{
				m_BackGround.SetTile(pos, m_ExplodedFloor);
			}
		}
		m_Foreground.SetTile(position, null);

		GameObject.Instantiate(m_Explosion, m_Grid.CellToLocalInterpolated(position + new Vector3(0.5f, 0.5f)), Quaternion.identity);
	}
}
