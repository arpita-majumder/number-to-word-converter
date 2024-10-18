using Microsoft.AspNetCore.Mvc;

namespace NumberToWordAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberToWordController : ControllerBase
    {
        Dictionary<int, string> numberMap = new Dictionary<int, string>
        {
            {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"}, {5, "Five"},
            {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"}, {10, "Ten"},
            {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"}, {15, "Fifteen"},
            {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"}, {20, "Twenty"},
            {30, "Thirty"}, {40, "Forty"}, {50, "Fifty"}, {60, "Sixty"}, {70, "Seventy"},
            {80, "Eighty"}, {90, "Ninety"}
        };


        [HttpGet("ConvertNumberToWord/{numberToConvert}")]
        public  ActionResult<string> ConvertNumberToWord(string numberToConvert) 
        {
            String word = "";

            if(string.IsNullOrEmpty(numberToConvert) || numberToConvert == "undefined") 
            {
                return BadRequest("Amount cannot be empty");
            }

            if (decimal.TryParse(numberToConvert, out decimal result))
            {
                if (result > 100000000)
                {
                    return BadRequest("Enter number between millions");
                }

                word = ConvertNumber(result);
            }
            else
            {
                return BadRequest("Invalid Input");
            }

            return word;
        }

        private string ConvertNumber(decimal number)
        {
            string word = "";

            int dollars = (int)number;
            int cents = (int)((number - dollars) * 100);

            string dollarsToWord = ConvertToWord(dollars);
            word = dollarsToWord != "" ? dollarsToWord + " Dollars" : "";
            if (cents > 0)
            {
                string centsToWord = ConvertToWord(cents);
                word = word != "" ? ( word + " And " + centsToWord + " Cents" ) : (centsToWord + " Cents");
            }              

            return word.ToUpper();
        }

        private string ConvertToWord(int amount)
        {
            string word = "";

            if ((amount / 1000000) > 0)
            {
                word += ConvertToWord(amount / 1000000) + " Million ";
                amount %= 1000000;
            }
            if ((amount / 1000) > 0)
            {
                word += ConvertToWord(amount / 1000) + " Thousand ";
                amount %= 1000;
            }
            if ((amount / 100) > 0)
            {
                word += ConvertToWord(amount / 100) + " Hundred ";
                amount %= 100;
            }
            if (amount >= 20)
            {                    
                if ((amount % 10) == 0)
                {
                    word += numberMap[(amount - amount % 10)];
                    amount %= 10;
                }
                if ((amount / 10) > 0)
                {
                    word += numberMap[(amount - amount % 10)] + "-";
                    amount %= 10;
                }
            }
            if (amount > 0 && amount < 20)
            {
                word += numberMap[(int)amount];
            }
           
            return word.Trim();
        }
    }
}
