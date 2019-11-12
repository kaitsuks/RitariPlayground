using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MonsterMapper : MonoBehaviour
{
	//public const string k_Key = "exploded";

	public TileBase m_Border;
	public TileBase m_ExplodedFloor;
    public TileBase tieTiili;
    public TileBase stub;
    public GameObject m_Explosion;
	
	private Grid m_Grid;
	private Tilemap m_Foreground;
	private Tilemap m_BackGround;
    private Tilemap m_TreeGround;
    //private GridInformation m_Info;
    private Vector3 monsterPosition;

	// Use this for initialization
	void Start ()
	{
		m_Grid = GameObject.Find("Grid").GetComponent<Grid>();
		//m_Info = m_Grid.GetComponent<GridInformation>();
		m_Foreground = GameObject.Find("Tiet").GetComponent<Tilemap>();
		m_BackGround = GameObject.Find("Ruoho").GetComponent<Tilemap>();
        m_TreeGround = GameObject.Find("Puut").GetComponent<Tilemap>();
    }
	
	// Update is called once per frame
	void Update ()
	{
        monsterPosition = this.transform.position;
        Vector3Int gridPos = m_Grid.WorldToCell(monsterPosition);
        if(m_TreeGround.GetTile(gridPos) != null && m_TreeGround.GetTile(gridPos) != stub) {
           // Debug.Log("Monster on puussa " + gridPos);
            gameObject.SendMessage("SlowDown", 0.2f);
        }
        else
            gameObject.SendMessage("RunFaster", 0.2f);

        //Debug.Log(transform.position);
        //Debug.Log(monsterPosition);
        if (m_Grid && (Input.GetKeyDown("k") || Input.GetKeyDown("l")))
		{
            //monsterPosition = this.transform.position;
            Debug.Log("k- tai l-kirjainta painettu");
			//Vector3 world = Camera.main.ScreenToWorldPoint(monsterPosition);
			//Vector3Int gridPos = m_Grid.WorldToCell(world);
            //Vector3Int gridPos = m_Grid.WorldToCell(monsterPosition);
            gridPos = m_Grid.WorldToCell(monsterPosition);
            Debug.Log("Monster ruudussa " + gridPos);
            

            ExplodeCell(gridPos);
			//ExplodeCell(gridPos + new Vector3Int(-1, 0, 0));
			//ExplodeCell(gridPos + new Vector3Int(-2, 0, 0));
			//ExplodeCell(gridPos + new Vector3Int(1, 0, 0));
			//ExplodeCell(gridPos + new Vector3Int(2, 0, 0));
			//ExplodeCell(gridPos + new Vector3Int(0, -1, 0));
			//ExplodeCell(gridPos + new Vector3Int(0, -2, 0));
			//ExplodeCell(gridPos + new Vector3Int(0, 1, 0));
			//ExplodeCell(gridPos + new Vector3Int(0, 2, 0));
		}
	}

	private void ExplodeCell(Vector3Int position)
	{
		if (m_Foreground.GetTile(position) == m_Border)
			return;

        //if(m_Foreground.GetTile(position) == tieTiili)
        //{
        //    m_Foreground.SetTile(position, null);
        //}
        if (m_TreeGround.GetTile(position) != null)
        {
            m_TreeGround.SetTile(position, stub);
        }

        //m_Info.ErasePositionProperty(position, k_Key);
        //m_Info.SetPositionProperty(position, k_Key, 1);
        //foreach (var pos in new BoundsInt(position.x - 1, position.y - 1, position.z, 3, 3, 1).allPositionsWithin)
        //{
        //	if (m_Foreground.GetTile(pos) != null)
        //	{
        //		m_BackGround.SetTile(pos, m_ExplodedFloor);
        //	}
        //}
        //m_Foreground.SetTile(position, null);

        //GameObject.Instantiate(m_Explosion, m_Grid.CellToLocalInterpolated(position + new Vector3(0.5f, 0.5f)), Quaternion.identity);
    }
}
