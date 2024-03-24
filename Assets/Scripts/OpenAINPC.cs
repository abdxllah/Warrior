using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using OpenAi.Unity.V1;

public class OpenAINPC : MonoBehaviour
{

    //script to initialise openAI APIC calls
   
   public TMP_Text outputField;
   public bool inProgress;
   
   public NPCSpeech npcscript; 
    
    private Coroutine genCoroutine;
    public bool running;
    private Coroutine genCoroutineTwo;
    public GameObject panel;
    public string result = "";
    
    
        
    public void UpdateAI()
    {
        if (running){
        StopCoroutine(genCoroutine);
        Debug.Log("Coroutine stopped");
        }
    
    }
        //for crewmate API Call
     public void DoApiCompletion(string text, string character)
        {
            inProgress = true;

            if (string.IsNullOrEmpty(text))
            {
                Debug.LogError("Example requires input in input field");
                return;
            }

            Debug.Log("Performing Completion in Play Mode");

            outputField.text = "...";
            
            
            OpenAiCompleterV1.Instance.Complete(
                text,
                s => genCoroutine = StartCoroutine(TypeWriter(outputField, s, character)),
                e => genCoroutineTwo = StartCoroutine(TypeWriter(outputField, "Sorry Ingolfr, I didn't catch what you said", character))
            );

            
            
        }    

        //for classifier API call

         public void DoApiCompletionClassifier(string text)
        {

            if (string.IsNullOrEmpty(text))
            {
                Debug.LogError("Example requires input in input field");
            }

            Debug.Log("Performing Completion in Play Mode");

            outputField.text = "...";
            Debug.Log(text);
            
            StartCoroutine(Waiter(text));
            

        }   

        //coroutine to wait till API call is done
        IEnumerator Waiter(string text){
            running = true;
            string error = "";
            
            OpenAiCompleterV1.Instance.Complete(
                text,
                s => result = s,
                e => error = "error"
            );
            yield return new WaitUntil(() => result != "");
            Debug.Log(error);
            Debug.Log(result);
            running = false;
        }

      


        //Crew NPC typewriter
        public IEnumerator TypeWriter(TMP_Text field, string displayText, string person){
        running = true;
        npcscript.output = displayText;
        Debug.Log(npcscript.output);
        field.text = "";
        
        foreach (char c in person + ": " + displayText)
		    {
			field.text += c;
			yield return new WaitForSeconds(0.05f);
		    }  
        inProgress = false;
        running = false;
    }
        //clear a text field
        public void Clear(){
            outputField.text = "";
        }
}
