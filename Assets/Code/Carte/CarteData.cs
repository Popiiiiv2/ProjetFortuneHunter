namespace Cartes
{
    [System.Serializable]
    public class CarteData
    {
        public int id;
        public string description;
        public string titre;
        public string type;
        public int valeur;
        public string fichier;
        public string action;
        public int vente;

        public int getVente()
        {
            return vente;
        }
        public int getValeur()
        {
            return valeur;
        }
        public int getID()
        {
            return id;
        }

        public string getDescription()
        {
            return description;
        }

        public string getTitre()
        {
            return titre;
        }

        public string getType()
        {
            return type;
        }

        public string getFichier()
        {
            return fichier;
        }

        public string getAction()
        {
            return action;
        }
    }
}