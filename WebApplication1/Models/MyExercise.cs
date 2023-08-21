namespace WebApplication1.Models
{
    public class MyExercise
    {
        /// <summary>
        /// Получить сумму каждого второго нечётного числа из массива
        /// </summary>
        public int GetSumOfEverySecondOddNumber(int[] numbers)
        {
            int resultSum = 0;
            bool wasFirstOddNumber = false;

            foreach (int number in numbers)
            {
                if (number%2!=0)
                {
                    if (wasFirstOddNumber)
                    {
                        resultSum += number;
                        wasFirstOddNumber = false;
                    }
                    else
                        wasFirstOddNumber = true;
                }
            }
            return resultSum;
        }

        /// <summary>
        /// Определить, является строка палиндромом или нет
        /// </summary>
        public bool IsStringPalindrome(string str, bool ignoreCase)
        {
            if (ignoreCase)
            {
                str = str.ToLowerInvariant();
            }

            int startIndex = 0;
            int endIndex = str.Length - 1;
            while (startIndex < endIndex)
            {
                if (str[startIndex] != str[endIndex])
                    return false;

                startIndex++;
                endIndex--;
            }

            return true;
        }
    }
}
