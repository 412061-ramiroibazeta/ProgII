using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Xml.Linq;
using TemperaturaAPI.Models;

namespace TemperaturaAPI.Utils
{
    public class TemperaturaSingleton
    {
        private static TemperaturaSingleton _instance;
        private static List<Temperatura> lst;
        private TemperaturaSingleton()
        {
            lst = new List<Temperatura>();
        }
        public static TemperaturaSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TemperaturaSingleton();
            }
            return _instance;
        }
        public List<Temperatura> GetTemperaturas()
        {
            return lst;
        }

        public Temperatura GetById(int id)
        {
            var temp = lst.Find(temp => temp.Identificador == id);
            return temp;
        }
        public bool Save(Temperatura t)
        {
            bool aux = true;
            if (t == null)
                { aux = false; }    
            
            lst.Add(t);
            return aux;
        }

    }
}
