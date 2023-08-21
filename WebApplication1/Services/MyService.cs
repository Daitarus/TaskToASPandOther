using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class MyService : IMyServise
    {
        public Response ExecuteExercise(Request request)
        {
            if (request.RequestDatas.Count == 0)
                return new Response(true, "Пустые переданные данные!");

            return request.ExerciseType switch
            {
                ExerciseType.First => GetResponseForFirstExercise(request.RequestDatas),
                ExerciseType.Second => GetResponseForSecondExercise(request.RequestDatas[0]),
                ExerciseType.Third => GetResponseForThirdExercise(request.RequestDatas),
                _ => throw new SwitchExpressionException()
            };
        }

        private Response GetResponseForFirstExercise(IList<string> requestStr)
        {
            MyExercise exercise = new MyExercise();
            IList<int> requestInt = ConvertToListInt(requestStr);
            if (requestInt.Count == 0)
                return new Response(true, "Ошибка преобразования введённых данных!");

            int responseInt = exercise.GetSumOfEverySecondOddNumber(requestInt.ToArray());
            return new Response(responseInt.ToString());
        }
        private Response GetResponseForSecondExercise(string requestStr)
        {
            if (string.IsNullOrEmpty(requestStr))
                return new Response(true, "Пустые переданные данные!");

            MyExercise exercise = new MyExercise();
            bool responseBool = exercise.IsStringPalindrome(requestStr, true);

            string responseStr;
            if (responseBool)
                responseStr = "Строка является палиндромом";
            else
                responseStr = "Строка не является палиндромом";

            return new Response(responseStr);
        }
        private Response GetResponseForThirdExercise(IList<string> requestStr)
        {
            IList<int> requestInt = ConvertToListInt(requestStr);
            if (requestInt.Count == 0)
                return new Response(true, "Ошибка преобразования введённых данных!");

            MyList<int> myList = new MyList<int>(requestInt.Count);
            foreach (int item in requestInt)
            {
                myList.Add(item);
            }

            myList.Sort();

            StringBuilder responseStr = new StringBuilder();
            for(int i = 0; i < myList.Count; i++)
            {
                responseStr.Append(myList[i].ToString());
                responseStr.Append(" ");
            }
            return new Response(responseStr.ToString());
        }

        private IList<int> ConvertToListInt(IList<string> stringList)
        {
            IList<int> listInt = new List<int>();

            foreach (string str in stringList)
            {
                int num = 0;
                int.TryParse(str, out num);
                if (int.TryParse(str, out num))
                    listInt.Add(num);
                else
                {
                    listInt.Clear();
                    return listInt;
                }
            }

            return listInt;
        }

    }
}
