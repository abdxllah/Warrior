using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using OpenAi.Api;
using OpenAi.Api.V1;


public class NPCSpeech : MonoBehaviour
{

    //script to toggle npc conversations on the boat and to randomise which npc is chosen
    
    public TMP_Text dialogue0;
    public TMP_InputField defaultField;
    public GameObject defaultFieldObject;
    public TMP_InputField field1;
    public OpenAINPC openai;
    public GameObject canvas;
    public bool active;
    public bool choiceNode;
    public bool inConversation;
    public string output;
    public bool closed;
    public bool running;
    public List<NPCTuple> npcs = new List<NPCTuple>();
    public NPCTuple randomNPC;
    //public SOCompletionArgsV1 apirequest;
    public NPCTuple ragnar;
    public NPCTuple frode;
    public NPCTuple bjorn;
    public NPCTuple astrid;
    public NPCTuple sven;
    public NPCTuple gunnar;
    public NPCTuple ingrid;
    public NPCTuple freyja;
    public NPCTuple hilde;
    public NPCTuple gudrid;
    public NPCTuple sigrid;
    public NPCTuple helga;
    public NPCTuple erik;
    public NPCTuple phillip;
    public NPCTuple andrew;
    
    

    // Start is called before the first frame update
    public void Start(){

        //all the random npcs that can be assigned
        //12 viking based npcs based on the fact that karvi longships would have at minimum 6 benches = 12 crewmates
        // extra 2 npcs as an easter egg :)
        ragnar = new NPCTuple("Ragnar",
                              "Ragnar: Captain! How may I help you?" ,
                              "This following is a conversation in English between Ragnar and his Captain Ingolfr Arnarson (only in plain english with correct grammar- no slang, symbols or acronyms and they should take turns speaking - there should be no repeated sentences and all the speech of one character should be on the same line and the conversation shouldn't get stuck anywhere), while on the boat to settle Iceland in the year 874(they have been on the boat for five days)- currently they do not believe there is anyone inhabiting Iceland. Ragnar was a fisherman in Norway, who hopes to find abundant fishing grounds in Iceland. He is also a skilled hunter and plans to supplement his income with hunting. He is onboard alongside his wife Gudrid. Ragnar: I am Ragnar, a Viking from Norway and I am on the way to settle Iceland for the first time alongside you, Ingolfr Arnarson and my wife Gudrid. Ingolfr: ");
        frode = new NPCTuple("Frode",
                             "Frode: Hello there Captain!" ,
                             "This is a conversation between Frode and his Captain Ingolfr Arnarson in English(only in plain english with correct grammar- no slang, symbols or acronyms and they should take turns speaking - there should be no repeated sentences and all the speech of one character should be on the same line and the conversation shouldn't get stuck anywhere), while on the boat to settle Iceland in the year 874(they have been on the boat for five days)- currently they do not believe there is anyone inhabiting Iceland.A fierce warrior and skilled shipbuilder from Sweden. He was banished from his homeland after challenging the authority of the ruling king. Frode: I am Frode, a Viking from Sweden, but I lived in Norway before coming on this journey and I am on the way to settle Iceland for the first time alongside you, Ingolfr Arnarson. I look for new lands to settle. Ingolfr: ");   
        bjorn = new NPCTuple("Bjorn",
                             "Bjorn: Ingolfr, my friend.",
                             "This following is a conversation in English between Bjorn and his Captain Ingolfr Arnarson (only in plain english with correct grammar- no slang, symbols or acronyms and they should take turns speaking - there should be no repeated sentences and all the speech of one character should be on the same line and the conversation shouldn't get stuck anywhere), while on the boat to settle Iceland in the year 874(they have been on the boat for five days)- currently they do not believe there is anyone inhabiting Iceland. Bjorn is a former chieftain who lost his lands in Norway. He is looking to start over in Iceland and is hoping to establish a new power base. Bjorn: I am Bjorn, a Viking from Norway and I am on the way to settle Iceland for the first time alongside you, Ingolfr Arnarson. I look for new lands to settle. Ingolfr: ");
        astrid = new NPCTuple("Astrid",
                             "Astrid: Ingolfr! How are you",
                             "This following is a conversation in English between Astrid and her Captain Ingolfr Arnarson (only in plain english with correct grammar- no slang, symbols or acronyms and they should take turns speaking - there should be no repeated sentences and all the speech of one character should be on the same line and the conversation shouldn't get stuck anywhere), while on the boat to settle Iceland in the year 874(they have been on the boat for five days)- currently they do not believe there is anyone inhabiting Iceland. Astrid is a Norse woman from Norway. She is a skilled weaver and seamstress, and has created many beautiful garments and tapestries. Astrid is joining the expedition to Iceland to escape a difficult marriage and to start a new life. She hopes to use her skills to create new clothing for the settlers in Iceland, and to establish herself as a respected member of the community. Astrid: I am Astrid from Norway and I am on the way to settle Iceland for the first time alongside you, Ingolfr Arnarson. Ingolfr: ");
        sven = new NPCTuple("Sven",
                            "Sven: Hail Odin!",
                            "This following is a conversation in English between Sven and his Captain Ingolfr Arnarson (only in plain english with correct grammar- no slang, symbols or acronyms and they should take turns speaking - there should be no repeated sentences and all the speech of one character should be on the same line and the conversation shouldn't get stuck anywhere), while on the boat to settle Iceland in the year 874(they have been on the boat for five days)- currently they do not believe there is anyone inhabiting Iceland. Sven is a Swedish blacksmith. He is known for his skill in forging weapons and tools, and has created many powerful weapons for his clients. Sven is joining the expedition to Iceland to escape a troubled past, and to start a new life. He hopes to use his skills to create new weapons and tools for the settlers in Iceland, and to establish himself as a respected member of the community. Sven: I am Sven from Sweden and I am on the way to settle Iceland for the first time alongside you, Ingolfr Arnarson. Ingolfr: ");
        gunnar = new NPCTuple("Gunnar",
                           "Gunnar: Ingolfr. My friend.",
                           "This following is a conversation in English between Gunnar and his Captain Ingolfr Arnarson (only in plain english with correct grammar- no slang, symbols or acronyms and they should take turns speaking - there should be no repeated sentences and all the speech of one character should be on the same line and the conversation shouldn't get stuck anywhere), while on the boat to settle Iceland in the year 874(they have been on the boat for five days)- currently they do not believe there is anyone inhabiting Iceland. Gunnar is a former member of a notorious Viking raiding party that terrorized the shores of Britain. After a particularly brutal battle, Gunnar decided to leave his life of violence behind and start anew in Iceland. He hopes to build a farm and live a peaceful life. Gunnar: I am Gunnar from Norway and I am on the way to settle Iceland for the first time alongside you, Ingolfr Arnarson. Ingolfr: ");
        ingrid = new NPCTuple("Ingrid",
                              "Ingrid: Odin is with us Ingolfr.",
                            "This following is a conversation in English between Ingrid and her Captain Ingolfr Arnarson (only in plain english with correct grammar- no slang, symbols or acronyms and they should take turns speaking - there should be no repeated sentences and all the speech of one character should be on the same line and the conversation shouldn't get stuck anywhere), while on the boat to settle Iceland in the year 874(they have been on the boat for five days)- currently they do not believe there is anyone inhabiting Iceland. Ingrid is a healer who has been traveling around Scandinavia treating people's ailments and injuries. She is looking for a new place to call home and is drawn to  the rumours of Iceland's natural hot springs and healing properties .Ingrid: I am Ingrid and I am on the way to settle Iceland for the first time alongside you, Ingolfr Arnarson, and help people. Ingolfr: ");
        freyja = new NPCTuple("Freyja",
                              "Freyja: I can't wait Ingolfr, we're nearly there.",
                               "This following is a conversation in English between Freyja and her Captain Ingolfr Arnarson (only in plain english with correct grammar- no slang, symbols or acronyms and they should take turns speaking - there should be no repeated sentences and all the speech of one character should be on the same line and the conversation shouldn't get stuck anywhere), while on the boat to settle Iceland in the year 874(they have been on the boat for five days)- currently they do not believe there is anyone inhabiting Iceland. Freyja is a young lady from Iceland who is passionate about hunting and trapping. She spends most of her time in the wilderness, tracking game and exploring the local terrain. Freyja is accompanied by his faithful hunting dog, a black Labrador named Odin. Freyja: I am Freyja and I am on the way to settle Iceland for the first time alongside you, Ingolfr Arnarson, and hunt. Ingolfr: "); 
        hilde = new NPCTuple("Hilde",
                              "Hilde: May the mead flow and the songs be loud tonight Ingolfr.",
                                "This following is a conversation in English between Hilde and her Captain Ingolfr Arnarson (only in plain english with correct grammar- no slang, symbols or acronyms and they should take turns speaking - there should be no repeated sentences and all the speech of one character should be on the same line and the conversation shouldn't get stuck anywhere), while on the boat to settle Iceland in the year 874(they have been on the boat for five days)- currently they do not believe there is anyone inhabiting Iceland. Hilde is a Viking warrior from Norway who has come to Iceland to start a new life. She is a skilled fighter and has a reputation for being fearless in battle. Hilde: I am Hilde and am on the way to settle Iceland for the first time alongside you, Ingolfr Arnarson. Ingolfr: ");
        gudrid = new NPCTuple("Gudrid",
                              "Gudrid: Ingolfr! I've never seen Ragnar so excited before.",
                              "This following is a conversation in English between Gudrid and her Captain Ingolfr Arnarson (only in plain english with correct grammar- no slang, symbols or acronyms and they should take turns speaking - there should be no repeated sentences and all the speech of one character should be on the same line and the conversation shouldn't get stuck anywhere ), while on the boat to settle Iceland in the year 874(they have been on the boat for five days)- currently they do not believe there is anyone inhabiting Iceland. Gudrid is a dairy farmer from Norway. She joined the expedition to Iceland in search of new grazing lands for her cattle. Gudrid is hardworking and no-nonsense, but also has a sense of humor. She hopes to start a successful dairy business in Iceland. She is on board alongside her husband Ragnar. Gudrid: I am Gudrid and I am on the way to settle Iceland for the first time alongside you, Ingolfr Arnarson, and my husband Ragnar. Ingolfr: ");
        sigrid = new NPCTuple("Sigrid", 
                              "Sigrid: Greetings Ingolfr.",
                              "This following is a conversation in English between Sigrid and her Captain Ingolfr Arnarson (only in plain english with correct grammar- no slang, symbols or acronyms and they should take turns speaking - there should be no repeated sentences and all the speech of one character should be on the same line and the conversation shouldn't get stuck anywhere), while on the boat to settle Iceland in the year 874(they have been on the boat for five days)- currently they do not believe there is anyone inhabiting Iceland. Sigrid is a brave and experienced sailor who has spent most of her life on ships. She is travelling to Iceland to escape a life of piracy and now works as a navigator for the settlers. She also hopes to discover new trade routes for the settlement. Sigrid: I am Sigrid and I am on the way to settle Iceland for the first time alongside you, Ingolfr Arnarson. Ingolfr: ");  
        helga = new NPCTuple("Helga",
                             "Helga: Skol!",
                            "This following is a conversation in English between Helga and her Captain Ingolfr Arnarson (only in plain english with correct grammar- no slang, symbols or acronyms and they should take turns speaking - there should be no repeated sentences and all the speech of one character should be on the same line and the conversation shouldn't get stuck anywhere), while on the boat to settle Iceland in the year 874(they have been on the boat for five days)- currently they do not believe there is anyone inhabiting Iceland. Helga is a musician who has travelled across many lands to learn different musical styles. She hopes to use her skills to bring joy to the settlers of Iceland, and to be the pioneer the island's unique musical traditions. Helga: I am Helga and I am on the way to settle Iceland for the first time alongside you, Ingolfr Arnarson. Ingolfr: ");
        erik = new NPCTuple("Erik",
                            "Erik: Good day to you!",
                            "This following is a conversation in English between Erik and his Captain Ingolfr Arnarson (only in plain english with correct grammar- no slang, symbols or acronyms and they should take turns speaking - there should be no repeated sentences and all the speech of one character should be on the same line and the conversation shouldn't get stuck anywhere), while on the boat to settle Iceland in the year 874(they have been on the boat for five days)- currently they do not believe there is anyone inhabiting Iceland. Erik is a young man from Norway who joined the expedition to Iceland to escape his abusive father. Erik is quiet and reserved, but has a strong sense of justice. He hopes to find a new sense of purpose and belonging in Iceland. Erik : I am Erik and I am on the way to settle Iceland for the first time alongside you, Ingolfr Arnarson. Ingolfr: ");
        phillip = new NPCTuple("Phillip",
                              "Phillip: Good to see you up and about today Ingolfr",
                              "This following is a conversation in English between Phillip and his Captain Ingolfr Arnarson (only in plain english with correct grammar- no slang, symbols or acronyms and they should take turns speaking - there should be no repeated sentences and all the speech of one character should be on the same line and the conversation shouldn't get stuck anywhere), while on the boat to settle Iceland in the year 874(they have been on the boat for five days)- currently they do not believe there is anyone inhabiting Iceland. Phillip is a former sailor from England. He has spent most of his life at sea and has seen his fair share of battles. He left England due to a sense of restlessness and a desire for adventure. Phillip was approached by the Vikings while he was in port in England. He saw this as an opportunity to experience a new culture and explore uncharted territory. Phillip : I am Phillip and I am on the way to settle Iceland for the first time alongside you, Ingolfr Arnarson. Ingolfr: ");   
        andrew = new NPCTuple("Andrew",
                              "Andrew: May your axe always strike true, friend",
                            "This following is a conversation in English between Andrew and his Captain Ingolfr Arnarson (only in plain english with correct grammar- no slang, symbols or acronyms and they should take turns speaking - there should be no repeated sentences and all the speech of one character should be on the same line and the conversation shouldn't get stuck anywhere), while on the boat to settle Iceland in the year 874(they have been on the boat for five days)- currently they do not believe there is anyone inhabiting Iceland. Andrew was born in England and lost his father in a battle with Vikings when he was young. He was taken in and adopted by a Viking, Ingolfr’s father’s friend, Leifur, who had a soft spot for him, and grew up as his adopted son. Despite his difficult upbringing and the animosity between the English and the Vikings, Andrew has a deep respect for his adoptive culture and its traditions, as well as Ingolfr. Andrew: I am Andrew and I am on the way to settle Iceland for the first time alongside you, my friend, Ingolfr Arnarson. Ingolfr: ");







        npcs.Add(ragnar);
        npcs.Add(frode);
        npcs.Add(bjorn);
        npcs.Add(astrid);
        npcs.Add(sven);
        npcs.Add(gunnar);
        npcs.Add(ingrid);
        npcs.Add(freyja);
        npcs.Add(hilde);
        npcs.Add(gudrid);
        npcs.Add(sigrid);
        npcs.Add(helga);
        npcs.Add(erik);
        npcs.Add(phillip);
        npcs.Add(andrew);


        //randomise chosen npc
        System.Random random = new System.Random();
        int randomIndex = random.Next(npcs.Count);
        randomNPC = npcs[randomIndex];
       // SOCompletionArgsV1.characterNeeded = (randomNPC,character + ": ");
        //apirequest.stop[1] = (randomNPC.character + ": ");


        StartCoroutine(Waiting());
        
    }

