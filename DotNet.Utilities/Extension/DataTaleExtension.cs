//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Collections.Generic;
using System.Data;

namespace DotNet.Utilities
{
    public static class DataTaleExtension
    {
        public static List<T> ToList<T>(this DataTable dt) where T : new()
        {
            List<T> lstT = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                lstT.Add(dr.ToObject<T>());
            }
            return lstT;
        }

        public static T ToObject<T>(this DataRow dr) where T : new()
        {
            dynamic dynTemp = new T();
            return dynTemp.GetFrom(dr);
        }
    }
}
