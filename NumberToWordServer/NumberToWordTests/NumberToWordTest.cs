using Microsoft.AspNetCore.Mvc;
using NumberToWordAPI;
using NumberToWordAPI.Controllers;

namespace NumberToWordTests
{
    public class Tests
    {
        NumberToWordController _controller;

        [SetUp]
        public void Setup()
        {
            // Initialize the controller before each test
            _controller = new NumberToWordController();
        }

        [Test]
        public void ConvertNumberToWord_InvalidNumber()
        {
            string input = "testnumber";

            var result = _controller.ConvertNumberToWord(input);

            var badRequestResult = result.Result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
        }

        [Test]
        public void ConvertNumberToWord_ValidNumberWithoutDecimal()
        {
            string input = "45";
            string output = "FORTY-FIVE DOLLARS";

            var result = _controller.ConvertNumberToWord(input);

            // Assert
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(result.Value, output);
        }

        [Test]
        public void ConvertNumberToWord_ValidNumberWithDecimal()
        {
            string input = "45.56";
            string output = "FORTY-FIVE DOLLARS AND FIFTY-SIX CENTS";

            var result = _controller.ConvertNumberToWord(input);

            // Assert
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(result.Value, output);
        }

        [Test]
        public void ConvertNumberToWord_InvalidDecimal()
        {
            string input = "12.34.56";

            var result = _controller.ConvertNumberToWord(input);

            var badRequestResult = result.Result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
        }

        [Test]
        public void ConvertNumberToWord_Null()
        {
            string input = "";

            var result = _controller.ConvertNumberToWord(input);

            var badRequestResult = result.Result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
        }
    }
}