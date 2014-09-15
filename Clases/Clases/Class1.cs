using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    //Clases de Peuba
    #region Clases_de_Prueba
    public class aaa
    {
        public int MyProperty { get; set; }
    }

    public class bbb
    {
        public int MyProperty { get; set; }
    }
    #endregion

    //Clase Principal
    public static class Class1
    {
        //Funcion que pasa los datos del objeto t al objeto s
        public static string TransformarClases<T,S>(T t, S s) 
                             where T: class where S : class
        {
            PropertyInfo[] t_propiedades = getPropertiesClass<T>(t);
            PropertyInfo[] s_propiedades = getPropertiesClass<S>(s);

            foreach (PropertyInfo propiedad in t_propiedades)
            {
                foreach (PropertyInfo sPropiedad in s_propiedades)
                {
                    if (propiedad.Name == sPropiedad.Name)
                    {
                        try
                        {
                            sPropiedad.SetValue(s, propiedad.GetValue(s));
                             return propiedad.GetValue(s).ToString();
                        }
                        catch (Exception)
                        {
                            return "Error al pasar los datos";
                        }
                    }
                }
            }
                return "Error al pasar los datos";
            
        }
        //Obtiene las propiedades del objeto pasado como paremetro
        public static PropertyInfo[]  getPropertiesClass<T>(T t) where T : class
        {
            Type type = null;
            PropertyInfo[] properties = null;
            type = t.GetType();
            properties = type.GetProperties();

            return properties;
            
        }

        //Crea nuevas instancias de clases, y ejecuta el metodo para pasar los datos.
        public static string metodo()
        {
            aaa t = new aaa();
            t.MyProperty = 1;
            bbb s = new bbb();
            s.MyProperty = 2;
            return TransformarClases<aaa, bbb>(t, s);
        }

    }
}
