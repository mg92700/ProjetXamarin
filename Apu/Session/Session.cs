using System;
namespace Apu.Session
{
    public class Session
    {


        private const string SESSION_SINGLETON = "SINGLETON";

        private static Session _instance = null;

        private Session()
        {
        }

        //Variables to store the data (used to be individual
        // session key/value pairs)
        string idUser = "";
        string tokenIdentification = "";

        public string IDUSER
        {
            get
            {
                return idUser;
            }
            set
            {
                idUser = value;
            }
        }

        public string getTokenIdentification
        {
            get
            {
                return tokenIdentification;
            }
            set
            {
                tokenIdentification = value;
            }
        }
    }
}
