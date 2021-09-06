using System.Collections.Generic;
using System.Linq;

namespace PCWebApp.Utils
{
    static class Utils
    {
        public static List<string> DesserializarString(string text){
            return text.Split(";").ToList();
        }

        public static string SerializarString(List<string> list){
            return string.Join(";", list);
        }
    }
}