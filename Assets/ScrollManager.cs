using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
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
        MovePiecesInPlay();
    }

    private void MovePiecesInPlay()
    {
        /*foreach (GameObject pieceInPlay in piecesInPlay) // TODO delete if not needed
        {
            pieceInPlay.transform.position = new Vector2(pieceInPlay.transform.position.x - speed * Time.deltaTime, pieceInPlay.transform.position.y);
        }*/

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
        GameObject nextPiece = GetRandomPiece();
        nextPiece.transform.position = transform.position;
        nextPiece.transform.parent = transform;
        piecesInPlay.Add(nextPiece);
    }

    private GameObject GetRandomPiece()
    {
        int rand = UnityEngine.Random.Range(0, modularPieces.Count);
        GameObject randomPiece = piecePools[rand].GetNextPiece();
        return randomPiece;
    }

    public class PiecePool
    {
        private int maxPoolSize = 7;
        private int myIndex = 0;
        private GameObject prefab;
        List<GameObject> pieces = new List<GameObject>();

        public PiecePool(GameObject prefabObject)
        {
            prefab = prefabObject;
        }

        /*public int GetCurrentIndex() // TODO delete if not needed
        {
            return index;
        }*/

        /*public int GetCount() // TODO delete if not needed
        {
            return pieces.Count;
        }*/

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
            Debug.Log("Index: " + myIndex.ToString());

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
