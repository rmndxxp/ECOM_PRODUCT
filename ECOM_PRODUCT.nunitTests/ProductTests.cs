namespace ECOM_PRODUCT.nunitTests
{
    [TestFixture]
    public class ProductTests
    {
        private Product _product { get; set; } = null;
        [SetUp]
        public void Setup()
        {
            _product = new Product(1, "Product 1", 20.15m, 50);
        }
        //***********TestCases for ProductID***********

        // Test case 1: The ID should be in the valid range
        [Test]
        public void ProductID_ShouldBeWithinValidRange()
        {
            // Act
            var actualProductID = _product.ProductID;

            // Assert
            Assert.That(actualProductID, Is.InRange(1, 5000));
        }

        // Test case 2: Verifying the last product has ProductID = 5000
        [Test]
        public void ProductID_ShouldBeMaximumValue()
        {
            // Arrange
            _product = new Product(5000, "Product XYZ", 30.14m, 90);
            var expectedMaxValue = 5000;

            // Act
            var actualProductID = _product.ProductID;

            // Assert
            Assert.That(actualProductID, Is.EqualTo(expectedMaxValue));
        }

        // Test case 3: Asserts that the ProductID property is set correctly when creating a new Product
        [Test]
        public void ProductID_ShouldBeSetCorrectly()
        {
            // Arrange
            var expectedProductID = 42;
            _product = new Product(expectedProductID, "Product 42", 15.99m, 30);

            // Act
            var actualProductID = _product.ProductID;

            // Assert
            Assert.That(actualProductID, Is.EqualTo(expectedProductID));
        }

        //***********TestCases for Price***********

        // Test case 1: Price should always be greater than or equal to 1
        [Test]
        public void Price_ShouldBeMinimumValue()
        {
            // Arrange
            var expectedMinPrice = 1m;
            _product = new Product(1, "Product 1", expectedMinPrice, 50);

            // Act
            var actualPrice = _product.Price;

            // Assert
            Assert.That(actualPrice, Is.EqualTo(expectedMinPrice));
        }

        // Test case 2: Price should always be less than or equal to 10000
        [Test]
        public void Price_ShouldBeMaximumValue()
        {
            // Arrange
            var expectedMaxPrice = 10000m;
            _product = new Product(1, "Product 1", expectedMaxPrice, 50);

            // Act
            var actualPrice = _product.Price;

            // Assert
            Assert.That(actualPrice, Is.EqualTo(expectedMaxPrice));
        }

        // Test case 3: Price should update correctly
        [Test]
        public void Price_ShouldBeUpdatedCorrectly()
        {
            // Arrange
            var expectedNewPrice = 30.25m;

            // Act
            _product.Price = expectedNewPrice;

            // Assert
            Assert.That(_product.Price, Is.EqualTo(expectedNewPrice));
        }

        //***********TestCases for ProductName***********

        // Test case 1: Updating ProductName attribute
        [Test]
        public void ProductName_ShouldBeUpdatedCorrectly()
        {
            // Arrange
            var expectedNewName = "Updated Product Name";

            // Act
            _product.ProductName = expectedNewName;

            // Assert
            Assert.That(_product.ProductName, Is.EqualTo(expectedNewName));
        }

        // Test case 2: Updating ProductName attribute with null value
        [Test]
        public void ProductName_ShouldAllowNullValue()
        {
            // Act
            _product.ProductName = null;

            // Assert
            Assert.That(_product.ProductName, Is.Null);
        }

        // Test case 3: Updating ProductName attribute with an empty string
        [Test]
        public void ProductName_ShouldAllowEmptyString()
        {
            // Act
            _product.ProductName = "";

            // Assert
            Assert.That(_product.ProductName, Is.EqualTo(""));
        }

        //***********TestCases for Stock***********

        // Test case 1: Updating Stock attribute
        [Test]
        public void Stock_Update()
        {
            // Arrange
            var expectedStock = 30;

            // Act
            _product.Stock = expectedStock;

            // Assert
            Assert.That(_product.Stock, Is.EqualTo(expectedStock));
        }

        // Test case 2: Verifying stock is in specified range
        [Test]
        public void Stock_InSpecifiedRange()
        {
            // Arrange
            _product = new Product(1, "Product 1", 14.0m, 3500);

            // Act
            var actualStock = _product.Stock;

            // Assert
            Assert.That(actualStock, Is.InRange(1, 5000));
        }

        // Test case 3: Stock property is set correctly when creating a new Product
        [Test]
        public void Stock_ShouldBeSetCorrectly()
        {
            // Arrange
            var expectedStock = 100;
            _product = new Product(2, "Product 2", 10.99m, expectedStock);

            // Act
            var actualStock = _product.Stock;

            // Assert
            Assert.That(actualStock, Is.EqualTo(expectedStock));
        }
        //*********Test Cases for Increase Stock Method **********
        // Test case 1: Increasing stock with a positive quantity
        [Test]
        public void IncreaseStock_WithPositiveQuantity_ShouldIncreaseStock()
        {
            // Arrange
            var increaseQuantity = 10;
            var expectedStock = _product.Stock + increaseQuantity;

            // Act
            _product.IncreaseStock(increaseQuantity);

            // Assert
            Assert.That(_product.Stock, Is.EqualTo(expectedStock));
        }

        // Test case 2: Increasing stock with a negative quantity should throw an exception
        [Test]
        public void IncreaseStock_WithNegativeQuantity_ShouldThrowArgumentException()
        {
            // Arrange
            var increaseQuantity = -10;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _product.IncreaseStock(increaseQuantity));
            Console.WriteLine(ex.Message);
            Assert.That(ex.Message, Is.EqualTo("Quantity cannot be Empty or Less than 0"));
        }

        // Test case 3: Increasing stock with zero quantity should not change stock
        [Test]
        public void IncreaseStock_WithZeroQuantity_ShouldNotChangeStock()
        {
            // Arrange
            var increaseQuantity = 0;
            var expectedStock = _product.Stock;

            // Act
            _product.IncreaseStock(increaseQuantity);

            // Assert
            Assert.That(_product.Stock, Is.EqualTo(expectedStock));
        }

        //*********Test Cases for Decrease Stock Method **********

        // Test case 1: Decreasing stock with a positive quantity
        [Test]
        public void DecreaseStock_WithPositiveQuantity_ShouldDecreaseStock()
        {
            // Arrange
            var decreaseQuantity = 10;
            var expectedStock = _product.Stock - decreaseQuantity;

            // Act
            _product.DecreaseStock(decreaseQuantity);

            // Assert
            Assert.That(_product.Stock, Is.EqualTo(expectedStock));
        }

        // Test case 2: Decreasing stock with a negative quantity should throw an exception
        [Test]
        public void DecreaseStock_WithNegativeQuantity_ShouldThrowArgumentException()
        {
            // Arrange
            var decreaseQuantity = -10;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _product.DecreaseStock(decreaseQuantity));
            Assert.That(ex.Message, Is.EqualTo("Quantity cannot be Empty or Negative"));
        }

        // Test case 3: Decreasing stock with a quantity greater than available stock should throw an exception
        [Test]
        public void DecreaseStock_WithQuantityGreaterThanStock_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var decreaseQuantity = _product.Stock + 10;

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => _product.DecreaseStock(decreaseQuantity));
            Assert.That(ex.Message, Is.EqualTo("Not enough stock available"));
        }
    }
}
