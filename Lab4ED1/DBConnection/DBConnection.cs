using Lab4ED1.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4ED1.DBConnection
{
    public class DBConnection
    {
        private static volatile DBConnection instance;

        private static object sync = new Object();

        public Dictionary<string, StickerLists> ListadoCromos = new Dictionary<string, StickerLists>();
        public Dictionary<string, bool> EstadoCromo = new Dictionary<string, bool>();

        public static DBConnection getInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (sync)
                    {
                        if (instance == null)
                        {
                            instance = new DBConnection();
                        }
                    }
                }

                return instance;
            }

        }
    }
}