using Draw.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.BLL.Model
{
    public class Reponse<T> : IResponse<T>
    {
        public bool IsSuccess{get; private set;}

        public string Message { get; private set; }

        public T Result { get; private set; }
       

        public static Reponse<T> Error(string message)
        {
            return new Reponse<T>() { Message = message, IsSuccess = false };
        }

        public static Reponse<T> Success(string message)
        {
            return new Reponse<T>() { Message = message, IsSuccess = true };
        }
        public static Reponse<T> Success(T result)
        {
            return new Reponse<T>() { Result= result,IsSuccess=true };
        }
        public static Reponse<T> Success(string message,T result)
        {
            return new Reponse<T>() { Message= message, Result = result, IsSuccess = true };
        }
    }
}
