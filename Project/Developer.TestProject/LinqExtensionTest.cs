using Developer.ExtensionCore;
using System.Linq.Expressions;

namespace Developer.TestProject
{
    [TestClass]
    public class LinqExtensionTest
    {
        private class TestPerson
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public bool IsActive { get; set; }
        }

        [TestMethod]
        public void AddExpression_CombineTwoExpressions_ShouldReturnCombinedExpression()
        {
            // Arrange
            Expression<Func<TestPerson, bool>> expr1 = p => p.Age > 18;
            Expression<Func<TestPerson, bool>> expr2 = p => p.IsActive;

            var testData = new[]
            {
                new TestPerson { Name = "John", Age = 25, IsActive = true },
                new TestPerson { Name = "Jane", Age = 17, IsActive = true },
                new TestPerson { Name = "Bob", Age = 30, IsActive = false },
                new TestPerson { Name = "Alice", Age = 22, IsActive = true }
            };

            // Act
            var combinedExpression = expr1.AddExpression(expr2);
            var compiled = combinedExpression.Compile();
            var result = testData.Where(compiled).ToList();

            // Assert
            Assert.IsNotNull(combinedExpression);
            Assert.HasCount(2, result);
            Assert.IsTrue(result.All(p => p.Age > 18 && p.IsActive));
            Assert.IsTrue(result.Any(p => p.Name == "John"));
            Assert.IsTrue(result.Any(p => p.Name == "Alice"));
        }

        [TestMethod]
        public void AddExpression_WithStringComparison_ShouldWorkCorrectly()
        {
            // Arrange
            Expression<Func<TestPerson, bool>> expr1 = p => p.Name.StartsWith("J");
            Expression<Func<TestPerson, bool>> expr2 = p => p.Age > 20;

            var testData = new[]
            {
                new TestPerson { Name = "John", Age = 25, IsActive = true },
                new TestPerson { Name = "Jane", Age = 17, IsActive = true },
                new TestPerson { Name = "Bob", Age = 30, IsActive = false },
                new TestPerson { Name = "Jack", Age = 22, IsActive = true }
            };

            // Act
            var combinedExpression = expr1.AddExpression(expr2);
            var compiled = combinedExpression.Compile();
            var result = testData.Where(compiled).ToList();

            // Assert
            Assert.IsNotNull(combinedExpression);
            Assert.HasCount(2, result);
            Assert.IsTrue(result.All(p => p.Name.StartsWith("J") && p.Age > 20));
        }

        [TestMethod]
        public void AddExpression_WithAllFalseConditions_ShouldReturnEmptyResult()
        {
            // Arrange
            Expression<Func<TestPerson, bool>> expr1 = p => p.Age > 100;
            Expression<Func<TestPerson, bool>> expr2 = p => p.Name == "NonExistent";

            var testData = new[]
            {
                new TestPerson { Name = "John", Age = 25, IsActive = true },
                new TestPerson { Name = "Jane", Age = 17, IsActive = true }
            };

            // Act
            var combinedExpression = expr1.AddExpression(expr2);
            var compiled = combinedExpression.Compile();
            var result = testData.Where(compiled).ToList();

            // Assert
            Assert.IsNotNull(combinedExpression);
            Assert.IsEmpty(result);
        }

        [TestMethod]
        public void AddExpression_ChainMultipleExpressions_ShouldWorkCorrectly()
        {
            // Arrange
            Expression<Func<TestPerson, bool>> expr1 = p => p.Age > 18;
            Expression<Func<TestPerson, bool>> expr2 = p => p.IsActive;
            Expression<Func<TestPerson, bool>> expr3 = p => p.Name.Length > 3;

            var testData = new[]
            {
                new TestPerson { Name = "John", Age = 25, IsActive = true },
                new TestPerson { Name = "Jo", Age = 20, IsActive = true },
                new TestPerson { Name = "Alice", Age = 22, IsActive = true },
                new TestPerson { Name = "Bob", Age = 30, IsActive = false }
            };

            // Act
            var combinedExpression = expr1.AddExpression(expr2).AddExpression(expr3);
            var compiled = combinedExpression.Compile();
            var result = testData.Where(compiled).ToList();

            // Assert
            Assert.IsNotNull(combinedExpression);
            Assert.HasCount(2, result);
            Assert.IsTrue(result.All(p => p.Age > 18 && p.IsActive && p.Name.Length > 3));
        }

        [TestMethod]
        public void AddExpression_WithComplexConditions_ShouldMaintainLogic()
        {
            // Arrange
            Expression<Func<TestPerson, bool>> expr1 = p => p.Age >= 18 && p.Age <= 30;
            Expression<Func<TestPerson, bool>> expr2 = p => p.IsActive || p.Name == "Bob";

            var testData = new[]
            {
                new TestPerson { Name = "John", Age = 25, IsActive = true },
                new TestPerson { Name = "Jane", Age = 17, IsActive = true },
                new TestPerson { Name = "Bob", Age = 28, IsActive = false },
                new TestPerson { Name = "Alice", Age = 22, IsActive = false },
                new TestPerson { Name = "Charlie", Age = 35, IsActive = true }
            };

            // Act
            var combinedExpression = expr1.AddExpression(expr2);
            var compiled = combinedExpression.Compile();
            var result = testData.Where(compiled).ToList();

            // Assert
            Assert.IsNotNull(combinedExpression);
            Assert.HasCount(2, result);
            Assert.IsTrue(result.Any(p => p.Name == "John"));
            Assert.IsTrue(result.Any(p => p.Name == "Bob"));
        }

        [TestMethod]
        public void AddExpression_WithSingleMatchingItem_ShouldReturnOneResult()
        {
            // Arrange
            Expression<Func<TestPerson, bool>> expr1 = p => p.Name == "John";
            Expression<Func<TestPerson, bool>> expr2 = p => p.Age == 25;

            var testData = new[]
            {
                new TestPerson { Name = "John", Age = 25, IsActive = true },
                new TestPerson { Name = "John", Age = 30, IsActive = true },
                new TestPerson { Name = "Jane", Age = 25, IsActive = true }
            };

            // Act
            var combinedExpression = expr1.AddExpression(expr2);
            var compiled = combinedExpression.Compile();
            var result = testData.Where(compiled).ToList();

            // Assert
            Assert.IsNotNull(combinedExpression);
            Assert.HasCount(1, result);
            Assert.AreEqual("John", result[0].Name);
            Assert.AreEqual(25, result[0].Age);
        }
    }
}
