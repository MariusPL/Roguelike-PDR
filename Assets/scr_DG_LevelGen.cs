using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DG_LevelGen : MonoBehaviour
{
    public float StartTimeBetweenRoom = 0.25f;
    public int maxRooms = 10;
    private int RoomsCounter;
    private int ViableRoomCounter;
    public GameObject[] rooms;
    private int direction;
    private int lastdirection;
    public float offset;
    private float timebetweenRoom;
    private int[] forwardCounter = new int[5];

    private bool statePolish, stateCoreRooms;
    public List<GameObject> roomList;
    private Vector2 originalPos;


    // Start is called before the first frame update
    void Start()
    {
        forwardCounter[1] = 0;
        forwardCounter[2] = 0;
        forwardCounter[3] = 0;
        forwardCounter[4] = 0;
        originalPos = transform.position;
        GameObject aux = Instantiate(rooms[4], transform.position, Quaternion.identity);
        roomList.Add(aux);
        RoomsCounter = 0;
        ViableRoomCounter = 0;
        direction = Random.Range(1, 5);
        statePolish = false;
        stateCoreRooms = false;
    }

    private void Update()
    {
        if (stateCoreRooms)
        { 
        
        }
        else if (statePolish)
        {
            PolishRooms();
        }
        else
        {
            if (RoomsCounter < maxRooms)
            {
                if (timebetweenRoom <= 0)
                {
                    Move();
                    timebetweenRoom = StartTimeBetweenRoom;
                }
                else
                {
                    timebetweenRoom -= Time.deltaTime;

                }
            }
            else
            {

                if (ViableRoomCounter < maxRooms)
                {
                    if (ViableRoomCounter == 0)
                    {
                        forwardCounter[1] = 0;
                        forwardCounter[2] = 0;
                        forwardCounter[3] = 0;
                        forwardCounter[4] = 0;
                        transform.position = originalPos;
                    }


                    if (timebetweenRoom <= 0)
                    {
                        GenerateViablePath();
                        timebetweenRoom = StartTimeBetweenRoom;
                    }
                    else
                    {
                        timebetweenRoom -= Time.deltaTime;

                    }
                }
                else
                {
                    statePolish = true;
                }
            }


        }
       



    }
    private void Move()
    {

        Vector2 newPos = transform.position;
        switch (direction)
        {
            case 1:
                { //move Right
                    newPos = new Vector2(transform.position.x + offset, transform.position.y);
                    transform.position = newPos;
                    direction = Random.Range(1, 5);
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0f);
                    if (hit.collider != null)
                    {
                        GameObject aux = Instantiate(rooms[4], transform.position, Quaternion.identity);
                        roomList.Add(aux);
                        if (direction == 2 || direction == 1) 
                        {
                            Vector2 auxPos = new Vector2(transform.position.x + offset, transform.position.y);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = 3; }
                        }
                        if (direction == 3)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x, transform.position.y + offset);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = 4; }
                        }
                        if (direction == 4)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x, transform.position.y - offset);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = Random.Range(1, 5); }
                        }

                        

                    }
                    else {
                        if (forwardCounter[1] >= 2 && (direction == 1 || direction == 2))
                        {
                            direction = Random.Range(3, 5);
                        }
                        switch (direction)
                        {
                            case 1:
                                {

                                    GameObject aux = Instantiate(rooms[5], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 2:
                                {
                                    direction = 1;
                                    GameObject aux = Instantiate(rooms[5], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 3:
                                {
                                    GameObject aux = Instantiate(rooms[1], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 4:
                                {
                                    GameObject aux = Instantiate(rooms[0], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                        }
                    }
                    


                    break;
                }
            case 2:
                { //move Left
                    newPos = new Vector2(transform.position.x - offset, transform.position.y);
                    transform.position = newPos;
                    direction = Random.Range(1, 5);
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0f);
                    if (hit.collider != null)
                    {
                        GameObject aux = Instantiate(rooms[4], transform.position, Quaternion.identity);
                        roomList.Add(aux);
                        if (direction == 2 || direction == 1)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x - offset, transform.position.y);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = 3; }
                        }
                        if (direction == 3)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x, transform.position.y + offset);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = 4; }
                        }
                        if (direction == 4)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x, transform.position.y - offset);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = Random.Range(1, 5); }
                        }

                        
                    }
                    else
                    {
                        if (forwardCounter[2] >= 2 && (direction == 1 || direction == 2))
                        {
                            direction = Random.Range(3, 5);
                        }
                        switch (direction)
                        {
                            case 1:
                                {
                                    direction = 2;
                                    GameObject aux = Instantiate(rooms[5], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 2:
                                {

                                    GameObject aux = Instantiate(rooms[5], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 3:
                                {
                                    GameObject aux = Instantiate(rooms[3], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 4:
                                {
                                    GameObject aux = Instantiate(rooms[2], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                        }
                    }
                    
                    break;

                }
            case 3:
                { //move Up
                    newPos = new Vector2(transform.position.x, transform.position.y + offset);
                    transform.position = newPos;
                    direction = Random.Range(1, 5);
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0f);
                    if (hit.collider != null)
                    {
                        GameObject aux = Instantiate(rooms[4], transform.position, Quaternion.identity);
                        roomList.Add(aux);
                        if (direction == 1)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x + offset, transform.position.y);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = 2; }
                        }
                        if (direction == 2)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x - offset, transform.position.y);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = 3; }
                        }
                        if (direction == 3 || direction == 4)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x, transform.position.y + offset);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = Random.Range(1, 5); }
                        }
                        
                    }
                    else
                    {
                        if (forwardCounter[3] >= 2 && (direction == 3 || direction == 4))
                        {
                            direction = Random.Range(1, 3);
                        }
                        switch (direction)
                        {
                            case 1:
                                {
                                    GameObject aux = Instantiate(rooms[2], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 2:
                                {

                                    GameObject aux = Instantiate(rooms[0], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 3:
                                {
                                    GameObject aux = Instantiate(rooms[6], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 4:
                                {
                                    direction = 3;
                                    GameObject aux = Instantiate(rooms[6], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                        }
                    }
                    
                    break;
                }
            case 4:
                { //move Down
                    newPos = new Vector2(transform.position.x, transform.position.y - offset);
                    transform.position = newPos;
                    direction = Random.Range(1, 5);
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0f);
                    if (hit.collider != null)
                    {
                        GameObject aux = Instantiate(rooms[4], transform.position, Quaternion.identity);
                        roomList.Add(aux);
                        if (direction == 1)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x + offset, transform.position.y);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = 2; }
                        }
                        if (direction == 2)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x - offset, transform.position.y);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = 3; }
                        }
                        if (direction == 3 || direction == 4)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x, transform.position.y - offset);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = Random.Range(1, 5); }
                        }
                        
                    }
                    else {
                        if (forwardCounter[4] >= 2 && (direction == 3 || direction == 4))
                        {
                            direction = Random.Range(1, 3);
                        }
                        switch (direction)
                        {
                            case 1:
                                {
                                    GameObject aux = Instantiate(rooms[3], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 2:
                                {

                                    GameObject aux = Instantiate(rooms[1], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 3:
                                {
                                    direction = 4;
                                    GameObject aux = Instantiate(rooms[6], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 4:
                                {

                                    GameObject aux = Instantiate(rooms[6], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                        }
                    }
                    
                    break;
                }

            default:
                { Debug.Log("Out of range"); break; }
        }
            RoomsCounter++;
        CheckForwardCounter();
        lastdirection = direction;

    }


    private void GenerateViablePath()
    {

        Vector2 newPos = transform.position;
        switch (direction)
        {
            case 1:
                { //move Right
                    newPos = new Vector2(transform.position.x + offset, transform.position.y);
                    transform.position = newPos;
                    direction = Random.Range(1, 5);
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0f);
                    if (hit.collider != null)
                    {
                        GameObject aux = Instantiate(rooms[4], transform.position, Quaternion.identity);
                        roomList.Add(aux);
                        if (direction == 2 || direction == 1)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x + offset, transform.position.y);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = 3; }
                        }
                        if (direction == 3)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x, transform.position.y + offset);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = 4; }
                        }
                        if (direction == 4)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x, transform.position.y - offset);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = Random.Range(1, 5); }
                        }



                    }
                    else
                    {
                        if (forwardCounter[1] >= 2 && (direction == 1 || direction == 2))
                        {
                            direction = Random.Range(3, 5);
                        }
                        switch (direction)
                        {
                            case 1:
                                {

                                    GameObject aux = Instantiate(rooms[5], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 2:
                                {
                                    direction = 1;
                                    GameObject aux = Instantiate(rooms[5], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 3:
                                {
                                    GameObject aux = Instantiate(rooms[1], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 4:
                                {
                                    GameObject aux = Instantiate(rooms[0], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                        }
                    }



                    break;
                }
            case 2:
                { //move Left
                    newPos = new Vector2(transform.position.x - offset, transform.position.y);
                    transform.position = newPos;
                    direction = Random.Range(1, 5);
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0f);
                    if (hit.collider != null)
                    {
                        GameObject aux = Instantiate(rooms[4], transform.position, Quaternion.identity);
                        roomList.Add(aux);
                        if (direction == 2 || direction == 1)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x - offset, transform.position.y);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = 3; }
                        }
                        if (direction == 3)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x, transform.position.y + offset);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = 4; }
                        }
                        if (direction == 4)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x, transform.position.y - offset);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = Random.Range(1, 5); }
                        }


                    }
                    else
                    {
                        if (forwardCounter[2] >= 2 && (direction == 1 || direction == 2))
                        {
                            direction = Random.Range(3, 5);
                        }
                        switch (direction)
                        {
                            case 1:
                                {
                                    direction = 2;
                                    GameObject aux = Instantiate(rooms[5], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 2:
                                {

                                    GameObject aux = Instantiate(rooms[5], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 3:
                                {
                                    GameObject aux = Instantiate(rooms[3], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 4:
                                {
                                    GameObject aux = Instantiate(rooms[2], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                        }
                    }

                    break;

                }
            case 3:
                { //move Up
                    newPos = new Vector2(transform.position.x, transform.position.y + offset);
                    transform.position = newPos;
                    direction = Random.Range(1, 5);
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0f);
                    if (hit.collider != null)
                    {
                        GameObject aux = Instantiate(rooms[4], transform.position, Quaternion.identity);
                        roomList.Add(aux);
                        if (direction == 1)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x + offset, transform.position.y);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = 2; }
                        }
                        if (direction == 2)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x - offset, transform.position.y);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = 3; }
                        }
                        if (direction == 3 || direction == 4)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x, transform.position.y + offset);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = Random.Range(1, 5); }
                        }

                    }
                    else
                    {
                        if (forwardCounter[3] >= 2 && (direction == 3 || direction == 4))
                        {
                            direction = Random.Range(1, 3);
                        }
                        switch (direction)
                        {
                            case 1:
                                {
                                    GameObject aux = Instantiate(rooms[2], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 2:
                                {

                                    GameObject aux = Instantiate(rooms[0], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 3:
                                {
                                    GameObject aux = Instantiate(rooms[6], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 4:
                                {
                                    direction = 3;
                                    GameObject aux = Instantiate(rooms[6], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                        }
                    }

                    break;
                }
            case 4:
                { //move Down
                    newPos = new Vector2(transform.position.x, transform.position.y - offset);
                    transform.position = newPos;
                    direction = Random.Range(1, 5);
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0f);
                    if (hit.collider != null)
                    {
                        GameObject aux = Instantiate(rooms[4], transform.position, Quaternion.identity);
                        roomList.Add(aux);
                        if (direction == 1)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x + offset, transform.position.y);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = 2; }
                        }
                        if (direction == 2)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x - offset, transform.position.y);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = 3; }
                        }
                        if (direction == 3 || direction == 4)
                        {
                            Vector2 auxPos = new Vector2(transform.position.x, transform.position.y - offset);
                            hit = Physics2D.Raycast(auxPos, Vector2.up, 0f);
                            if (hit.collider != null)
                            { direction = Random.Range(1, 5); }
                        }

                    }
                    else
                    {
                        if (forwardCounter[4] >= 2 && (direction == 3 || direction == 4))
                        {
                            direction = Random.Range(1, 3);
                        }
                        switch (direction)
                        {
                            case 1:
                                {
                                    GameObject aux = Instantiate(rooms[3], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 2:
                                {

                                    GameObject aux = Instantiate(rooms[1], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 3:
                                {
                                    direction = 4;
                                    GameObject aux = Instantiate(rooms[6], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                            case 4:
                                {

                                    GameObject aux = Instantiate(rooms[6], transform.position, Quaternion.identity);
                                    roomList.Add(aux);
                                    break;
                                }
                        }
                    }

                    break;
                }

            default:
                { Debug.Log("Out of range"); break; }
        }
        ViableRoomCounter++;
        CheckForwardCounter();
        lastdirection = direction;

    }





    private void CheckForwardCounter()
    {
        if (direction == lastdirection && direction == 1)
        {
            forwardCounter[1]++;
            forwardCounter[2] = 0;
            forwardCounter[3] = 0;
            forwardCounter[4] = 0;
        }
        else if (direction == lastdirection && direction == 2)
        {
            forwardCounter[2]++;
            forwardCounter[1] = 0;
            forwardCounter[3] = 0;
            forwardCounter[4] = 0;
        }
        else if (direction == lastdirection && direction == 3)
        {
            forwardCounter[3]++;
            forwardCounter[1] = 0;
            forwardCounter[2] = 0;
            forwardCounter[4] = 0;
        }
        else if (direction == lastdirection && direction == 4)
        {
            forwardCounter[4]++;
            forwardCounter[1] = 0;
            forwardCounter[2] = 0;
            forwardCounter[3] = 0;  
        }
    }



    private void PolishRooms()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            for (int p = 0; p < roomList.Count; p++)
            {
                if (i != p)
                {
                    if (roomList[i].transform.position == roomList[p].transform.position)
                    {
                        Debug.Log("Same Position!");
                        Destroy(roomList[i]);
                        roomList.RemoveAt(i);
                        PolishRooms();
                    }
                }
            }
        }
        stateCoreRooms = true;
        CoreRoomsGen();

    }

    private void CoreRoomsGen()
    {
        transform.position = originalPos;

    
    
    }








}