    public void Update(){
        //close the crewmate UI
        if(Input.GetKeyDown("tab")){
            closed = true;
            openai.UpdateAI();
            canvas.SetActive(false);
            active = false;
            
            dialogue0.text = "";
            field1.text = "";
            openai.Clear();
            if (choiceNode){
                defaultFieldObject.SetActive(true);
                defaultField.ActivateInputField();
            }
            inConversation = false;
            closed = false;
        };
        
        StopCoroutine(Waiting());
        

        if (canvas.activeSelf && (active == false)){
            //when reopening the crewmate UI randomise again
            System.Random random = new System.Random();
            int randomIndex = random.Next(npcs.Count);
            randomNPC = npcs[randomIndex];
           // apirequest.stop[1] = (randomNPC.character + ": ");
            StartCoroutine(Waiting());
            active = true;
           
        }
    }


    IEnumerator Waiting(){
        //coroutine to allow for user to enter input and wait for api interaction
        if(defaultFieldObject.activeSelf){
            defaultField.DeactivateInputField();
            defaultFieldObject.SetActive(false);
            choiceNode = true;
        }
        active = true;
        inConversation = true;
        foreach (char c in randomNPC.introduction)
		    {
			dialogue0.text += c;
			yield return new WaitForSeconds(0.05f);
		    }  

        while (active){
        field1.ActivateInputField();
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        string current = field1.text;
        string total = randomNPC.dialogue +  current + randomNPC.character + ": ";
        
        openai.DoApiCompletion(total, randomNPC.character);
        
        field1.text = "";
        

        
        yield return new WaitUntil(() => openai.inProgress == false);
        randomNPC.dialogue = total + output + "Ingolfr: ";
        Debug.Log(randomNPC.dialogue);
        
        }
    }

    
}

