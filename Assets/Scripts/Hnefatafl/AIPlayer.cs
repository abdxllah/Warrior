using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIPlayer : MonoBehaviour, IAgent
{
    public BoardManager.Team Team { get; private set; }

    public void Instantiate(BoardManager.Team team)
    {
        Team = team;
    }

    public void GetMove(MDPEnvironment e, UnityAction<Move> callback)
    {
        StartCoroutine(WaitForMove(e, callback));
       
                            
    }

    private IEnumerator WaitForMove(MDPEnvironment e, UnityAction<Move> callback)
    {
       Vector2Int notSet = new Vector2Int(-1,-1);
        Vector2Int selected = new Vector2Int(UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10));
        List<Vector2Int> moves = e.GetAllPossibleMoves(selected, out bool hasMoves);
        MDPEnvironment.Tile t = e.Environment[selected.x, selected.y];
        if (!hasMoves || !(MDPEnvironment.IsOnTeam(t, Team))){
       while((hasMoves == false || !(MDPEnvironment.IsOnTeam(t, Team)))){
       selected = new Vector2Int(UnityEngine.Random.Range(0, BoardManager.Instance.BOARD_SIZE), UnityEngine.Random.Range(0, BoardManager.Instance.BOARD_SIZE));
        t = e.Environment[selected.x, selected.y]; 
        if (MDPEnvironment.IsOnTeam(t, Team)){
        moves = e.GetAllPossibleMoves(selected, out hasMoves);}
        
       }} 
       Debug.Log(selected);
       Debug.Log(moves.Count);
       /*for (int i = 0; i < moves.Count; i++) 
        {
            
            if (e.IsValidMove(selected, moves[i])){
                Debug.Log(moves[i]);
            }
        }*/

         
          int randomIndex = UnityEngine.Random.Range(0, moves.Count);
          Vector2Int randomMove = moves[randomIndex];
        bool done = false;
        
        while (!done){
        randomIndex = UnityEngine.Random.Range(0, moves.Count);
        randomMove = moves[randomIndex];
        if (e.IsValidMove(selected, randomMove))
                        {
                          done = true;
                        }
        
        }
        done = false;
        callback.Invoke(new Move(selected, randomMove, Team));
    
        /*
        for (int i = 0; i < moves.Count; i++) 
        {
            if (e.IsValidMove(selected, moves[i]))
                        {
                          callback.Invoke(new Move(selected, moves[i], Team));
                          Debug.Log(moves[i]);
                          break;
                        }
        }*/
        
       
    yield return null;
}}
