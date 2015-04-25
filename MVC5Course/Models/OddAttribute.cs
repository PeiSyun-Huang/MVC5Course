using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    // 自訂輸入驗證
    public class OddAttribute : DataTypeAttribute
    {
        public OddAttribute() : base("Odd")
        {

        }
        public override bool IsValid(object value)
        {
            try
            {
                if (int.Parse(value.ToString()) % 2 == 0)
                {
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }
    }
}