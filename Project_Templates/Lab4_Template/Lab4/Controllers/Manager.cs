using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using Lab4.Models;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class Manager
    {
        private DataContext ds = new DataContext();

        // ############################################################
        // Answers to various questions

        public List<string> GetProductSizes()
        {
            // Return a collection of strings
            return null;
        }

        // ############################################################
        // Supplier - get all, get all for select list

        public IEnumerable<SupplierBase> GetAllSuppliers()
        {
            // Fetch from the data store
            // Prepare the return result
            // Return the result
            return null;
        }

        // Get list
        public IEnumerable<SupplierList> GetAllSuppliersList()
        {
            // Fetch from the data store
            // Prepare the return result
            // Return the result
            return null;
        }

        // ############################################################
        // Product - get all, get one, add new

        public IEnumerable<ProductBase> GetAllProducts()
        {
            // Fetch from the data store
            // Prepare the return result
            // Return the result
            return null;
        }

        public ProductBase GetProductById(int id)
        {
            // Fetch from the data store
            // If not found, return null
            // Otherwise, continue
            // Prepare the return result
            // Return the result
            return null;
        }

        public ProductBase AddNewProduct(ProductAdd newItem)
        {
            // Attempt to fetch the supplier object
            // If that fails, return null
            // Otherwise, continue
            // Create a new design model object
            // Its properties come from the passed-in 'newItem' object
            // Remember to configure the Supplier property correctly
            // Add to the peristent store, and save changes
            // Prepare the return result
            // Return the result
            return null;
        }

    }

}
