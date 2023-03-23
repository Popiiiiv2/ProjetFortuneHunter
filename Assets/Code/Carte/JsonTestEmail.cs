using UnityEngine;
using System.IO;
using System.Collections.Generic;

namespace Cartes
{
    public class JsonTestEmail : MonoBehaviour
    {
        public ListeEmail emails = new ListeEmail();

        void Start()
        {
            string assetsPath = Application.dataPath;
            string jsonFilePath = assetsPath + "\\code\\jsonDonnee\\evenement.json";
            string jsonEmail = File.ReadAllText(jsonFilePath);
            Debug.Log(jsonEmail);
            emails = JsonUtility.FromJson<ListeEmail>(jsonEmail);

        }
    }
}