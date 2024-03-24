using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using XNode;
using TMPro;

public class GameWorldManager : MonoBehaviour
{
    
    //script to deal with the state of the game world
    public TensionManager tensionManager;
  
    Coroutine _parser;
    
    public TMP_Text dialogue;
    public TMP_Text importantDialogueField;
    public GameObject important;
    public GameObject importantUlf;
    public GameObject importantTrygve;
    public Image speakerImage;
    public NLPNaiveBayesClassifier script;
    public TMP_InputField field;
    public Image panel;
    public GameObject panelObject;
    public GameObject gameOverText;
    public GameObject endingText;
    public TMP_Text endingTextTMP;
    public GameObject userInputField;
    public Button clicker;
    public NPCSpeech speech;
    public Image tensionPanel;
    public float counter =1;
    public GameObject smoke;
    public bool smokeOn;
    
    
    

    private void Start(){
        //assinging all variables that need to be done
        tensionManager.AssignBeats();
        tensionManager.Current();
        smokeOn = false;
        
        foreach (BaseNode b in tensionManager.currentNode.nodes)
        {
            if (b.GetString() == "Start"){
                //make node start point
                tensionManager.currentNode.current = b;
                break;
            }
        }
        _parser = StartCoroutine(ParseNode());
    }

    IEnumerator ParseNode(){
        
        BaseNode b = tensionManager.currentNode.current;
        string data = b.GetString();
        string[] dataParts = data.Split('/');
        if (dataParts[0] == "Start"){
            NextNode("exit");
        }
        if (dataParts[0] == "DialogueNode"){

            
            
            //dialogue node processing
            foreach (char c in dataParts[1])
		    {
			dialogue.text += c;
            
			yield return new WaitForSeconds(0.06f);
		    }   
            
            
            //yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
            yield return WaitForButtonPress(clicker);
            dialogue.text = "";
            //yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
            
            
            NextNode("exit");
        }
         if (dataParts[0] == "BadDialogue"){

            tensionPanel.GetComponent<Image>();
            var temp = tensionPanel.color;
            temp.a = counter * 0.1f;
            tensionPanel.color =temp;
            counter++;
            //dialogue node processing
            foreach (char c in dataParts[1])
		    {
			dialogue.text += c;
			yield return new WaitForSeconds(0.06f);
		    }   
            
            //yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
            yield return WaitForButtonPress(clicker);
            dialogue.text = "";
            //yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
          
            
            NextNode("exit");
        }
          if (dataParts[0] == "ImportantNode"){
            dialogue.text = "";
            important.SetActive(true);
            //dialogue node processing
            if (dataParts[1] == "0"){
                importantUlf.SetActive(true);
            }else {
            if (dataParts[1] == "1"){
                importantTrygve.SetActive(true);
            }}
            foreach (char c in dataParts[2])
		    {
			importantDialogueField.text += c;
			yield return new WaitForSeconds(0.06f);
		    }   
            
            //yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            importantDialogueField.text = "";
            //yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
            importantTrygve.SetActive(false);
            importantUlf.SetActive(false);
            important.SetActive(false);
            NextNode("exit");
        }
        if (dataParts[0] == "ChoiceNode"){
            //choice node processing
           
            foreach (char c in "Begin Typing")
		    {
			dialogue.text += c;
			yield return new WaitForSeconds(0.06f);
		    }  
            userInputField.SetActive(true);
            field.ActivateInputField();
            
            script.classified = false;
            
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) && (speech.inConversation == false));
            if (SettingsVariables.onlineClassifier){
                dialogue.text = "...";
                yield return new WaitForSeconds(3f);
            }
            dialogue.text = "";
            string userResponse = script.classifiedLabel;
            script.classified = false;
            field.DeactivateInputField();
            userInputField.SetActive(false);
            Debug.Log("moving to " + userResponse);
            NextNode(userResponse);
        }
        if (dataParts[0] == "End"){
            //end node processing
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                //i changes the opacity of the panel so doesnt come up statically
                panelObject.SetActive(true);
                panel.color = new Color(0,0, 0, i);
                yield return null;
            }
            endingText.SetActive(true);
            foreach (char c in dataParts[1])
		    {
			endingTextTMP.text += c;
			yield return new WaitForSeconds(0.06f);
		    }   
            yield return new WaitForSeconds(5f);
            endingText.SetActive(false);
            yield return new WaitForSeconds(1f);
            gameOverText.SetActive(true);
            yield return new WaitForSeconds(5f);
           GameObject ocean = GameObject.FindGameObjectWithTag("OceanSound");
            Destroy(ocean);
           SceneManager.LoadScene(0);
        }

        

         if (dataParts[0] == "NextBeat"){
            //next beat processing
            int recievedTen = int.Parse(dataParts[1]);
            int recievedAff = int.Parse(dataParts[2]);
            int recievedFight = int.Parse(dataParts[3]);
            int recievedRed = int.Parse(dataParts[4]);
            if (recievedRed > 0){
            tensionPanel.GetComponent<Image>();
            var temp = tensionPanel.color;
            temp.a = counter * 0.1f;
            tensionPanel.color =temp;
            counter++;
            }
            tensionManager.CalculateNext(recievedTen, recievedAff,recievedFight, recievedRed);
             foreach (BaseNode bRepeat in tensionManager.currentNode.nodes)
            {
            if (bRepeat.GetString() == "Start"){
                //make node start point
                tensionManager.currentNode.current = bRepeat;
                break;
            }
           
            }
         NextNode("exit");
            
        }



        if (dataParts[0] == "StoryPoint"){
            //story point node processing
            if (smokeOn == false){
            smoke.SetActive(true);
            smokeOn = true;
            }else {
            if (smokeOn){
            smoke.SetActive(false);
            }}
         NextNode("exit");

            
        }
    }


    //function to find the next node that you are looking for and start the coroutine for this process
    public void NextNode(string fieldName){
        if (_parser !=null){
            StopCoroutine(_parser);
            _parser = null;
        }
        foreach (NodePort p in tensionManager.currentNode.current.Ports){
            if (p.fieldName == fieldName){
                tensionManager.currentNode.current = p.Connection.node as BaseNode;
                break;
            }
        }
        _parser = StartCoroutine(ParseNode());

    }
    
//coroutine to waitfor a button to be clicked
private IEnumerator WaitForButtonPress(Button button)
{
    bool buttonClicked = false;
    button.onClick.AddListener(() => buttonClicked = true);
    yield return new WaitUntil(() => buttonClicked);
    button.onClick.RemoveAllListeners();
     yield return null;
}
    
    
}






