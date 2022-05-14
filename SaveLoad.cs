using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Xml;
using System.Globalization;

namespace AddSaveLoadRepeat
{
    public class SaveLoad : MonoBehaviour
    {
        [Tooltip("The required database")]
        public Database database; //the required database
        [Tooltip("Game objects and their tag names")]
        public Objects[] objects; //game objects and their tag names
        string directory = "/Data/"; //the folder with saves
        [Tooltip("The save file name")]
        public string fileName; //the save file name
        [Tooltip("The quick save key")]
        public KeyCode quickSaveKey; //the quick save key
        [Tooltip("The quick load key")]
        public KeyCode quickLoadKey; //the quick load key
        [HideInInspector] //hide the variable in the inspector
        public bool showTextSave; //the condition for displaying the save label (the text with the information in the corner of the screen that the game saved)
        [HideInInspector] //hide the variable in the inspector
        public bool showTextLoad; //the condition for displaying the load label (the text with the information in the corner of the screen that the game loaded)
        XmlDocument xmlDoc = new XmlDocument();  //the declaration of the XML document
        [HideInInspector] //hide the variable in the inspector
        public string sceneName; //the name of the scene in the save
        [Tooltip("The text with the information in the corner of the screen that the game saved")]
        public string saveText; //the text with the information in the corner of the screen that the game saved
        [Tooltip("The text with the information in the corner of the screen that the game loaded")]
        public string loadText; //the text with the information in the corner of the screen that the game loaded
        [Tooltip("The condition for displaying the loading screen")]
        public bool loadingScreen; //the condition for displaying the loading screen
        [Tooltip("The button to start the game after a screen loading")]
        public KeyCode buttonToStart; //the button to start the game after a screen loading
        [Tooltip("The background of the loading screen ")]
        public GameObject loadingScreenBackground; //the background of the loading screen
        [Tooltip("The information and/or icon of the loading screen at the start")]
        public GameObject startOfTheLoadingScreen; //the information and/or icon of the loading screen at the start
        [Tooltip("The information and/or icon of the loading screen at the end")]
        public GameObject endOfTheLoadingScreen; //the information and/or icon of the loading screen at the end

        [Serializable] //indicates that a class or a struct can be serialized
        public class Objects //game objects and their tag names
        {
            [Tooltip("The tag name of game objects")]
            public string tagName;  //the tag name of game object
            [Tooltip("Game objects that have data in the database")]
            public GameObject[] gameObjects; //game objects that have data in the database
        }

