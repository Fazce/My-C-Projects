class Inventory {
    private List<Product> products = new List<Product>();

    /**
     * Method to add a new product to the inventory.
     * @param name The name of the product.
     * @param price The price of the product.
     * @param stockQuantity The initial stock quantity of the product.
     */
    public void AddProduct(string name, double price, int stockQuantity) {
        products.Add(new Product (name, price, stockQuantity));
    }

    /**
     * Method to update the stock quantity of a product.
     * @param name The name of the product.
     * @param quantityChange The amount to change the stock by (positive or negative).
     */
    public void UpdateStock(string name, int quantityChange) {
        var product = products.Find(p => p.Name == name);
        if (product != null) {
            product.stockQuantity += quantityChange;
            Console.WriteLine($"Stock Updated! New stock for {name}: {product.stockQuantity}");
        } else {
            Console.WriteLine("Product not found.");
        }
    }

    /**
     * Method to view all products currently in the inventory.
     * @param None
     */
    public void ViewInventory() {
        Console.WriteLine("Current Inventory:");
        foreach (var product in products) {
            Console.WriteLine(product.ToString());
        }
    }

    /**
     * Method to remove a product from the inventory.
     * @param name The name of the product to remove.
     */
    public void RemoveProduct(string name) {
        var product = products.Find(p => p.Name == name);
        if (product != null) {
            products.Remove(product);
            Console.WriteLine($"Product {name} removed from inventory.");
        } else {
            Console.WriteLine("Product not found.");
        }
    }
}