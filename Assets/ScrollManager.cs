using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    [SerializeField] bool usesCapFlags;
    public static float speed = 6f;
    public static int screenGridWidth = 21;
    public static int pieceWidth = 3;
    private int numStartingPieces = 7;
    private float despawnXPos;

    [SerializeField] List<GameObject> modularPieces;

    private List<PiecePool> piecePools = new List<PiecePool>();

    private List<GameObject> piecesInPlay = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Determine xPos when piece off screen
        despawnXPos = gameObject.transform.position.x - screenGridWidth;

        // Make piecePools
        foreach (GameObject pieceType in modularPieces)
        {
            piecePools.Add(new PiecePool(pieceType));
        }

        // Create the starting pieces already in place
        for (int i = 0; i < numStartingPieces; i++)
        {
            GameObject piece = piecePools[0].GetNextPiece();
            piece.transform.position = new Vector3(transform.position.x - screenGridWidth + (pieceWidth * i), transform.position.y, transform.position.z);
            piece.transform.parent = gameObject.transform;
            //piece.transform.rotation = Quaternion.identity; // TODO delete if not needed
            piecesInPlay.Add(piece);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.state == State.GAME_OVER == false)
        {
            MovePiecesInPlay();
        }
    }

    private void MovePiecesInPlay()
    {
        for (int i = 0; i < piecesInPlay.Count; i++)
        {
            piecesInPlay[i].transform.position = new Vector2(piecesInPlay[i].transform.position.x - speed * Time.deltaTime, piecesInPlay[i].transform.position.y);
            if (piecesInPlay[i].transform.position.x < despawnXPos)
            {
                piecesInPlay.RemoveAt(i);
                QueueNextPiece();
            }
        }
    }

    private void QueueNextPiece()
    {
        GameObject nextPiece;
        if (GameManager.Instance.state == State.SPLASH_SCREEN)
        {
            nextPiece = piecePools[0].GetNextPiece();
        }
        else
        {
            nextPiece = GetRandomPiece();
        }
        nextPiece.transform.position = new Vector3(piecesInPlay[piecesInPlay.Count - 1].transform.position.x + pieceWidth, transform.position.y, 0f);
        nextPiece.transform.parent = transform;
        piecesInPlay.Add(nextPiece);
    }

    private GameObject GetRandomPiece()
    {
        List<PiecePool> validPools;

        if (usesCapFlags)
        {
            validPools = GetValidPools();            
        }
        else
        {
            validPools = piecePools;
        }

        int rand = UnityEngine.Random.Range(0, validPools.Count);
        GameObject randomPiece = validPools[rand].GetNextPiece();
        return randomPiece;
    }

    private List<PiecePool> GetValidPools()
    {
        List<PiecePool> listToReturn = new List<PiecePool>();

        if (piecesInPlay[piecesInPlay.Count-1].GetComponent<ModularCapFlags>().isEmpty)
        {
            for (int i = 0; i < piecePools.Count; i++)
            {
                if (piecePools[i].prefab.GetComponent<ModularCapFlags>().leftCap || piecePools[i].prefab.GetComponent<ModularCapFlags>().isEmpty)
                {
                    listToReturn.Add(piecePools[i]);
                }
            }
        }
        else if (piecesInPlay[piecesInPlay.Count-1].GetComponent<ModularCapFlags>().rightCap)
        {
            for (int i = 0; i < piecePools.Count; i++)
            {
                if (piecePools[i].prefab.GetComponent<ModularCapFlags>().isEmpty)
                {
                    listToReturn.Add(piecePools[i]);
                }
            }
        }
        else
        {
            for (int i = 0; i < piecePools.Count; i++)
            {
                if (piecePools[i].prefab.GetComponent<ModularCapFlags>().leftCap == false && piecePools[i].prefab.GetComponent<ModularCapFlags>().isEmpty == false)
                {
                    listToReturn.Add(piecePools[i]);
                }
            }
        }

        return listToReturn;
    }

    public class PiecePool
    {
        private int maxPoolSize = 7;
        private int myIndex = 0;
        public GameObject prefab { get; private set; }
        List<GameObject> pieces = new List<GameObject>();

        public PiecePool(GameObject prefabObject)
        {
            prefab = prefabObject;
        }

        public GameObject GetNextPiece()
        {
            GameObject pieceToReturn;
            if (myIndex >= pieces.Count)
            {
                pieceToReturn = GenerateNextPiece();
            }
            else
            {
                pieceToReturn = pieces[myIndex];
            }
            myIndex++;
            myIndex = myIndex % maxPoolSize;

            return pieceToReturn;
        }

        private GameObject GenerateNextPiece()
        {
            GameObject nextPiece = Instantiate(prefab);
            pieces.Add(nextPiece);
            return nextPiece;
        }
    }
}