        public void Save() //the method to save data
        {
            try //an attempt to fulfill the condition
            {
                database = GameObject.Find("GameManager").GetComponent<SaveLoad>().database; //find GameManager and the database in the SaveLoad script 
            }
            catch (NullReferenceException) //if there is the NullReferenceException error
            {
#if UNITY_EDITOR //only in the editor
                Debug.Break(); //pause in the editor
#endif
                print("Add the GameManager"); //the advice in the console
            }

            if (!Directory.Exists(Application.dataPath + directory)) //if the folder with saves does not exist in the application data path
                Directory.CreateDirectory(Application.dataPath + directory); //create the folder with saves

            XmlElement elem; //the element of XML Document
            XmlNode rootNode = xmlDoc.CreateElement("Node" + SceneManager.GetActiveScene().name); //the node of XML Document
            try  //an attempt to fulfill the condition
            {
                xmlDoc.AppendChild(rootNode); //adds the specified node to the end of the list of child nodes, of this node
                rootNode.RemoveAll(); //removes all the child nodes and/or attributes of the current node
            }
            catch (InvalidOperationException) //if there is the InvalidOperationException error
            {
#if UNITY_EDITOR //only in editor
                Debug.Break(); //pause in the editor
#endif
                print("Too many saves at a time"); //the advice in the console
            }

            //save the scene name 
            elem = xmlDoc.CreateElement("sceneName"); //create the sceneName element
            XmlAttribute sceneName = xmlDoc.CreateAttribute("sceneName"); //create the sceneName attribute
            sceneName.Value = SceneManager.GetActiveScene().name; //the value is the name of the scene
            elem.SetAttributeNode(sceneName); //adds a new XmlAttribute
            rootNode.AppendChild(elem);  //adds the specified node to the end of the list of child nodes, of this node

            //save the number of game objects
            elem = xmlDoc.CreateElement("countObjects");
            XmlAttribute countObjects = xmlDoc.CreateAttribute("countObjects");
            countObjects.Value = database.objects.Length.ToString(); //the value is the number of game objects
            elem.SetAttributeNode(countObjects);
            rootNode.AppendChild(elem);

            for (int i = 0; i < database.objects.Length; i++) //the cycle within the database
            {
                //save tag names of game objects			
                elem = xmlDoc.CreateElement("tagNames" + i); //an i variable is an index number of the game object among other game objects with the same tag name
                XmlAttribute tagNames_ = xmlDoc.CreateAttribute("tagNames" + i);
                tagNames_.Value = database.objects[i].tagName;
                elem.SetAttributeNode(tagNames_);
                rootNode.AppendChild(elem);

                //save the number of health elements (game objects with health elements)
                elem = xmlDoc.CreateElement("countHealth_" + database.objects[i].tagName);
                XmlAttribute countHealth = xmlDoc.CreateAttribute("countHealth_" + database.objects[i].tagName);
                countHealth.Value = database.objects[i].health.Length.ToString();
                elem.SetAttributeNode(countHealth);
                rootNode.AppendChild(elem);

                //save the number of weapon elements (game objects with weapons)
                elem = xmlDoc.CreateElement("countWeapons_" + database.objects[i].tagName);
                XmlAttribute countWeapons = xmlDoc.CreateAttribute("countWeapons_" + database.objects[i].tagName);
                countWeapons.Value = database.objects[i].weapons.Length.ToString();
                elem.SetAttributeNode(countWeapons);
                rootNode.AppendChild(elem);

                //save weapon names
                elem = xmlDoc.CreateElement("weaponName_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].weapons.Length; j++)
                {
                    XmlAttribute weaponName = xmlDoc.CreateAttribute("weaponName_" + database.objects[i].tagName + j);
                    weaponName.Value = database.objects[i].weapons[j].weaponName;
                    elem.SetAttributeNode(weaponName);
                    rootNode.AppendChild(elem);
                }

                //save the number of game objects that have the element of cartridges in the magazine (ammunition)
                elem = xmlDoc.CreateElement("countCartridgesInTheMagazine_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].weapons.Length; j++)
                {
                    XmlAttribute countCartridgesInTheMagazine = xmlDoc.CreateAttribute("countCartridgesInTheMagazine_" + database.objects[i].tagName + "_" + database.objects[i].weapons[j].weaponName);
                    countCartridgesInTheMagazine.Value = database.objects[i].weapons[j].cartridgesInTheMagazine.Length.ToString();
                    elem.SetAttributeNode(countCartridgesInTheMagazine);
                    rootNode.AppendChild(elem);
                }

                //save the number of game objects that have the element of cartridges in the full magazine
                elem = xmlDoc.CreateElement("countCartridgesInTheFullMagazine_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].weapons.Length; j++)
                {
                    XmlAttribute countCartridgesInTheFullMagazine = xmlDoc.CreateAttribute("countCartridgesInTheFullMagazine_" + database.objects[i].tagName + "_" + database.objects[i].weapons[j].weaponName);
                    countCartridgesInTheFullMagazine.Value = database.objects[i].weapons[j].cartridgesInTheFullMagazine.Length.ToString();
                    elem.SetAttributeNode(countCartridgesInTheFullMagazine);
                    rootNode.AppendChild(elem);
                }

                //save the number of game objects that have the element of the magazine
                elem = xmlDoc.CreateElement("countMagazines_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].weapons.Length; j++)
                {
                    XmlAttribute countMagazines = xmlDoc.CreateAttribute("countMagazines_" + database.objects[i].tagName + "_" + database.objects[i].weapons[j].weaponName);
                    countMagazines.Value = database.objects[i].weapons[j].magazines.Length.ToString();
                    elem.SetAttributeNode(countMagazines);
                    rootNode.AppendChild(elem);
                }

                //save the number of game objects that have an energy
                elem = xmlDoc.CreateElement("countEnergy_" + database.objects[i].tagName);
                XmlAttribute countEnergy = xmlDoc.CreateAttribute("countEnergy_" + database.objects[i].tagName);
                countEnergy.Value = database.objects[i].energy.Length.ToString();
                elem.SetAttributeNode(countEnergy);
                rootNode.AppendChild(elem);

                //save the number of game objects that have scores
                elem = xmlDoc.CreateElement("countScores_" + database.objects[i].tagName);
                XmlAttribute countScores = xmlDoc.CreateAttribute("countScores_" + database.objects[i].tagName);
                countScores.Value = database.objects[i].scores.Length.ToString();
                elem.SetAttributeNode(countScores);
                rootNode.AppendChild(elem);

                //save the number of game objects that have a level
                elem = xmlDoc.CreateElement("countLevel_" + database.objects[i].tagName);
                XmlAttribute countLevel = xmlDoc.CreateAttribute("countLevel_" + database.objects[i].tagName);
                countLevel.Value = database.objects[i].level.Length.ToString();
                elem.SetAttributeNode(countLevel);
                rootNode.AppendChild(elem);

                //save the number of game objects that have money
                elem = xmlDoc.CreateElement("countMoney_" + database.objects[i].tagName);
                XmlAttribute countMoney = xmlDoc.CreateAttribute("countMoney_" + database.objects[i].tagName);
                countMoney.Value = database.objects[i].money.Length.ToString();
                elem.SetAttributeNode(countMoney);
                rootNode.AppendChild(elem);

                //save the number of game objects that have user elements 
                elem = xmlDoc.CreateElement("countUserElements_" + database.objects[i].tagName);
                XmlAttribute countOthers = xmlDoc.CreateAttribute("countUserElements_" + database.objects[i].tagName);
                countOthers.Value = database.objects[i].userElements.Length.ToString();
                elem.SetAttributeNode(countOthers);
                rootNode.AppendChild(elem);

                //save user elements names
                elem = xmlDoc.CreateElement("userElementsNames_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].userElements.Length; j++)
                {
                    XmlAttribute userElements = xmlDoc.CreateAttribute("userElements_" + database.objects[i].tagName + j);
                    userElements.Value = database.objects[i].userElements[j].name;
                    elem.SetAttributeNode(userElements);
                    rootNode.AppendChild(elem);
                }

                //save the number of game objects that have text values of user elements 
                elem = xmlDoc.CreateElement("countText_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].userElements.Length; j++)
                {
                    XmlAttribute countText = xmlDoc.CreateAttribute("countText_" + database.objects[i].tagName + "_" + database.objects[i].userElements[j].name);
                    countText.Value = database.objects[i].userElements[j].text.Length.ToString();
                    elem.SetAttributeNode(countText);
                    rootNode.AppendChild(elem);
                }

                //save the number of game objects that have values of user elements 
                elem = xmlDoc.CreateElement("countValues_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].userElements.Length; j++)
                {
                    XmlAttribute countValues = xmlDoc.CreateAttribute("countValues_" + database.objects[i].tagName + "_" + database.objects[i].userElements[j].name);
                    countValues.Value = database.objects[i].userElements[j].values.Length.ToString();
                    elem.SetAttributeNode(countValues);
                    rootNode.AppendChild(elem);
                }

                try //an attempt to fulfill the condition
                {
                    //save the position of game objects (XYZ-position)				
                    elem = xmlDoc.CreateElement("pos_" + database.objects[i].tagName);
                    for (int j = 0; j < objects[i].gameObjects.Length; j++)
                    {
                        XmlAttribute pos_X = xmlDoc.CreateAttribute("pos_X_" + database.objects[i].tagName + j);
                        pos_X.Value = objects[i].gameObjects[j].transform.position.x.ToString();
                        XmlAttribute pos_Y = xmlDoc.CreateAttribute("pos_Y_" + database.objects[i].tagName + j);
                        pos_Y.Value = objects[i].gameObjects[j].transform.position.y.ToString();
                        XmlAttribute pos_Z = xmlDoc.CreateAttribute("pos_Z_" + database.objects[i].tagName + j);
                        pos_Z.Value = objects[i].gameObjects[j].transform.position.z.ToString();
                        elem.SetAttributeNode(pos_X);
                        elem.SetAttributeNode(pos_Y);
                        elem.SetAttributeNode(pos_Z);
                        rootNode.AppendChild(elem);
                    }

                    //save the rotation of game objects (XYZW-rotation)
                    elem = xmlDoc.CreateElement("rotation_" + database.objects[i].tagName);
                    for (int j = 0; j < objects[i].gameObjects.Length; j++)
                    {
                        if (objects[i].gameObjects[j].transform.CompareTag("Player") && objects[i].gameObjects[j].transform.Find(Camera.main.name)) //if the game object has the "Player" tag and the main camera, rotation of the game object and camera is saved
                        {
                            XmlAttribute rotation_X = xmlDoc.CreateAttribute("rotation_X_" + database.objects[i].tagName + j);
                            rotation_X.Value = Camera.main.transform.rotation.x.ToString();
                            XmlAttribute rotation_Y = xmlDoc.CreateAttribute("rotation_Y_" + database.objects[i].tagName + j);
                            rotation_Y.Value = Camera.main.transform.rotation.y.ToString();
                            XmlAttribute rotation_Z = xmlDoc.CreateAttribute("rotation_Z_" + database.objects[i].tagName + j);
                            rotation_Z.Value = Camera.main.transform.rotation.z.ToString();
                            XmlAttribute rotation_W = xmlDoc.CreateAttribute("rotation_W_" + database.objects[i].tagName + j);
                            rotation_W.Value = Camera.main.transform.rotation.w.ToString();
                            elem.SetAttributeNode(rotation_X);
                            elem.SetAttributeNode(rotation_Y);
                            elem.SetAttributeNode(rotation_Z);
                            elem.SetAttributeNode(rotation_W);
                            rootNode.AppendChild(elem);
                        }
                        else //else only rotation of the game object is saved
                        {
                            XmlAttribute rotation_X = xmlDoc.CreateAttribute("rotation_X_" + database.objects[i].tagName + j);
                            rotation_X.Value = objects[i].gameObjects[j].transform.rotation.x.ToString();
                            XmlAttribute rotation_Y = xmlDoc.CreateAttribute("rotation_Y_" + database.objects[i].tagName + j);
                            rotation_Y.Value = objects[i].gameObjects[j].transform.rotation.y.ToString();
                            XmlAttribute rotation_Z = xmlDoc.CreateAttribute("rotation_Z_" + database.objects[i].tagName + j);
                            rotation_Z.Value = objects[i].gameObjects[j].transform.rotation.z.ToString();
                            XmlAttribute rotation_W = xmlDoc.CreateAttribute("rotation_W_" + database.objects[i].tagName + j);
                            rotation_W.Value = objects[i].gameObjects[j].transform.rotation.w.ToString();
                            elem.SetAttributeNode(rotation_X);
                            elem.SetAttributeNode(rotation_Y);
                            elem.SetAttributeNode(rotation_Z);
                            elem.SetAttributeNode(rotation_W);
                            rootNode.AppendChild(elem);
                        }
                    }

                    //save the scale of game objects (XYZ-scale)
                    elem = xmlDoc.CreateElement("scale_" + database.objects[i].tagName);
                    for (int j = 0; j < objects[i].gameObjects.Length; j++)
                    {
                        XmlAttribute scale_X = xmlDoc.CreateAttribute("scale_X_" + database.objects[i].tagName + j);
                        scale_X.Value = objects[i].gameObjects[j].transform.localScale.x.ToString();
                        XmlAttribute scale_Y = xmlDoc.CreateAttribute("scale_Y_" + database.objects[i].tagName + j);
                        scale_Y.Value = objects[i].gameObjects[j].transform.localScale.y.ToString();
                        XmlAttribute scale_Z = xmlDoc.CreateAttribute("scale_Z_" + database.objects[i].tagName + j);
                        scale_Z.Value = objects[i].gameObjects[j].transform.localScale.z.ToString();
                        elem.SetAttributeNode(scale_X);
                        elem.SetAttributeNode(scale_Y);
                        elem.SetAttributeNode(scale_Z);
                        rootNode.AppendChild(elem);
                    }
                }
                catch (NullReferenceException)  //if there is the NullReferenceException error
                {
#if UNITY_EDITOR //only in the editor
                    Debug.Break(); //pause in the editor
#endif
                    print("Add a game object to the GameManager"); //the advice in the console
                }

                //save health points of the game object
                elem = xmlDoc.CreateElement("health_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].health.Length; j++)
                {
                    XmlAttribute health = xmlDoc.CreateAttribute("health_" + database.objects[i].tagName + j);
                    health.Value = database.objects[i].health[j].ToString();
                    elem.SetAttributeNode(health);
                    rootNode.AppendChild(elem);
                }

                //save the number of cartridges in the magazine
                elem = xmlDoc.CreateElement("cartridgesInTheMagazine_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].weapons.Length; j++)
                    for (int n = 0; n < database.objects[i].weapons[j].cartridgesInTheMagazine.Length; n++)
                    {
                        XmlAttribute cartridgesInTheMagazine = xmlDoc.CreateAttribute("cartridgesInTheMagazine_" + database.objects[i].weapons[j].weaponName + n);
                        cartridgesInTheMagazine.Value = database.objects[i].weapons[j].cartridgesInTheMagazine[n].ToString();
                        elem.SetAttributeNode(cartridgesInTheMagazine);
                        rootNode.AppendChild(elem);
                    }

                //save the number of cartridges in the full magazine
                elem = xmlDoc.CreateElement("cartridgesInTheFullMagazine_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].weapons.Length; j++)
                    for (int n = 0; n < database.objects[i].weapons[j].cartridgesInTheFullMagazine.Length; n++)
                    {
                        XmlAttribute cartridgesInTheFullMagazine = xmlDoc.CreateAttribute("cartridgesInTheFullMagazine_" + database.objects[i].weapons[j].weaponName + n);
                        cartridgesInTheFullMagazine.Value = database.objects[i].weapons[j].cartridgesInTheFullMagazine[n].ToString();
                        elem.SetAttributeNode(cartridgesInTheFullMagazine);
                        rootNode.AppendChild(elem);
                    }

                //save the number of magazines
                elem = xmlDoc.CreateElement("magazines_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].weapons.Length; j++)
                    for (int n = 0; n < database.objects[i].weapons[j].magazines.Length; n++)
                    {
                        XmlAttribute magazines = xmlDoc.CreateAttribute("magazines_" + database.objects[i].weapons[j].weaponName + n);
                        magazines.Value = database.objects[i].weapons[j].magazines[n].ToString();
                        elem.SetAttributeNode(magazines);
                        rootNode.AppendChild(elem);
                    }

                //save energy points of the game object
                elem = xmlDoc.CreateElement("energy_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].energy.Length; j++)
                {
                    XmlAttribute energy = xmlDoc.CreateAttribute("energy_" + database.objects[i].tagName + j);
                    energy.Value = database.objects[i].energy[j].ToString();
                    elem.SetAttributeNode(energy);
                    rootNode.AppendChild(elem);
                }

                //save scores of the game object
                elem = xmlDoc.CreateElement("scores_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].scores.Length; j++)
                {
                    XmlAttribute scores = xmlDoc.CreateAttribute("scores_" + database.objects[i].tagName + j);
                    scores.Value = database.objects[i].scores[j].ToString();
                    elem.SetAttributeNode(scores);
                    rootNode.AppendChild(elem);
                }

                //save level of the game object
                elem = xmlDoc.CreateElement("level_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].level.Length; j++)
                {
                    XmlAttribute level = xmlDoc.CreateAttribute("level_" + database.objects[i].tagName + j);
                    level.Value = database.objects[i].level[j].ToString();
                    elem.SetAttributeNode(level);
                    rootNode.AppendChild(elem);
                }

                //save money of the game object
                elem = xmlDoc.CreateElement("money_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].money.Length; j++)
                {
                    XmlAttribute money = xmlDoc.CreateAttribute("money_" + database.objects[i].tagName + j);
                    money.Value = database.objects[i].money[j].ToString();
                    elem.SetAttributeNode(money);
                    rootNode.AppendChild(elem);
                }

                //save the text value of the user element of the game object
                elem = xmlDoc.CreateElement("userElements_Text_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].userElements.Length; j++)
                    for (int n = 0; n < database.objects[i].userElements[j].text.Length; n++)
                    {
                        XmlAttribute others0 = xmlDoc.CreateAttribute("userElements_Text_" + database.objects[i].userElements[j].name + n);
                        others0.Value = database.objects[i].userElements[j].text[n].ToString();
                        elem.SetAttributeNode(others0);
                        rootNode.AppendChild(elem);
                    }

                //save the value of the user element of the game object
                elem = xmlDoc.CreateElement("userElements_Values_" + database.objects[i].tagName);
                for (int j = 0; j < database.objects[i].userElements.Length; j++)
                    for (int n = 0; n < database.objects[i].userElements[j].values.Length; n++)
                    {
                        XmlAttribute others1 = xmlDoc.CreateAttribute("userElements_Values_" + database.objects[i].userElements[j].name + n);
                        others1.Value = database.objects[i].userElements[j].values[n].ToString();
                        elem.SetAttributeNode(others1);
                        rootNode.AppendChild(elem);
                    }
            }

            FileStream file = new FileStream(Application.dataPath + directory + fileName + ".xml", FileMode.Create, FileAccess.Write); //the file is created
            xmlDoc.Save(file); //the file is saved

            try
            {
                xmlDoc.RemoveChild(rootNode); //removes specified child node
            }
            catch (ArgumentException) //if there is the ArgumentException error
            {
#if UNITY_EDITOR //only in editor
                Debug.Break(); //pause in the editor
#endif
                print("Too many saves at a time"); //the advice in the console
            }
        }

        public void Load() //the method to load data
        {
            if (Directory.Exists(Application.dataPath + directory)) //if the folder with saves exists in the application data path
            {
                string path = Application.dataPath + directory + fileName + ".xml"; //the path to the save file
                string txtPath = Application.dataPath + directory + fileName + ".txt"; //the path to the TXT save file

                if (File.Exists(path)) //if save file exists
                {
                    XmlTextReader reader = new XmlTextReader(path); //represents a reader that provides fast, non-cached, forward-only access to XML data

                    while (reader.Read()) //file reading
                    {
                        if (reader.IsStartElement("sceneName")) //the search of the scene name
                            sceneName = reader.GetAttribute("sceneName"); //get scene name
                        LoadManager.Load.sceneName = sceneName; //set the scene name with the class for storing variables

                        try //an attempt to fulfill the condition
                        {
                            if (reader.IsStartElement("countObjects")) //the search of the number of game objects
                            {
                                database.objects = new Database.Objects[int.Parse(reader.GetAttribute("countObjects"))]; //define the number of game objects
                                for (int i = 0; i < database.objects.Length; i++)   //the cycle within the number of game objects
                                    database.objects[i] = new Database.Objects(); //game objects declaration
                                Array.Resize(ref database.objects, int.Parse(reader.GetAttribute("countObjects"))); //change the number of objects in the database
                            }

                            for (int i = 0; i < database.objects.Length; i++) //the cycle within the number of game objects
                            {
                                if (reader.IsStartElement("tagNames" + i)) //the search of tag names
                                    database.objects[i].tagName = reader.GetAttribute("tagNames" + i); //change tag names in the database

                                if (reader.IsStartElement("countHealth_" + database.objects[i].tagName)) //the search of the number of health elements
                                    Array.Resize(ref database.objects[i].health, int.Parse(reader.GetAttribute("countHealth_" + database.objects[i].tagName))); //change the number of health elements in the database

                                if (reader.IsStartElement("countWeapons_" + database.objects[i].tagName)) //the search of the number of weapon elements
                                {
                                    database.objects[i].weapons = new Database.Objects.Weapons[int.Parse(reader.GetAttribute("countWeapons_" + database.objects[i].tagName))];  //define the number of weapons
                                    for (int j = 0; j < database.objects[i].weapons.Length; j++) //the cycle within the number of weapons
                                        database.objects[i].weapons[j] = new Database.Objects.Weapons(); //weapons declaration
                                    Array.Resize(ref database.objects[i].weapons, int.Parse(reader.GetAttribute("countWeapons_" + database.objects[i].tagName))); //change the number of weapons in the database
                                }

                                if (reader.IsStartElement("weaponName_" + database.objects[i].tagName)) //the search of weapon names
                                    for (int j = 0; j < database.objects[i].weapons.Length; j++) //the cycle within the number of weapons
                                        database.objects[i].weapons[j].weaponName = reader.GetAttribute("weaponName_" + database.objects[i].tagName + j); //change weapon names

                                if (reader.IsStartElement("countCartridgesInTheMagazine_" + database.objects[i].tagName))  //the search of the number of elements of cartridges in the magazine
                                    for (int j = 0; j < database.objects[i].weapons.Length; j++) //the cycle within the number of weapons
                                        Array.Resize(ref database.objects[i].weapons[j].cartridgesInTheMagazine, int.Parse(reader.GetAttribute("countCartridgesInTheMagazine_" + database.objects[i].tagName + "_" + database.objects[i].weapons[j].weaponName))); //change the number of elements of cartridges in the magazine in the database

                                if (reader.IsStartElement("countCartridgesInTheFullMagazine_" + database.objects[i].tagName)) //the search of the number of elements of cartridges in the full magazine
                                    for (int j = 0; j < database.objects[i].weapons.Length; j++) //the cycle within the number of weapons
                                        Array.Resize(ref database.objects[i].weapons[j].cartridgesInTheFullMagazine, int.Parse(reader.GetAttribute("countCartridgesInTheFullMagazine_" + database.objects[i].tagName + "_" + database.objects[i].weapons[j].weaponName))); //change the number of elements of cartridges in the full magazine in the database

                                if (reader.IsStartElement("countMagazines_" + database.objects[i].tagName))  //the search of the number of elements of magazines
                                    for (int j = 0; j < database.objects[i].weapons.Length; j++) //the cycle within the number of weapons
                                        Array.Resize(ref database.objects[i].weapons[j].magazines, int.Parse(reader.GetAttribute("countMagazines_" + database.objects[i].tagName + "_" + database.objects[i].weapons[j].weaponName))); //change the number of elements of magazines in the database

                                if (reader.IsStartElement("countEnergy_" + database.objects[i].tagName)) //the search of the number of game objects that have an energy
                                    Array.Resize(ref database.objects[i].energy, int.Parse(reader.GetAttribute("countEnergy_" + database.objects[i].tagName))); //change the number of game objects that have an energy in the database

                                if (reader.IsStartElement("countScores_" + database.objects[i].tagName)) //the search of the number of game objects that have scores
                                    Array.Resize(ref database.objects[i].scores, int.Parse(reader.GetAttribute("countScores_" + database.objects[i].tagName))); //change the number of game objects that have scores in the database

                                if (reader.IsStartElement("countLevel_" + database.objects[i].tagName)) //the search of the number of game objects that have a level
                                    Array.Resize(ref database.objects[i].level, int.Parse(reader.GetAttribute("countLevel_" + database.objects[i].tagName))); //change the number of game objects that have a level in the database

                                if (reader.IsStartElement("countMoney_" + database.objects[i].tagName)) //the search of the number of game objects that have money
                                    Array.Resize(ref database.objects[i].money, int.Parse(reader.GetAttribute("countMoney_" + database.objects[i].tagName))); //change the number of game objects that have money in the database

                                if (reader.IsStartElement("countUserElements_" + database.objects[i].tagName)) //the search of the number game objects that have user elements
                                {
                                    database.objects[i].userElements = new Database.Objects.UserElements[int.Parse(reader.GetAttribute("countUserElements_" + database.objects[i].tagName))]; //define the number of user elements
                                    for (int j = 0; j < database.objects[i].userElements.Length; j++) //the cycle within the number of user elements
                                        database.objects[i].userElements[j] = new Database.Objects.UserElements(); //user elements declaration
                                    Array.Resize(ref database.objects[i].userElements, int.Parse(reader.GetAttribute("countUserElements_" + database.objects[i].tagName)));  //change the number of game objects that have user elements in the database
                                }

                                if (reader.IsStartElement("userElementsNames_" + database.objects[i].tagName)) //the search of the number of game objects that have user elements names
                                    for (int j = 0; j < database.objects[i].userElements.Length; j++) //the cycle within the number of user elements
                                        database.objects[i].userElements[j].name = reader.GetAttribute("userElements_" + database.objects[i].tagName + j); //change user elements names in the database

                                if (reader.IsStartElement("countText_" + database.objects[i].tagName)) //the search of the number of game objects that have text value of user elements
                                    for (int j = 0; j < database.objects[i].userElements.Length; j++) //the cycle within the number of user elements
                                        Array.Resize(ref database.objects[i].userElements[j].text, int.Parse(reader.GetAttribute("countText_" + database.objects[i].tagName + "_" + database.objects[i].userElements[j].name))); //change the number of game objects that have text value of user elements in the database

                                if (reader.IsStartElement("countValues_" + database.objects[i].tagName)) //the search of the number of game objects that have value of user elements
                                    for (int j = 0; j < database.objects[i].userElements.Length; j++) //the cycle within the number of user elements
                                        Array.Resize(ref database.objects[i].userElements[j].values, int.Parse(reader.GetAttribute("countValues_" + database.objects[i].tagName + "_" + database.objects[i].userElements[j].name))); //change the number of game objects that have value of user elements in the database

                                if (reader.IsStartElement("pos_" + database.objects[i].tagName)) //the search of game objects position
                                    for (int j = 0; j < objects[i].gameObjects.Length; j++) //the cycle within the number of game objects
                                        objects[i].gameObjects[j].transform.position = new Vector3(float.Parse(reader.GetAttribute("pos_X_" + database.objects[i].tagName + j)), float.Parse(reader.GetAttribute("pos_Y_" + database.objects[i].tagName + j)), float.Parse(reader.GetAttribute("pos_Z_" + database.objects[i].tagName + j))); //change game objects position

                                if (reader.IsStartElement("rotation_" + database.objects[i].tagName)) //the search of game objects rotation
                                    for (int j = 0; j < objects[i].gameObjects.Length; j++) //the cycle within the number of game objects
                                    {
                                        if (objects[i].gameObjects[j].transform.CompareTag("Player") && objects[i].gameObjects[j].transform.Find(Camera.main.name)) //if game objects have the "Player" tag and the main camera
                                            Camera.main.transform.rotation = new Quaternion(float.Parse(reader.GetAttribute("rotation_X_" + database.objects[i].tagName + j)), float.Parse(reader.GetAttribute("rotation_Y_" + database.objects[i].tagName + j)), float.Parse(reader.GetAttribute("rotation_Z_" + database.objects[i].tagName + j)), float.Parse(reader.GetAttribute("rotation_W_" + database.objects[i].tagName + j))); //change game objects camera rotation
                                        else
                                            objects[i].gameObjects[j].transform.rotation = new Quaternion(float.Parse(reader.GetAttribute("rotation_X_" + database.objects[i].tagName + j)), float.Parse(reader.GetAttribute("rotation_Y_" + database.objects[i].tagName + j)), float.Parse(reader.GetAttribute("rotation_Z_" + database.objects[i].tagName + j)), float.Parse(reader.GetAttribute("rotation_W_" + database.objects[i].tagName + j))); //change game objects rotation
                                    }

                                if (reader.IsStartElement("scale_" + database.objects[i].tagName)) //the search of game objects scale
                                    for (int j = 0; j < objects[i].gameObjects.Length; j++) //the cycle within the number of game objects
                                        objects[i].gameObjects[j].transform.localScale = new Vector3(float.Parse(reader.GetAttribute("scale_X_" + database.objects[i].tagName + j)), float.Parse(reader.GetAttribute("scale_Y_" + database.objects[i].tagName + j)), float.Parse(reader.GetAttribute("scale_Z_" + database.objects[i].tagName + j))); //change game objects scale

                                if (reader.IsStartElement("health_" + database.objects[i].tagName)) //the search of game objects health elements
                                    for (int j = 0; j < database.objects[i].health.Length; j++) //the cycle within the number of health elements
                                        database.objects[i].health[j] = float.Parse(reader.GetAttribute("health_" + database.objects[i].tagName + j)); //change values of health elements

                                if (reader.IsStartElement("cartridgesInTheMagazine_" + database.objects[i].tagName)) //the search of elements of cartridges in magazines of weapons of game objects 
                                    for (int j = 0; j < database.objects[i].weapons.Length; j++) //the cycle within the number of weapons
                                        for (int n = 0; n < database.objects[i].weapons[j].cartridgesInTheMagazine.Length; n++) //the cycle within the number of elements of cartridges in magazines
                                            database.objects[i].weapons[j].cartridgesInTheMagazine[n] = float.Parse(reader.GetAttribute("cartridgesInTheMagazine_" + database.objects[i].weapons[j].weaponName + n)); //change values of cartridges in magazines

                                if (reader.IsStartElement("cartridgesInTheFullMagazine_" + database.objects[i].tagName)) //the search of elements of cartridges in full magazines of weapons of game objects 
                                    for (int j = 0; j < database.objects[i].weapons.Length; j++) //the cycle within the number of weapons
                                        for (int n = 0; n < database.objects[i].weapons[j].cartridgesInTheFullMagazine.Length; n++) //the cycle within the number of elements of cartridges in full magazines
                                            database.objects[i].weapons[j].cartridgesInTheFullMagazine[n] = float.Parse(reader.GetAttribute("cartridgesInTheFullMagazine_" + database.objects[i].weapons[j].weaponName + n));  //change values of cartridges in full magazines

                                if (reader.IsStartElement("magazines_" + database.objects[i].tagName)) //the search of elements of weapons magazines of game objects 
                                    for (int j = 0; j < database.objects[i].weapons.Length; j++) //the cycle within the number of weapons
                                        for (int n = 0; n < database.objects[i].weapons[j].magazines.Length; n++) //the cycle within the number of elements of magazines
                                            database.objects[i].weapons[j].magazines[n] = float.Parse(reader.GetAttribute("magazines_" + database.objects[i].weapons[j].weaponName + n));  //change the number of magazines of weapons

                                if (reader.IsStartElement("energy_" + database.objects[i].tagName)) //the search of energy elements of game objects 
                                    for (int j = 0; j < database.objects[i].energy.Length; j++) //the cycle within the number of energy elements
                                        database.objects[i].energy[j] = float.Parse(reader.GetAttribute("energy_" + database.objects[i].tagName + j)); //change values of energy elements

                                if (reader.IsStartElement("scores_" + database.objects[i].tagName)) //the search of game objects scores
                                    for (int j = 0; j < database.objects[i].scores.Length; j++) //the cycle within the number of scores elements
                                        database.objects[i].scores[j] = float.Parse(reader.GetAttribute("scores_" + database.objects[i].tagName + j)); //change scores

                                if (reader.IsStartElement("level_" + database.objects[i].tagName)) //the search of game objects level
                                    for (int j = 0; j < database.objects[i].level.Length; j++) //the cycle within the number of level elements
                                        database.objects[i].level[j] = float.Parse(reader.GetAttribute("level_" + database.objects[i].tagName + j)); //change level

                                if (reader.IsStartElement("money_" + database.objects[i].tagName)) //the search of game objects money
                                    for (int j = 0; j < database.objects[i].money.Length; j++) //the cycle within the number of  money elements
                                        database.objects[i].money[j] = float.Parse(reader.GetAttribute("money_" + database.objects[i].tagName + j)); //change values of money

                                if (reader.IsStartElement("userElements_Text_" + database.objects[i].tagName)) //the search of text values elements of game objects
                                    for (int j = 0; j < database.objects[i].userElements.Length; j++) //the cycle within the number of user elements
                                        for (int n = 0; n < database.objects[i].userElements[j].text.Length; n++) //the cycle within the number of text values of user elements
                                            database.objects[i].userElements[j].text[n] = reader.GetAttribute("userElements_Text_" + database.objects[i].userElements[j].name + n); //change text values of user elements

                                if (reader.IsStartElement("userElements_Values_" + database.objects[i].tagName)) //the search of values elements of game objects
                                    for (int j = 0; j < database.objects[i].userElements.Length; j++) //the cycle within the number of user elements
                                        for (int n = 0; n < database.objects[i].userElements[j].values.Length; n++) //the cycle within the number of values of user elements
                                            database.objects[i].userElements[j].values[n] = float.Parse(reader.GetAttribute("userElements_Values_" + database.objects[i].userElements[j].name + n)); //change values of user elements
                            }
                        }
                        catch { } //if there is an error, then do nothing
                    }
                    reader.Close(); //end of file reading
                }
            }
        }

        void Awake() //Awake is used to initialize any variables or game state before the game starts
        {
            try //an attempt to fulfill the condition
            {
                database = GameObject.Find("GameManager").GetComponent<SaveLoad>().database; //find GameManager and the database in the SaveLoad script
            }
            catch (NullReferenceException) //if there is the NullReferenceException error
            {
#if UNITY_EDITOR //only in the editor
                Debug.Break(); //pause in the editor
#endif
                print("Add the GameManager"); //the advice in the console
            }

#if UNITY_EDITOR  //only in editor
            if (UnityEditor.EditorApplication.isPlaying == true && SceneManager.GetActiveScene().name == LoadManager.Load.sceneName && LoadManager.Load.sceneLoader == true) //if the editor is playing, the current scene is the scene in the save and the boolean variable indicates that the scene should be loaded
            {
                LoadManager.Load.sceneLoader = false; //uncheck the boolean variable in the class for storing variables that the scene needs to be loaded
                StartCoroutine(TimeLoad()); //start a Coroutine that shows text with information that the game loaded in the corner of the screen
                Load(); //load the game

            }
#endif

#if UNITY_STANDALONE //only in builds
            if (SceneManager.GetActiveScene().name == LoadManager.Load.sceneName && LoadManager.Load.sceneLoader == true) //if the current scene is the scene in the save and the boolean variable indicates that the scene should be loaded
            {
                LoadManager.Load.sceneLoader = false; //uncheck the boolean variable in the class for storing variables that the scene needs to be loaded
                StartCoroutine(TimeLoad()); //start a Coroutine that shows text with information that the game loaded in the corner of the screen
                Load(); //load the game
            }
#endif
        }

        void Update() //update is called every frame, if the MonoBehaviour is enabled
        {
            try //an attempt to fulfill the condition
            {
                if (Input.GetKeyDown(quickSaveKey)) //if the quick save button was pressed
                {
                    if (Time.timeScale != 0 && showTextSave == false) //if the game is not paused and a saving was completed
                    {
                        Save(); //save the game
                        StartCoroutine(TimeSave()); //start a Coroutine that shows text with information that the game saved in the corner of the screen
                        if (showTextLoad == true) //if information that the game loaded is being shown 
                            showTextLoad = false; //not show information
                    }
                    string quickSaveName = "QuickSave " + DateTime.Now; //the name of the file with date and time
                    string gameSaves = Application.dataPath + "/Data/" + "quickSave.xml"; //the path to the file

                    if (!Directory.Exists(Application.dataPath + directory)) //if the folder with saves does not exist in the application data path
                        Directory.CreateDirectory(Application.dataPath + directory); //create the folder with saves

                    XmlElement elem; //the element of XML Document
                    XmlNode rootNode = xmlDoc.CreateElement("Node" + SceneManager.GetActiveScene().name); //the node of XML Document
                    try  //an attempt to fulfill the condition
                    {
                        xmlDoc.AppendChild(rootNode); //adds the specified node to the end of the list of child nodes, of this node
                        rootNode.RemoveAll(); //removes all the child nodes and/or attributes of the current node
                    }
                    catch (InvalidOperationException) //if there is the InvalidOperationException error
                    {
#if UNITY_EDITOR //only in editor
                        Debug.Break(); //pause in the editor
#endif
                        print("Too many saves at a time"); //the advice in the console
                    }

                    //save the Quick Save Name
                    elem = xmlDoc.CreateElement("quickSaveName"); //create the quickSaveName element
                    XmlAttribute saveName = xmlDoc.CreateAttribute("quickSaveName"); //create the quickSaveName attribute  
                    saveName.Value = quickSaveName; //the value is the name of the file with date and time
                    elem.SetAttributeNode(saveName);
                    rootNode.AppendChild(elem);

                    FileStream file = new FileStream(gameSaves, FileMode.Create, FileAccess.Write); //the file is created
                    xmlDoc.Save(file); //the file is saved
                    try  //an attempt to fulfill the condition
                    {
                        xmlDoc.RemoveChild(rootNode); //removes specified child node
                    }
                    catch (ArgumentOutOfRangeException) //if there is the ArgumentOutOfRangeException error
                    {
#if UNITY_EDITOR //only in editor
                        Debug.Break(); //pause in the editor
#endif
                        print("Too many saves at a time"); //the advice in the console
                    }
                    catch (ArgumentException) //if there is the ArgumentException error
                    {
#if UNITY_EDITOR //only in editor
                        Debug.Break(); //pause in the editor
#endif
                        print("Too many saves at a time"); //the advice in the console
                    }
                }

                if (Input.GetKeyDown(quickLoadKey)) //if the quick laod button was pressed
                {
                    if (Time.timeScale != 0) //if the game is not paused
                    {
                        if (loadingScreen == false)  //if the game does not have a loading screen
                            StartCoroutine(TimeLoad()); //start a Coroutine that shows text with information that the game loaded in the corner of the screen

                        if (showTextSave == true) //if information that the game saved is being shown 
                            showTextSave = false;  //not show information

                        string path = Application.dataPath + directory + fileName + ".xml"; //the path to the save file

                        if (File.Exists(path)) //if save file exists
                        {
                            XmlTextReader reader = new XmlTextReader(path);  //represents a reader that provides fast, non-cached, forward-only access to XML data
                            while (reader.Read()) //file reading
                            {
                                if (reader.IsStartElement("sceneName")) //the search of the scene name
                                    sceneName = reader.GetAttribute("sceneName"); //get scene name
                            }
                            reader.Close(); //end of file reading
                        }

                        LoadManager.Load.sceneName = sceneName; //set a scene name in the class for storing variables

                        if (SceneManager.GetActiveScene().name != sceneName || loadingScreen == true) //if the current scene is not the scene in the save and the game has a loading screen
                        {
                            if (sceneName == "") //if the sceneName is empty
                            {
#if UNITY_EDITOR //only in the editor
                                Debug.Break(); //pause in the editor
#endif
                                print("Check saves"); //the advice in the console
                            }

                            else
                            {
                                StartCoroutine(LoadScene()); //start a Coroutine that loads a level
                                LoadManager.Load.sceneLoader = true; //set the boolean variable with the class for storing variables that the scene should be loaded
                            }
                        }

                        Load(); //load the game
                    }
                }
            }
            catch (IOException) //if there is an IOException error
            {
#if UNITY_EDITOR //only in editor
                Debug.Break(); //pause in the editor
#endif
                print("Too many saves at a time or very fast loading key press"); //the advice in the console
            }
        }

        IEnumerator TimeSave() //start a Coroutine that shows text with information that the game saved in the corner of the screen
        {
            showTextSave = true;  //the information that the game saved is being shown 
            yield return new WaitForSecondsRealtime(3); //waits 3 seconds
            showTextSave = false; //not show information
        }
        IEnumerator TimeLoad() //start a Coroutine that shows text with information that the game loaded in the corner of the screen
        {
            showTextLoad = true; //the information that the game loaded is being shown 
            yield return new WaitForSecondsRealtime(3); //waits 3 seconds
            showTextLoad = false;  //not show information
        }

        IEnumerator LoadScene() //start a Coroutine that loads the scene
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName); //asynchronous operation coroutine

            while (!asyncLoad.isDone) //while asyncLoad is not done
            {
                if (loadingScreen == true) //if the loading screen is displayed
                {
                    try  //an attempt to fulfill the condition
                    {
                        asyncLoad.allowSceneActivation = false; //not allow scene activation
                        Cursor.visible = false; //the cursor is not visible
                        Time.timeScale = 0; //the game is basically paused
                        showTextLoad = false; //not show information

                        loadingScreenBackground.SetActive(true); //the background of the loading screen is activated
                        startOfTheLoadingScreen.SetActive(true); //the information and/or icon are activated
                        endOfTheLoadingScreen.SetActive(false); //the information and/or icon are not activated

                        if (asyncLoad.progress >= 0.9f) //if the progress of the loading is more than 0.9
                        {
                            loadingScreenBackground.SetActive(true); //the background of the loading screen is activated
                            startOfTheLoadingScreen.SetActive(false); //the information and/or icon are not activated
                            endOfTheLoadingScreen.SetActive(true); //the information and/or icon are activated

                            if (Input.GetKeyDown(buttonToStart)) //the button to start the game after a screen loading is pressed
                            {
                                asyncLoad.allowSceneActivation = true; //allow scene activation
                                Time.timeScale = 1; //the game resumes

                                if (asyncLoad.progress == 1) //if the progress of the loading is 1
                                {
                                    loadingScreenBackground.SetActive(false); //the background of the loading screen is not activated
                                    startOfTheLoadingScreen.SetActive(false); //the information and/or icon are not activated
                                    endOfTheLoadingScreen.SetActive(false); //the information and/or icon is are activated
                                }
                            }
                        }
                    }
                    catch (NullReferenceException) //if there is the NullReferenceException error
                    {
#if UNITY_EDITOR //only in the editor
                        Debug.Break(); //pause in the editor
#endif
                        print("Add the GameManager"); //the advice in the console
                    }
                    catch (UnassignedReferenceException) //if there is the UnassignedReferenceException error
                    {
#if UNITY_EDITOR //only in the editor
                        Debug.Break(); //pause in the editor
#endif
                        print("Add loading screen objects"); //the advice in the console
                    }
                }

                yield return null; //defines the returned element (instructs to wait until the next frame before continuing)
            }
        }

        void OnGUI() //OnGUI is called for rendering and handling GUI events
        {
            GUIStyle style = new GUIStyle(); //styling information for GUI elements
            style.normal.textColor = Color.black; //add a black color to the GUI
            if (showTextSave == true) //if information that the game saved is being shown 
                GUI.Label(new Rect(5, 5, 1, 1), new GUIContent(saveText), style); //make a text label on the screen that the game saved
            if (showTextLoad == true) //if information that the game loaded is being shown 
                GUI.Label(new Rect(5, 5, 1, 1), new GUIContent(loadText), style); //make a text label on the screen that the game loaded
        }
    }

    class LoadManager //class for storing variables
    {
        public static LoadManager Load = new LoadManager(); //declare a static member for reference by the class name

        public bool sceneLoader; //the boolean variable indicates that the scene should be loaded
        public string sceneName; //the name of the scene in the save
    }
}
