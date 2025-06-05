class Product {
    public string Name { get; set; }
    public double Price { get; set; }
    public int stockQuantity { get; set; }

    /**
     * Constructor to initialize a new product with name, price, and stock quantity.
     * @param name The name of the product.
     * @param price The price of the product.
     * @param stockQuantity The initial stock quantity of the product.
     */
    public Product (string name, double price, int stockQuantity) {
        Name = name;
        Price = price;
        this.stockQuantity = stockQuantity;
    }

    /**
     * Method to print out the product details.
     * @param None
     */
    public override string ToString() {
        return $"{Name} - ${Price} - {stockQuantity} in stock";
    }
}